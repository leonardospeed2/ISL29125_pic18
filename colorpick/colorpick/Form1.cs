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

        private void timerCOM_Tick(object sender, EventArgs e)
        {
            atualizarcom();
        }

        private void btligar_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
            {
                try
                {
                    serialPort1.PortName = cbcom.Items[cbcom.SelectedIndex].ToString();
                    serialPort1.Open();

                }
                catch
                {
                    return;

                }
                if (serialPort1.IsOpen)
                {
                    btligar.Text = "Desligar";
                    cbcom.Enabled = false;

                }
            }
            else
            {

                try
                {
                    serialPort1.Close();
                    cbcom.Enabled = true;
                    btligar.Text = "Ligar";
                }
                catch
                {
                    return;
                }

            }
        }

        private long map(long x)
        {
            return x*255/65535;
        }

        private void btred_Click(object sender, EventArgs e)
        {
            Byte[] buff = {0,0};
            long cor;
            string hex = "";
            if (serialPort1.IsOpen == true)          //porta está abert
            {
                serialPort1.Write("R");  //envia o texto presente no textbox Enviar
                serialPort1.Read(buff,0,2);
                foreach (char c in buff)
                    hex += ((int)c).ToString("x") + " ";
                lbrx2.Text = hex;
                cor = buff[0];
                cor += (buff[1] << 8);
                cor = map(cor);
                lbred.Text = cor.ToString();
                lbgreen.Text = "0";
                lbblue.Text = "0";
                viewcolor.BackColor = Color.FromArgb(Int16.Parse(lbred.Text), 0, 0);
            }
                
        }

        private void btgreen_Click(object sender, EventArgs e)
        {
            Byte[] buff = { 0,0 };
            long cor;
            string hex = "";
            if (serialPort1.IsOpen == true)          //porta está abert
            {
                serialPort1.Write("G");  //envia o texto presente no textbox Enviar
                serialPort1.Read(buff, 0, 2);
                foreach (char c in buff)
                    hex += ((int)c).ToString("x") + " ";
                lbrx2.Text = hex;
                cor = buff[0];
                cor += (buff[1] << 8);
                cor = map(cor);
                lbgreen.Text = cor.ToString();
                lbred.Text = "0";
                lbblue.Text = "0";
                viewcolor.BackColor = Color.FromArgb(0,Int16.Parse(lbgreen.Text), 0);
            }
        }

        private void btblue_Click(object sender, EventArgs e)
        {
            Byte[] buff = {0, 0 };
            long cor;
            string hex = "";
            if (serialPort1.IsOpen == true)          //porta está abert
            {
                serialPort1.Write("B");  //envia o texto presente no textbox Enviar
                serialPort1.Read(buff, 0, 2);
                foreach (char c in buff)
                    hex += ((int)c).ToString("x") + " ";
                lbrx2.Text = hex;
                cor = buff[0];
                cor += (buff[1] << 8);
                cor = map(cor);
                lbblue.Text = cor.ToString();
                lbgreen.Text = "0";
                lbred.Text = "0";
                viewcolor.BackColor = Color.FromArgb(0,0,Int16.Parse(lbblue.Text));
            }

        }

        private void btrgb_Click(object sender, EventArgs e)
        {
            Byte[] buff = { 0, 0,0,0,0,0 };
            long cor,cor2,cor3;
            string hex = "";
            if (serialPort1.IsOpen == true)          //porta está abert
            {
                serialPort1.Write("A");  //envia o texto presente no textbox Enviar
                serialPort1.Read(buff, 0, 6);
                foreach (char c in buff)
                    hex += ((int)c).ToString("x") + " ";
                lbrx2.Text = hex;
                cor = buff[1];
                cor += (buff[0] << 8);
                cor = map(cor);
                cor2 = buff[3];
                cor2 += (buff[2] << 8);
                cor2 = map(cor2);
                cor3 = buff[5];
                cor3 += (buff[4] << 8);
                cor3 = map(cor3);
                lbred.Text = cor.ToString();
                lbgreen.Text = cor2.ToString();
                lbblue.Text = cor3.ToString();
                viewcolor.BackColor = Color.FromArgb(Int16.Parse(lbred.Text),Int16.Parse(lbgreen.Text),Int16.Parse(lbblue.Text));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen == true)  // se porta aberta
                serialPort1.Close();         //fecha a porta
        }

    }
}
