/** 
 * File:    config.h
 * Author:  Leonardo & Vitor
 */

#pragma config WDT = OFF        ///desativar watchdog
#pragma config OSC = RCIO       ///oscilador externo
#pragma config FCMEN = OFF      ///Fail-safe clock monitor disabled
#pragma config IESO = OFF       ///oscilador switchover disabled
#define _XTAL_FREQ 20000000     ///frequencai oscilador 20MHz
#define TRUE 1                  ///verdade valor 1
#define FALSE 0                 ///falso valor 0
/**
 
 */