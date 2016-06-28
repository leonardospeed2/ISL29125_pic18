using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace colorpick
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timerCOM.Enabled = true;
        }

        /**
        *funcao atualizar as coms, verifica se existe portas com no pc e lista numa combobox
        */
        private void atualizarcom()
        {
            int i;
            bool quantDiferente; //flag para sinalizar que a quantidade de portas mudou

            i = 0;
            quantDiferente = false;

            //se a quantidade de portas mudou
            if (cbcom.Items.Count == SerialPort.GetPortNames().Length)
            {
                foreach (string s in SerialPort.GetPortNames())
                {
                    if (cbcom.Items[i++].Equals(s) == false)
                    {
                        quantDiferente = true;
                    }
                }
            }
            else
            {
                quantDiferente = true;
            }

            //Se não foi detectado diferença
            if (quantDiferente == false)
            {
                return;                     //retorna
            }

            //limpa comboBox
            cbcom.Items.Clear();

            //adiciona todas as COM diponíveis na lista
            foreach (string s in SerialPort.GetPortNames())
            {
                cbcom.Items.Add(s);
            }
            //seleciona a primeira posição da lista
            cbcom.SelectedIndex = 0;
        }


        /**
        * funcao timer com, passado 1 segundo chama a funcao atualizarcom
        */
        private void timerCOM_Tick(object sender, EventArgs e)
        {
            //chamar a funcao atualizarcom
            atualizarcom();
        }

        /**
        *funcao do botao ligar, liga a porta com escolhida da combobox
        */
        private void btligar_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)        //se a porta com estiver aberta
            {
                try
                {
                    serialPort1.PortName = cbcom.Items[cbcom.SelectedIndex].ToString(); //buscar com selecionada
                    serialPort1.Open();     //abrir uma ligacao serial

                }
                catch
                {
                    return;

                }
                if (serialPort1.IsOpen)             //se existir ligacao
                {
                    btligar.Text = "Desligar";      //botao diz desligar
                    cbcom.Enabled = false;          //nao podes selecionar coms

                }
            }
            else
            {

                try
                {
                    serialPort1.Close();           //se nao existir ligacao 
                    cbcom.Enabled = true;          //podes selecionar uma com 
                    btligar.Text = "Ligar";        //botao diz ligar 
                }
                catch
                {
                    return;
                }

            }
        }

        /**
        *funcao map, converte valor 16bits em 8bits
        */
        private long map(long x)
        {
            return x*255/65535;     //converter 16bits para 8 bits
        }

        /**
        *funcao converter hex, array bytes converte em string hexadecimal
        */
        private string converterhex(Byte[] buff)
        {
            string hex = "";
            foreach (char c in buff)
            {
                if (c <= 0x0F)
                    hex += "0" + ((int)c).ToString("x") + " ";
                else
                    hex += ((int)c).ToString("x") + " ";
            }
            return hex;
        }

        /**
        *funcao botao red, envia para porta com que quer cor vermelha e recebe 2 bytes, converte e mostra
        */
        private void btred_Click(object sender, EventArgs e)
        {
            Byte[] buff = {0,0};        //variavel para ler valores recebidos
            long cor;                   //variavel onde vai ter valor final
            if (serialPort1.IsOpen == true)          //porta está abert
            {
                try
                {
                    serialPort1.Write("R");             //envia o texto presente no textbox Enviar
                    serialPort1.Read(buff, 0, 2);       //ler dois Bytes 
                }
                catch
                {
                    return;
                }
                
                lbrx2.Text = converterhex(buff);    //converter para hexadecimal
                cor = buff[1];                      //por na variavel cor
                cor += (buff[0] << 8);              //por na variavel cor
                cor = map(cor);                     //fazer conversao para 8bits
                lbred.Text = cor.ToString();        //escrever a cor
                lbgreen.Text = "0";                 //escrever a cor
                lbblue.Text = "0";                  //escrever a cor
                viewcolor.BackColor = Color.FromArgb(Int16.Parse(lbred.Text), 0, 0);        //ver cor
            }
                
        }

        /**
        *funcao botao green, envia para porta com que quer cor verde e recebe 2 bytes, converte e mostra
        */
        private void btgreen_Click(object sender, EventArgs e)
        {
            Byte[] buff = { 0, 0 };        //variavel para ler valores recebidos
            long cor;                      //variavel onde vai ter valor final
            if (serialPort1.IsOpen == true)          //porta está abert
            {
                try
                {
                    serialPort1.Write("G");             //envia o texto presente no textbox Enviar
                    serialPort1.Read(buff, 0, 2);       //ler dois Bytes 
                }
                catch
                {
                    return;
                }

                
                lbrx2.Text = converterhex(buff);    //converter para hexadecimal
                cor = buff[1];                      //por na variavel cor
                cor += (buff[0] << 8);              //por na variavel cor
                cor = map(cor);                     //fazer conversao para 8bits
                lbgreen.Text = cor.ToString();      //escrever a cor
                lbred.Text = "0";                   //escrever a cor
                lbblue.Text = "0";                  //escrever a cor
                viewcolor.BackColor = Color.FromArgb(0,Int16.Parse(lbgreen.Text),0);        //ver cor
            }
        }

        /**
        *funcao botao blue, envia para porta com que quer cor azul e recebe 2 bytes, converte e mostra
        */
        private void btblue_Click(object sender, EventArgs e)
        {
            Byte[] buff = { 0, 0 };        //variavel para ler valores recebidos
            long cor;                      //variavel onde vai ter valor final
            if (serialPort1.IsOpen == true)          //porta está abert
            {
                try
                {
                    serialPort1.Write("B");             //envia o texto presente no textbox Enviar
                    serialPort1.Read(buff, 0, 2);       //ler dois Bytes 
                }
                catch
                {
                    return;
                }
                lbrx2.Text = converterhex(buff);    //converter para hexadecimal
                cor = buff[1];                      //por na variavel cor
                cor += (buff[0] << 8);              //por na variavel cor
                cor = map(cor);                     //fazer conversao para 8bits
                lbblue.Text = cor.ToString();       //escrever a cor
                lbgreen.Text = "0";                 //escrever a cor
                lbred.Text = "0";                   //escrever a cor
                viewcolor.BackColor = Color.FromArgb(0,0,Int16.Parse(lbblue.Text));        //ver cor
            }
        }

        /**
        *funcao botao rgb, envia para porta com que quer RGB e recebe 6 bytes, converte e mostra
        */
        private void btrgb_Click(object sender, EventArgs e)
        {
            Byte[] buff = { 0, 0,0,0,0,0 };          //variavel para ler valores recebidos
            long cor,cor2,cor3;                      //variavel onde vai ter valor final
            if (serialPort1.IsOpen == true)          //porta está abert
            {
                try
                {
                    serialPort1.Write("A");              //envia o texto presente no textbox Enviar
                    serialPort1.Read(buff, 0, 6);        //ler seis Bytes 
                }
                catch
                {
                    return;
                }
                lbrx2.Text = converterhex(buff);     //converter para hexadecimal
                cor = buff[1];                       //por na variavel cor
                cor += (buff[0] << 8);               //por na variavel cor
                cor = map(cor);                      //fazer conversao para 8bits
                cor2 = buff[3];                      //por na variavel cor
                cor2 += (buff[2] << 8);              //por na variavel cor
                cor2 = map(cor2);                    //fazer conversao para 8bits
                cor3 = buff[5];                      //por na variavel cor
                cor3 += (buff[4] << 8);              //por na variavel cor
                cor3 = map(cor3);                    //fazer conversao para 8bits
                lbred.Text = cor.ToString();         //escrever a cor
                lbgreen.Text = cor2.ToString();      //escrever a cor
                lbblue.Text = cor3.ToString();       //escrever a cor
                viewcolor.BackColor = Color.FromArgb(Int16.Parse(lbred.Text),Int16.Parse(lbgreen.Text),Int16.Parse(lbblue.Text));   //ver cor
            }
        }

        /**
        *funcao fromclose, quando fecha a aplicacao ele fecha a porta com aberta
        */
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen == true)  // se porta aberta
                serialPort1.Close();         //fecha a porta
        }

    }
}
