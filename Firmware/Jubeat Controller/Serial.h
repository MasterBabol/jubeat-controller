#ifndef SERIAL_H_
#define SERIAL_H_

#include <avr/io.h>

#define BaudRateCalculationU2X0(clock, baudRate) ((clock + (baudRate * 8))/(16*baudRate) - 1)

void UsartInit();
unsigned char UsartSyncRecv();
void UsartSyncSend(unsigned char data);

#endif