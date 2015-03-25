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
        SerialPort ComPort = new SerialPort();
        string RxString;
        int i = 1;
        char[] buff = new char[1024];

        internal delegate void SerialPinChangedEventHandlerDelegate(object sender, SerialPinChangedEventArgs e);
        //private SerialPinChangedEventHandler SerialPinChangedEventHandler1;
        delegate void SetTextCallback(string text);




        public Form1()
        {
            InitializeComponent();
            //StartSetting.Enabled = true;
            //SerialPinChangedEventHandler1 = new SerialPinChangedEventHandler(PinChanged);
            //Comm Ports
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


            //Hand Shake
            //FlowControl.Items.Add("None");
            //FlowControl.Items.Add("Hardware");
            //FlowControl.Items.Add("XOnXOff");
            //HandShake.Items.Add("RequestToSend");
            //HandShake.Items.Add("RequestToSendXOnXOff");
            //get the first item print it in the text 
            //FlowControl.Text = FlowControl.Items[0].ToString();


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

            

            //StreamWriter MyStreamWriter = new StreamWriter(@"C:\Users\Rui Shen\Downloads\M.Eng. project\SimpleSerial\Data.txt", true);
            //MyStreamWriter.Write("LoL\r\n");
            //MyStreamWriter.Flush();
            //MyStreamWriter.Close();

            serialPort1.PortName = CommPort.Text;
            serialPort1.BaudRate = int.Parse(BaudRate.Text);

            
                if (Parity.SelectedIndex == 0)
                {
                    serialPort1.Parity = System.IO.Ports.Parity.None;
                }
                if (Parity.SelectedIndex == 1)
                {
                    serialPort1.Parity = System.IO.Ports.Parity.Even;
                }
                if (Parity.SelectedIndex == 2)
                {
                    serialPort1.Parity = System.IO.Ports.Parity.Odd;
                }
                if (Parity.SelectedIndex == 3)
                {
                    serialPort1.Parity = System.IO.Ports.Parity.Mark;
                }
                if (Parity.SelectedIndex == 4)
                {
                    serialPort1.Parity = System.IO.Ports.Parity.Space;
                }



                serialPort1.DataBits = int.Parse(DataBits.Text);



                if (StopBits.SelectedIndex == 0)
                {
                    serialPort1.StopBits = System.IO.Ports.StopBits.None;
                }
                if (StopBits.SelectedIndex == 1)
                {
                    serialPort1.StopBits = System.IO.Ports.StopBits.One;
                }
                if (StopBits.SelectedIndex == 2)
                {
                    serialPort1.StopBits = System.IO.Ports.StopBits.OnePointFive;
                }
                if (StopBits.SelectedIndex == 3)
                {
                    serialPort1.StopBits = System.IO.Ports.StopBits.Two;
                }




                if (HandShake.SelectedIndex == 0)
                {
                    serialPort1.Handshake = Handshake.None;
                }
                
                if (HandShake.SelectedIndex == 1)
                {

                    serialPort1.Handshake = Handshake.RequestToSend;
                    serialPort1.DtrEnable = true;

                }

                if (HandShake.SelectedIndex == 2)
                {

                    serialPort1.Handshake = Handshake.RequestToSendXOnXOff;
                    serialPort1.DtrEnable = true;

                }

                if (HandShake.SelectedIndex == 3)
                {

                    serialPort1.Handshake = Handshake.XOnXOff;

                }


                serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);

                serialPort1.Open();

                if (serialPort1.IsOpen)
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
          
            if (serialPort1.IsOpen)
            {

                buff[i] = '\n';
                buff[i + 1] = '\r';
                serialPort1.Write(buff, 0, buff.Length);
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
                serialPort1.DiscardInBuffer();
                serialPort1.DiscardOutBuffer();
                textBox2.AppendText("\r\n");

                serialPort1.Close();
                buttonStart.Enabled = true;
                buttonSend.Enabled = false;
                buttonStop.Enabled = false;
                buttonSaveData.Enabled = true;
                //StartSetting.Enabled = true;
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = true;
            

        }

        

        private void buttonSaveData_Click(object sender, EventArgs e)
        {

            saveFileDialog1.ShowDialog();
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;

       

            /*StreamWriter SaveTextbox = new StreamWriter("C:\\Users\\Rui\\Desktop\\M.Eng. project\\SimpleSerial\\MeasurementResults.txt");

            //Use write method to write the text
            SaveTextbox.Write("Commands:\r\n"+textBox1.Text);
            SaveTextbox.Write("\r\nResults:\r\n"+textBox2.Text);

            //always close your stream
            SaveTextbox.Close();*/

                //File.WriteAllText("C:\\Users\\Rui\\Desktop\\M.Eng. project\\SimpleSerial", textBox1.Text); 
                
                //StreamWriter MyStreamWriter = new StreamWriter(@"C:\Users\Rui Shen\Downloads\M.Eng. project\SimpleSerial\Data.txt", true);
                //MyStreamWriter.Write(buff, 0, buff.Length);
                //MyStreamWriter.Write("   ");
                //MyStreamWriter.Write(RxString);
                //MyStreamWriter.Write(System.Environment.NewLine);
                //MyStreamWriter.Write("\r\n");
                //MyStreamWriter.Flush();
                //MyStreamWriter.Close();

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
            if (serialPort1.IsOpen) serialPort1.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // int i = 1;
            // If the port is closed, don't try to send a character.
            if (!serialPort1.IsOpen) return;

            // char[] buff = new char[i];

            // if (e.KeyChar != (char)Keys.Return)
                // buff[0] = e.KeyChar;
           
            // do
            // {
                // buff[i-1] = e.KeyChar;
                // i++;
            // } while (e.KeyChar != (char)Keys.Return);

            
                buff[i-1] = e.KeyChar;
                i++;

            // serialPort1.Write(buff, 0, buff.Length);

            // serialPort1.Write(RxString);

                //serialPort1.DiscardOutBuffer();
                

            // If the port is Open, declare a char[] array with one element.
            // char[] buff = new char[1];

            // Load element 0 with the key character.
            // buff[0] = e.KeyChar;

            // Send the one character buffer.
            // serialPort1.Write(buff, 0, 1);

            // Set the KeyPress event as handled so the character won't
            // display locally. If you want it to display, omit the next line.
            //e.Handled = true;

           
        }

        private void DisplayText(object sender, EventArgs e)
        {
            //textBox2.Text = "\r\n";
            //textBox2.Text = "Reply: ";
            textBox2.AppendText(RxString);
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            RxString = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(DisplayText));

            //string result = serialPort1.ReadExisting();
            //Console.WriteLine("Data Received: ");
            //Console.WriteLine(RxString);
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|Word Document (*.doc)|*.doc|All files (*.*)|*.*" ; 
            saveFileDialog1.FilterIndex = 3; 
            //saveFileDialog1.RestoreDirectory = false;
            //saveFileDialog1.AddExtension = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
               
                using (Stream myStream = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(myStream))
                sw.Write("Commands:\r\n"+textBox1.Text+"\r\nResults:\r\n"+textBox2.Text); 
                   
            }
         }

   

        /*private void StartSetting_Click(object sender, EventArgs e)
        {
            //Comm Ports
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

            
            //Hand Shake
            //FlowControl.Items.Add("None");
            //FlowControl.Items.Add("Hardware");
            //FlowControl.Items.Add("XOnXOff");
            //HandShake.Items.Add("RequestToSend");
            //HandShake.Items.Add("RequestToSendXOnXOff");
            //get the first item print it in the text 
            //FlowControl.Text = FlowControl.Items[0].ToString();

            
            //Flow Control
            FlowControl.Items.Add("None");
            FlowControl.Items.Add("Hardware");
            FlowControl.Items.Add("Xon/Xoff");

            //get the first item print it in the text 
            FlowControl.Text = FlowControl.Items[0].ToString();


        }*/


        /*private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Stream myStream ; 
            SaveFileDialog saveFileDialog1 = new SaveFileDialog(); 

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|Word Document (*.doc)|*.doc|All files (*.*)|*.*" ; 
            saveFileDialog1.FilterIndex = 3; 
            //saveFileDialog1.RestoreDirectory = true; 

            if(saveFileDialog1.ShowDialog() == DialogResult.OK) 
            { 
                  if((myStream = saveFileDialog1.OpenFile()) != null) 
                  { 
                        StreamWriter sw =new StreamWriter(myStream); 
                         
                        sw.Write("Commands:\r\n"+textBox1.Text+"\r\nResults:\r\n"+textBox2.Text); 

                        myStream.Close(); 
                  } 
            }
        }*/


        }

        
        
    
}