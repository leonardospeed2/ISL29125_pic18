/* *
 * File:    isl29125   
 * Author:  Leonardo & Vitor
 */

/** 
 * biblioteca de configuracao do sensor ISL29125
 */
#include <plib/i2c.h>

//ISL29125 Registos
#define DEVICE_ID 0x00
#define CONFIG_1 0x01
#define CONFIG_2 0x02
#define CONFIG_3 0x03
#define THRESHOLD_LL 0x04
#define THRESHOLD_LH 0x05
#define THRESHOLD_HL 0x06
#define THRESHOLD_HH 0x07
#define STATUS 0x08 
#define GREEN_L 0x09 
#define GREEN_H 0x0A
#define RED_L 0x0B
#define RED_H 0x0C
#define BLUE_L 0x0D
#define BLUE_H 0x0E

//config 1
//modo de operacao
#define CFG1_MODE_POWERDOWN 0x00
#define CFG1_MODE_G 0x01
#define CFG1_MODE_R 0x02
#define CFG1_MODE_B 0x03
#define CFG1_MODE_STANDBY 0x04
#define CFG1_MODE_RGB 0x05
#define CFG1_MODE_RG 0x06
#define CFG1_MODE_GB 0x07

//LUX
#define CFG1_375LUX 0x00
#define CFG1_10KLUX 0x08

//ADC
#define CFG1_16BIT 0x00
#define CFG1_12BIT 0x10

//interrupcao sim  nao
#define CFG1_ADC_SYNC_NORMAL 0x00
#define CFG1_ADC_SYNC_TO_INT 0x20

//config 2
//tamanho filtro IR
#define CFG2_IR_OFFSET_OFF 0x00
#define CFG2_IR_OFFSET_ON 0x80

//calibracao do filtro IR
#define CFG2_IR_ADJUST_LOW 0x00
#define CFG2_IR_ADJUST_MID 0x20
#define CFG2_IR_ADJUST_HIGH 0x3F

//config 3
//interrupcaoes baseada em cores
#define CFG3_NO_INT 0x00
#define CFG3_G_INT 0x01
#define CFG3_R_INT 0x02
#define CFG3_B_INT 0x03

//numreo de amostras que interrupcao deve desparar
#define CFG3_INT_PRST1 0x00
#define CFG3_INT_PRST2 0x04
#define CFG3_INT_PRST4 0x08
#define CFG3_INT_PRST8 0x0C

//se conversao estiver concluida disparar uma interrupcao
#define CFG3_RGB_CONV_TO_INT_DISABLE 0x00
#define CFG3_RGB_CONV_TO_INT_ENABLE 0x10

//bandeiras de estado
#define FLAG_INT 0x01
#define FLAG_CONV_DONE 0x02
#define FLAG_BROWNOUT 0x04
#define FLAG_CONV_G 0x10
#define FLAG_CONV_R 0x20
#define FLAG_CONV_B 0x30

//configuracoes por defeito
#define CFG_DEFAUT 0x00
#define READISL 0x89
#define WRITEISL 0x88
#define BRG 49  //i2c comunicacao 100kHz

/**
* funcao abrir uma comunica��o I2C
*\image html OpenISL.png
*/
void OpenISL(){
    SSPADD = BRG;                   //100kHz                   
    OpenI2C(MASTER, SLEW_OFF);      //PIC como master frequencia baixa 100kHz
    IdleI2C();                      //esperar bus esteja livre
}

/**
* funcao de escrever para o sensor ISL29125
*\image html WriteISL.png
*\image html blockWriteISL.png
*/
void WriteISL(unsigned char address,unsigned char data){
    IdleI2C();                      //esperar bus esteja livre
    StartI2C();                     //enviar Start transmissao
    while(SSPCON2bits.SEN);         //esperar que condicao start acaba
    WriteI2C(WRITEISL);             //enviar 7 bits referentes ISL e 8 bit de escrita
    IdleI2C();                      //esperar bus esteja livre
    WriteI2C(address);              //enviar endereco
    IdleI2C();                      //esperar bus esteja livre
    WriteI2C(data);                 //enviar dados
    IdleI2C();                      //esperar bus esteja livre
    StopI2C();                      //Parar a transmissao
}

/**
* funcao de ler do sensor ISL29125
*\image html ReadISL.png
*\image html blockReadISL.png
*/
unsigned char ReadISL(char address){
    char data;                      //variavel onde vai guardar byte vindo isl
    IdleI2C();                      //esperar bus esteja livre
    StartI2C();                     //enviar Start transmissao
    while(SSPCON2bits.SEN);         //esperar que condicao start acaba
    WriteI2C(WRITEISL);             //enviar 7 bits referentes ISL e 8 bit de escrita
    IdleI2C();                      //esperar bus esteja livre
    WriteI2C(address);              //enviar endereco
    IdleI2C();                      //esperar bus esteja livre
    RestartI2C();                   //enviar restart transmissao
    while(SSPCON2bits.RSEN);        //esperar que condicao restart acaba
    WriteI2C(READISL);              //enviar 7 bits referentes ISL e 8 bit de leitura
    IdleI2C();                      //esperar bus esteja livre
    data = getcI2C();               //receber byte do ISL
    StopI2C();                      //Parar a transmissao
    return data;                    //retorno data
}

/**
* funcao de configurar a config_1 ISL29125
*\image html ConfigISL1.png
*/
void ConfigISL1(unsigned char cfg){
    WriteISL(CONFIG_1,cfg);         //configuracao 1
}

/**
* funcao de configurar a config_2 ISL29125
*\image html ConfigISL2.png
*/
void ConfigISL2(unsigned char cfg){
    WriteISL(CONFIG_2,cfg);        //configuracao 2
}

/**
* funcao de configurar a config_3 ISL29125
*\image html ConfigISL3.png
*/
void ConfigISL3(unsigned char cfg){
    WriteISL(CONFIG_3,cfg);        //configuracao 3
}

/**
* funcao para por a ADC do sensor ligado
*\image html StartISL.png
*/
void StartISL(){
    ConfigISL1(CFG1_MODE_STANDBY | CFG1_10KLUX | CFG1_16BIT | CFG1_ADC_SYNC_NORMAL);
    ConfigISL2(CFG2_IR_OFFSET_ON | CFG2_IR_ADJUST_HIGH | 0x00);
}

/**
* funcao para por a ADC do sensor desligado
*\image html StopISL.png
*/
void StopADCISL(){
    ConfigISL1(CFG1_MODE_POWERDOWN | CFG1_10KLUX | CFG1_16BIT | CFG1_ADC_SYNC_NORMAL);
}

/**
* funcao para ler as bandeiras do sensor ISL29125
*\image html StatusISL.png
*/
char StatusISL(){
    char r;                         //variavel onde vai ter flag ISL
    r = ReadISL(STATUS);            //ler do ISL a flag
    if(r == FLAG_CONV_DONE)         //se r == conversao feita
        return 0;                   //retorno 0
    if(r == FLAG_BROWNOUT)          //se r == overflow adc
        return 1;                   //retorno 1
    if(r == FLAG_CONV_G)            //se r == conversao verde
        return 2;                   //retorno 2
    if(r == FLAG_CONV_R)            //se r == conversao vermelha
        return 3;                   //retorno 3
    if(r == FLAG_CONV_B)            //se r == conversao azul
        return 4;                   //retorno 4
    if(r == FLAG_INT)               //se r == interrupcao
        return 5;                   //retorno 5
    else                            //adc parada
        return 6;                   //retorno 6
}

/**
* funcao para ler a cor vermelha do sensor ISL29125
*\image html ColorRED.png
*/
void ColorRED(){
    char a=0;       //variavel onde vai guardar byte vindo isl
    //configurar uma interrupcao na cor vermelha
    ConfigISL1(CFG1_MODE_R | CFG1_10KLUX | CFG1_16BIT | CFG1_ADC_SYNC_NORMAL);
    ConfigISL3(CFG3_R_INT | CFG3_INT_PRST8 | CFG3_RGB_CONV_TO_INT_DISABLE);
    while(StatusISL() != 6);        //esperar que esteja convertido
    StopADCISL();                   //Parar a adc do isl
    a = ReadISL(RED_L);             //ler byte menos significativo
    putcUSART(a);                   //Imprimir para USART
    a = ReadISL(RED_H);             //ler byte mais significativo
    putcUSART(a);                   //Imprimir para USART
}

/**
* funcao para ler a cor verde do sensor ISL29125
*\image html ColorGREEN.png
*/
void ColorGREEN(){
    char a= 0;      //variavel onde vai guardar byte vindo isl
    //configurar uma interrupcao na cor verde
    ConfigISL1(CFG1_MODE_G | CFG1_10KLUX | CFG1_16BIT | CFG1_ADC_SYNC_NORMAL);
    ConfigISL3(CFG3_G_INT | CFG3_INT_PRST8 | CFG3_RGB_CONV_TO_INT_DISABLE);
    while(StatusISL() != 6);        //esperar que esteja convertido
    StopADCISL();                   //Parar a adc do isl
    a = ReadISL(GREEN_L);           //ler byte menos significativo
    putcUSART(a);                   //Imprimir para USART
    a = ReadISL(GREEN_H);           //ler byte mais significativo
    putcUSART(a);                   //Imprimir para USART
}

/**
* funcao para ler a cor azul do sensor ISL29125
*\image html ColorBLUE.png
*/
void ColorBLUE(){
    char a=0;       //variavel onde vai guardar byte vindo isl
    //configurar uma interrupcao na cor azul
    ConfigISL1(CFG1_MODE_B | CFG1_10KLUX | CFG1_16BIT | CFG1_ADC_SYNC_NORMAL);
    ConfigISL3(CFG3_B_INT | CFG3_INT_PRST8 | CFG3_RGB_CONV_TO_INT_DISABLE);
    while(StatusISL() != 6);        //esperar que esteja convertido
    StopADCISL();                   //Parar a adc do isl
    a = ReadISL(BLUE_L);            //ler byte menos significativo
    putcUSART(a);                   //Imprimir para USART
    a = ReadISL(BLUE_H);            //ler byte mais significativo
    putcUSART(a);                   //Imprimir para USART
}