/**
* \file eusart.h
* \author  Leonardo & Vitor
* biblioteca de configuracao da USART
*/
#include "plib/usart.h"
#define BAUD 10         //115200 baud rate

/**
* funcao de configuracao de uma USART, sem interrupcoes, modo assincrono e
* baud rate 115200
*\image html usartconfig.png
*/
void ConfigUsart(){
    PIR1bits.RCIF = FALSE;      //bandeira rececao falsa
    IPR1bits.RCIP = FALSE;      //prioridade alta falsa
    PIE1bits.RCIE = FALSE;      //interrupcao na rececao falsa
    INTCONbits.PEIE = FALSE;    //interrupcao global desativada
    OpenUSART(USART_TX_INT_OFF & USART_RX_INT_OFF & USART_ASYNCH_MODE & USART_EIGHT_BIT & USART_BRGH_HIGH,BAUD);
}

/**
* funcao de ler um caracter da USART
*\image html getc_USART.png
*/
char getc_USART(){
    while(!PIR1bits.RCIF);  //esperar que chegue um byte
    return getcUSART();     //retorno do byte
}
