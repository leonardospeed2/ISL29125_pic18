/**
 * File:   main.c
 * Author: Leonardo & Vitor
 *
 * Created on 18 de Junho de 2016, 14:16
 */

#include <xc.h>                                       
#include "config.h"                     
#include "eusart.h"
#include "isl29125.h"

/**
*funcao main, recebe um byte da USART, conforme o byte recebido pode mostrar a cor
* vermelha, verde, azul ou RGB 
*\image html main.png
*/
void main(void) {
    char rx;                            //variavel de rececao USART
    TRISCbits.RC6 = FALSE;              //TX pin output
    TRISCbits.RC7 = TRUE;               //RX pin Input
    TRISCbits.RC3 = TRUE;               //SCL pin 
    TRISCbits.RC4 = TRUE;               //SDA pin
    ConfigUsart();                      //configurar usart
    OpenISL();                          //Abrir comunicacao I2C
    StartISL();                         //ligar o sensor ISL    
    while(TRUE){                        //loop infinito
        rx = getc_USART();              //guardar caracter que recebeu da USART
        switch(rx){                     //decisao  
            case 'R':{                  //se for rx == R
                ColorRED();             //chamar funcao cor vermelha
                break;                  //salta fora
            }
            case 'G':{                  //se for rx == G
                ColorGREEN();           //chamar funcao cor verde
                break;                  //salta fora
            }
            case 'B':{                  //se for rx == B
                ColorBLUE();            //chamar funcao cor azul
                break;                  //saltar fora
            }
            case 'A':{                  //se for rx == A
                ColorRED();             //chamar funcao cor vermelha
                ColorGREEN();           //chamar funcao cor verde
                ColorBLUE();            //chamar funcao cor azul
                break;                  //salta fora
            }
        }
    }
    return;
}