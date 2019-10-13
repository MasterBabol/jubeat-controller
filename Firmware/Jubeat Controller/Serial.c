#include "Serial.h"

void UsartInit()
{
	UCSR1A = 0x00;
	UCSR1B = 0b00011000;
	
	UBRR1L = 103;
	UBRR1H = 0;
}

unsigned char UsartSyncRecv()
{
	while(!(UCSR1A & (1 << RXC)));
	return UDR1;
}

void UsartSyncSend(unsigned char data)
{
	while(!(UCSR1A & (1 << UDRE)));
	UDR1 = data;
}
