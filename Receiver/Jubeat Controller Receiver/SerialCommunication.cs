using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

class SerialCommunication : IDisposable
{
	private SerialPort serialConnection;

	public SerialCommunication(String portName, Int32 baudRate)
	{
		serialConnection = new SerialPort(portName, baudRate);
		serialConnection.StopBits = StopBits.One;
		serialConnection.Parity = Parity.None;
	}

	~SerialCommunication()
	{
		Dispose(false);
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(Boolean userDisposing)
	{
		if (userDisposing)
		{
			try
			{
				serialConnection.DiscardOutBuffer();
			}
			catch (Exception) { }
			try
			{
				serialConnection.DiscardInBuffer();
			}
			catch (Exception) { }
			try
			{
				new System.Threading.Thread(new System.Threading.ThreadStart(delegate() { serialConnection.Close(); })).Start();
			}
			catch (Exception) { }
		}
	}

	public void Open()
	{
		serialConnection.Open();
	}

	public void SendByte(byte data)
	{
		serialConnection.Write(new byte[1] { data }, 0, 1);
	}

	public void SendByte(byte[] data)
	{
		serialConnection.Write(data, 0, data.Length);
	}

	public byte ReadByte()
	{
		return (byte)serialConnection.ReadByte();
	}

	public int ReadBuffer(byte[] buffer, int offset, int count)
	{
		return serialConnection.Read(buffer, offset, count);
	}

	public void AddReceiveHandler(SerialDataReceivedEventHandler handler)
	{
		serialConnection.DataReceived += handler;
	}

	public Boolean Connected
	{
		get
		{
			return serialConnection.IsOpen;
		}
	}
}

