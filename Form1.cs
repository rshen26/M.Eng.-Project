using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;


namespace SimpleSerial
{

    public partial class Form1 : Form
    {
        // Add this variable 
        string RxString;
        int i = 1;
        char[] buff = new char[1024];


        public Form1()
        {
            InitializeComponent();
  
            CommPort.Items.Add("COM1");
            CommPort.Items.Add("COM2");
            CommPort.Items.Add("COM3");
            CommPort.Items.Add("COM4");
            CommPort.Items.Add("COM5");
            CommPort.Items.Add("COM6");
            CommPort.Items.Add("COM7");
            CommPort.Items.Add("COM8");
            CommPort.Items.Add("COM9");
            CommPort.Items.Add("COM10");
            CommPort.Items.Add("COM11");
            CommPort.Items.Add("COM12");
            CommPort.Items.Add("COM13");
            CommPort.Items.Add("COM14");
            CommPort.Items.Add("COM15");
            CommPort.Items.Add("COM16");
            CommPort.Items.Add("COM17");
            CommPort.Items.Add("COM18");
            CommPort.Items.Add("COM19");
            CommPort.Items.Add("COM20");
            CommPort.Items.Add("COM21");
            CommPort.Items.Add("COM22");
            CommPort.Items.Add("COM23");
            CommPort.Items.Add("COM24");


            //get first item print in text
            CommPort.Text = CommPort.Items[0].ToString();

            //Baud Rate
            BaudRate.Items.Add(110);
            BaudRate.Items.Add(300);
            BaudRate.Items.Add(600);
            BaudRate.Items.Add(1200);
            BaudRate.Items.Add(2400);
            BaudRate.Items.Add(4800);
            BaudRate.Items.Add(9600);
            BaudRate.Items.Add(19200);
            BaudRate.Items.Add(38400);
            BaudRate.Items.Add(57600);
            BaudRate.Items.Add(115200);
            //BaudRate.Items.ToString();

            //get first item print in text
            BaudRate.Text = BaudRate.Items[0].ToString();
            //Data Bits
            DataBits.Items.Add(7);
            DataBits.Items.Add(8);
            //get the first item print it in the text 
            DataBits.Text = DataBits.Items[0].ToString();

            //Stop Bits
            StopBits.Items.Add(0);
            StopBits.Items.Add(1);
            StopBits.Items.Add(1.5);
            StopBits.Items.Add(2);

            //get the first item print in the text
            StopBits.Text = StopBits.Items[0].ToString();

            //Parity 
            Parity.Items.Add("None");
            Parity.Items.Add("Odd");
            Parity.Items.Add("Even");
            Parity.Items.Add("Mark");
            Parity.Items.Add("Space");

            //get the first item print in the text

            Parity.Text = Parity.Items[0].ToString();


            //Flow Control
            HandShake.Items.Add("None");
            HandShake.Items.Add("RequestToSend");
            HandShake.Items.Add("RequestToSendXOnXOff");
            HandShake.Items.Add("XOnXOff");

            //get the first item print it in the text 
            HandShake.Text = HandShake.Items[0].ToString();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
  
            SerialPort.PortName = CommPort.Text;
            SerialPort.BaudRate = int.Parse(BaudRate.Text);

            
                if (Parity.SelectedIndex == 0)
                {
                    SerialPort.Parity = System.IO.Ports.Parity.None;
                }
                if (Parity.SelectedIndex == 1)
                {
                    SerialPort.Parity = System.IO.Ports.Parity.Even;
                }
                if (Parity.SelectedIndex == 2)
                {
                    SerialPort.Parity = System.IO.Ports.Parity.Odd;
                }
                if (Parity.SelectedIndex == 3)
                {
                    SerialPort.Parity = System.IO.Ports.Parity.Mark;
                }
                if (Parity.SelectedIndex == 4)
                {
                    SerialPort.Parity = System.IO.Ports.Parity.Space;
                }



                SerialPort.DataBits = int.Parse(DataBits.Text);



                if (StopBits.SelectedIndex == 0)
                {
                    SerialPort.StopBits = System.IO.Ports.StopBits.None;
                }
                if (StopBits.SelectedIndex == 1)
                {
                    SerialPort.StopBits = System.IO.Ports.StopBits.One;
                }
                if (StopBits.SelectedIndex == 2)
                {
                    SerialPort.StopBits = System.IO.Ports.StopBits.OnePointFive;
                }
                if (StopBits.SelectedIndex == 3)
                {
                    SerialPort.StopBits = System.IO.Ports.StopBits.Two;
                }




                if (HandShake.SelectedIndex == 0)
                {
                    SerialPort.Handshake = Handshake.None;
                }
                
                if (HandShake.SelectedIndex == 1)
                {

                    SerialPort.Handshake = Handshake.RequestToSend;
                    SerialPort.DtrEnable = true;

                }

                if (HandShake.SelectedIndex == 2)
                {

                    SerialPort.Handshake = Handshake.RequestToSendXOnXOff;
                    SerialPort.DtrEnable = true;

                }

                if (HandShake.SelectedIndex == 3)
                {

                    SerialPort.Handshake = Handshake.XOnXOff;

                }


                //serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);

                SerialPort.Open();

                if (SerialPort.IsOpen)
                {


                buttonStart.Enabled = false;
                buttonSend.Enabled = true;
                buttonStop.Enabled = true;
                buttonSaveData.Enabled = false;
                //StartSetting.Enabled = false;
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = true;

                }

          

        }


        private void buttonSend_Click(object sender, EventArgs e)
        {

            if (SerialPort.IsOpen)
            {

                buff[i] = '\n';
                buff[i + 1] = '\r';
                SerialPort.Write(buff, 0, buff.Length);
                //serialPort1.DiscardInBuffer();

                buttonStart.Enabled = false;
                buttonSend.Enabled = false;
                buttonStop.Enabled = true;
                buttonSaveData.Enabled = false;
                //StartSetting.Enabled = false;
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = false;
                //textBox1.WriteLine("Data Received: ");
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            
           
                //char[] buff = new char[1024];
                //buff.Initialize();
                Array.Clear(buff, 0, buff.Length);
                SerialPort.DiscardInBuffer();
                SerialPort.DiscardOutBuffer();
                textBox2.AppendText("\r\n");

                SerialPort.Close();
                buttonStart.Enabled = true;
                buttonSend.Enabled = false;
                buttonStop.Enabled = false;
                buttonSaveData.Enabled = true;
                //StartSetting.Enabled = true;
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
            

        }

        

        private void buttonSaveData_Click(object sender, EventArgs e)
        {

            saveFileDialog1.ShowDialog();
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;

            buttonStart.Enabled = true;
            buttonSend.Enabled = false;
            buttonStop.Enabled = false;
            buttonSaveData.Enabled = false;
            //StartSetting.Enabled = false;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
 
            
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SerialPort.IsOpen) SerialPort.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If the port is closed, don't try to send a character.
            if (!SerialPort.IsOpen) return;

                buff[i-1] = e.KeyChar;
                i++;

        }

        private void DisplayText(object sender, EventArgs e)
        {
            textBox2.AppendText(RxString);
        }

        
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            RxString = SerialPort.ReadExisting();
            this.Invoke(new EventHandler(DisplayText));

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|Word Document (*.doc)|*.doc|All files (*.*)|*.*" ; 
            saveFileDialog1.FilterIndex = 3; 

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
               
                using (Stream myStream = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(myStream))
                sw.Write("Commands:\r\n"+textBox1.Text+"\r\nResults:\r\n"+textBox2.Text); 
                   
            }
         }


   
        }
 
    
}