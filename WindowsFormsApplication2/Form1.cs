using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace WindowsFormsApplication2
{

    public partial class Form1 : Form
    {
        SerialPort port;

        string[] ports = SerialPort.GetPortNames();
        byte[] myarr = new byte[36];

        public Form1()
        {
            InitializeComponent();
            richTextBox1.Clear();
            comboBox1.Items.AddRange(ports);
            richTextBox1.Text = myarr;

            //36 байтный  массив, заполняем нулями
            for (int i = 0; i < myarr.Length; i++)
                myarr[i] = 0;




        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Отправка(активна если ком порт доступен)
            for (int i = 0; i < myarr.Length; i += 4)
                myarr[i] = 0xFF;
            port.Write();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            port = new SerialPort();

            // читаем номер
            string n = comboBox1.SelectedItem.ToString();
            try
            {
                // настройки порта
                port.PortName = n;
                port.BaudRate = 115200;
                port.DataBits = 8;
                port.Parity = System.IO.Ports.Parity.None;
                port.StopBits = System.IO.Ports.StopBits.One;
                port.ReadTimeout = 1000;
                port.WriteTimeout = 1000;
                port.Open();
            }
            catch   (Exception ex) 
            {   
                richTextBox1.Text = "Не могу открыть порт: " + ex.ToString();
                return;
            }

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //Ввод отправляемых данных

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //сетевой адрес компьютера на CAN шине

        }
    }
}
