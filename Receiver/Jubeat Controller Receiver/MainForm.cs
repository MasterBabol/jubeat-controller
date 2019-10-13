using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Runtime.InteropServices;

namespace Jubeat_Controller_Receiver
{
	public partial class MainForm : Form
	{
		private SerialCommunication serialComm = null;
		private Timer timer = null;
		private byte[] keyBuffers = new byte[2];
		private char[] charMap = new Char[] { '4', '5', '6', '7',
											'r', 't', 'y', 'u',
											'f', 'g', 'h', 'j',
											'v', 'b', 'n', 'm' };

		private enum KeyState
		{
			KeyPress,
			KeyRelease,
			Nothing
		}

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{

		}

		private void SerialDataReceived(Object sender, SerialDataReceivedEventArgs e)
		{
			byte buf1 = serialComm.ReadByte();
			byte buf2 = serialComm.ReadByte();

			/*List<bool> status = CompareKeyStates(buf1, buf2);
			int count = 0;
			foreach (bool b in status)
			{
				if (b)
					SendKey(charMap[count]);
				count++;
			}
			keyBuffers[0] = buf1;
			keyBuffers[1] = buf2;*/
			List<KeyState> status = KeyStates(buf1, buf2);
			int count = 0;
			foreach (KeyState b in status)
			{
				switch (b)
				{
					case KeyState.KeyPress:
						PressKey(charMap[count]);
						break;
					case KeyState.KeyRelease:
						ReleaseKey(charMap[count]);
						break;
				}
				count++;
			}
			keyBuffers[0] = buf1;
			keyBuffers[1] = buf2;

			try
			{
				this.Invoke(new MethodInvoker(delegate()
				{
					Char[] buf1Chars = Convert.ToString(buf1, 2).PadLeft(8, '0').ToCharArray();
					Char[] buf2Chars = Convert.ToString(buf2, 2).PadLeft(8, '0').ToCharArray();
					Array.Reverse(buf1Chars);
					Array.Reverse(buf2Chars);
					textBox1.Text = new String(buf1Chars);
					textBox1.Text += new String(buf2Chars);
				}));
			}
			catch (Exception) { }
		}

		private void buttonConnect_Click(object sender, EventArgs e)
		{
			Int32 baudRate = 0;

			try
			{
				baudRate = Int32.Parse(textBaudRate.Text);
			}
			catch (Exception)
			{
				MessageBox.Show("Invalid Baud Rate.");
				return;
			}

			try
			{
				serialComm = new SerialCommunication(textPortName.Text, baudRate);
				serialComm.AddReceiveHandler(SerialDataReceived);
				serialComm.Open();

				if (serialComm.Connected == false)
					throw new Exception();
			}
			catch (Exception)
			{
				MessageBox.Show("Cannot connect to " + textPortName.Text);
				serialComm.Dispose();
				serialComm = null;
				return;
			}

			keyBuffers[0] = keyBuffers[1] = 0xFF;
			buttonConnect.Enabled = false;
			buttonDisconnect.Enabled = true;
			buttonRequest.Enabled = true;
			checkAutorequest.Enabled = true;
		}

		private void buttonDisconnect_Click(object sender, EventArgs e)
		{
			if (serialComm != null)
			{
				serialComm.Dispose();
				serialComm = null;
				buttonConnect.Enabled = true;
				buttonDisconnect.Enabled = false;
				buttonRequest.Enabled = false;
				checkAutorequest.Enabled = false;
			}
		}

		private void buttonRequest_Click(object sender, EventArgs e)
		{
			if (serialComm != null)
			{
				if (serialComm.Connected)
					serialComm.SendByte(new byte[] { 0xfa, 0xce });
				else
					buttonDisconnect.PerformClick();
			}
		}

		private void checkAutorequest_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if (checkAutorequest.Checked == true)
				{
					if (timer == null)
					{
						timer = new Timer();
						timer.Interval = 10;
						timer.Tick += timerHandler;
						timer.Enabled = true;
					}
					if (timer.Enabled == false)
						timer.Enabled = true;
				}
				else
				{
					if (timer != null)
					{
						timer.Enabled = false;
					}
				}
			}
			catch (Exception)
			{
				buttonDisconnect.PerformClick();
			}
		}

		private void timerHandler(object sender, EventArgs e)
		{
			try
			{
				if (serialComm != null)
					if (serialComm.Connected == true)
					{
						buttonRequest.PerformClick();
					}
			}
			catch (Exception)
			{
				buttonDisconnect.PerformClick();
			}
		}

		private List<KeyState> KeyStates(byte buf1, byte buf2)
		{
			List<KeyState> list = new List<KeyState>();

			int cursor;
			KeyState state;
			for (cursor = 0; cursor < 8; cursor++)
			{
				state = KeyState.Nothing;
				if ((buf1 & (1 << cursor)) != (keyBuffers[0] & (1 << cursor)))
				{
					if ((buf1 & (1 << cursor)) == 0)
						state = KeyState.KeyPress;
					else
						state = KeyState.KeyRelease;
				}
				list.Add(state);
			}
			for (cursor = 0; cursor < 8; cursor++)
			{
				state = KeyState.Nothing;
				if ((buf2 & (1 << cursor)) != (keyBuffers[1] & (1 << cursor)))
				{
					if ((buf2 & (1 << cursor)) == 0)
						state = KeyState.KeyPress;
					else
						state = KeyState.KeyRelease;
				}
				list.Add(state);
			}

			return list;
		}

		private List<bool> CompareKeyStates(byte buf1, byte buf2)
		{
			List<bool> list = new List<bool>();
			
			// [buf2] [buf1]
			// [keyBuffers[1]] [keyBuffers[0]]
			int cursor;
			bool state;
			for (cursor = 0; cursor < 8; cursor++)
			{
				state = false;
				if ((buf1 & (1 << cursor)) != (keyBuffers[0] & (1 << cursor)))
				{
					if ((keyBuffers[1] & (1 << cursor)) != 0)
						state = true;
				}
				list.Add(state);
			}
			for (cursor = 0; cursor < 8; cursor++)
			{
				state = false;
				if ((buf2 & (1 << cursor)) != (keyBuffers[1] & (1 << cursor)))
				{
					if ((keyBuffers[1] & (1 << cursor)) != 0)
						state = true;
				}
				list.Add(state);
			}

			return list;
		}


		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
		public const int MOUSEEVENTF_LEFTDOWN = 0x02;
		public const int MOUSEEVENTF_LEFTUP = 0x04;
		public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
		public const int MOUSEEVENTF_RIGHTUP = 0x10;
		public const int MOUSEEVENTF_WHEEL = 0x800;

		[DllImport("user32.dll", SetLastError = true)]
		static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
		public const int KEYEVENTF_EXTENDEDKEY = 0x0001;
		public const int KEYEVENTF_KEYUP = 0x0002;

		[DllImport("user32.dll")]
		static extern short VkKeyScan(char ch);

		public static void SendKeys(string text)
		{
			foreach (char c in text)
			{
				SendKey(c);
			}
		}

		public static void SendKey(char key)
		{
			short vkstate = VkKeyScan(key);
			byte vkey = (byte)(vkstate & 0xFF); // Low byte contains VKEY

			SendKey(vkey);
		}

		public static void SendKey(byte vkey)
		{
			// Simulate a key press
			keybd_event(vkey,
						 0x45,
						 KEYEVENTF_EXTENDEDKEY | 0,
						 0);

			// Simulate a key release
			keybd_event(vkey,
						 0x45,
						 KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP,
						 0);
		}

		public static void PressKey(char key)
		{
			short vkstate = VkKeyScan(key);
			byte vkey = (byte)(vkstate & 0xFF); // Low byte contains VKEY

			PressKey(vkey);
		}

		public static void PressKey(byte vkey)
		{
			keybd_event(vkey,
						 0x45,
						 KEYEVENTF_EXTENDEDKEY | 0,
						 0);
		}

		public static void ReleaseKey(char key)
		{
			short vkstate = VkKeyScan(key);
			byte vkey = (byte)(vkstate & 0xFF); // Low byte contains VKEY

			ReleaseKey(vkey);
		}

		public static void ReleaseKey(byte vkey)
		{
			keybd_event(vkey,
						 0x45,
						 KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP,
						 0);
		}
	}

}


