#include <avr/io.h>
#include "Serial.h"

int main(void)
{	
	UsartInit();
	
	for(;;)
	{
		if (UsartSyncRecv() == 0xfa)
		{
			if (UsartSyncRecv() == 0xce)
			{
				UsartSyncSend(PINA);
				UsartSyncSend(PINC);
			}	
		}
		PORTA = PINE;
	}
}
