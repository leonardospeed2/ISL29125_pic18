/** 
 * File:    eusart.h
 * Author:  Leonardo & Vitor
 */

#include "plib/usart.h"
#define BAUD 10         ///115200 baud rate

///configurar usart
void ConfigUsart(){
    PIR1bits.RCIF = FALSE;      ///bandeira rececao falsa
    IPR1bits.RCIP = FALSE;      ///prioridade alta falsa
    PIE1bits.RCIE = FALSE;      ///interrupcao na rececao falsa
    INTCONbits.PEIE = FALSE;    ///interrupcao global desativada    
    OpenUSART(USART_TX_INT_OFF & USART_RX_INT_OFF & USART_ASYNCH_MODE & USART_EIGHT_BIT & USART_BRGH_HIGH,BAUD);
}

///receber um carater
char getc_USART(){
    while(!PIR1bits.RCIF);  ///esperar que chegue um byte
    return getcUSART();     ///retorno do byte
}
