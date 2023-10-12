using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadSerialDataUsingThreading
{
    public partial class Mainfrm : Form
    {
        public Thread ReadSerialDataThread;
        public Thread SendEnterSerialDataThread;
        public Thread SendCommandSerialDataThread;

        public string readserialvalue;
        public String Platform = null;
        public string[] AN = { "\n", "usb start 2;bin2emmc 2 1 fusion_writer_AD1.bin 0x0;bin2emmc 2 1 fusion_writer_AD3.bin 0x1A0F00;bin2emmc 2 1 fusion_writer_AD4.bin 0x81A0E00; bin2emmc 2 1 fusion_writer_AD5.bin 0x101A0F00;bin2emmc 2 1 fusion_writer_AD6.bin 0x181A0F00" };
        public string[] AY = { "\n", "usb start 1;bin2emmc 1 1 fusion_writer_AY1.bin 0x0;bin2emmc 1 1 fusion_writer_AY3.bin 0x12FFE0;bin2emmc 1 1 fusion_writer_AY5.bin 0x181748;bin2emmc 1 1 fusion_writer_AY6.bin 0x8181749;bin2emmc 1 1 fusion_writer_AY7.bin 0x10181749;bin2emmc 1 1 fusion_writer_AY8.bin 0x18181749;bin2emmc 1 1 fusion_writer_AY9.bin 0x20181749;bin2emmc 1 1 fusion_writer_AY10.bin 0x28181749;bin2emmc 1 1 fusion_writer_AY11.bin 0x30181749;bin2emmc 1 1 fusion_writer_AY12.bin 0x38181749; reset" };
        public string[] Other = new string[2];
        public int i = 0;
        public string path = "muratlogfile.txt";
        public string LogPath = "";
        public string applicationPath = "";

        public string plotform { get; set; }

        public Mainfrm()
        {
            InitializeComponent();
        }

        private void Mainfrm_Load(object sender, EventArgs e)
        {
            //Load all UI
            this.Text = @"Seri Port Program";
            LoadConfigurationSetting();
            gbConnection.Enabled = false;
            Btnsave.Enabled = false;
            Btndisconnect.Enabled = false;
            Btnsend.Enabled = false;
            Btnconnect.Enabled = false;
            Btnedit.Enabled = false;
            buttonPlatformSelect.Enabled = true;
            button1.Enabled = false;

            applicationPath = Path.GetFullPath(System.AppDomain.CurrentDomain.BaseDirectory);
            LogPath = Path.Combine(applicationPath, path);
            Console.WriteLine(LogPath);

            if (File.Exists(LogPath))
            {
                File.Delete(LogPath);
            }


        }

        private void LoadConfigurationSetting()
        {
            //Load Configuration
            txtportname.Text = ConfigurationManager.AppSettings["comname"];
            txtbaudrate.Text = ConfigurationManager.AppSettings["combaudrate"];
            txtparity.Text = ConfigurationManager.AppSettings["comparity"];
            txtdatabits.Text = ConfigurationManager.AppSettings["comdatabits"];
            txtstopbits.Text = ConfigurationManager.AppSettings["comstopbits"];
        }

        private void Btnedit_Click(object sender, EventArgs e)
        {
            gbConnection.Enabled = true;
            txtportname.Enabled = true;
            txtbaudrate.Enabled = false;
            txtparity.Enabled = false;
            txtdatabits.Enabled = false;
            txtstopbits.Enabled = false;

            Btnsave.Enabled = true;
            Btndisconnect.Enabled = false;
            Btnsend.Enabled = false;
            Btnconnect.Enabled = false;
            Btnedit.Enabled = false;
            buttonPlatformSelect.Enabled = true;
            button1.Enabled = false;

        }

        private void txtportname_DropDown(object sender, EventArgs e)
        {
            txtportname.Items.Clear();
            string[] comports = SerialPort.GetPortNames();
            foreach (var comport in comports)
            {
                txtportname.Items.Add(comport);
            }
        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings.Remove("comname");
                config.AppSettings.Settings.Remove("combaudrate");
                config.AppSettings.Settings.Remove("comparity");
                config.AppSettings.Settings.Remove("comdatabits");
                config.AppSettings.Settings.Remove("comstopbits");

                config.AppSettings.Settings.Add("comname", txtportname.Text);
                config.AppSettings.Settings.Add("combaudrate", txtbaudrate.Text);
                config.AppSettings.Settings.Add("comparity", txtparity.Text);
                config.AppSettings.Settings.Add("comdatabits", txtdatabits.Text);
                config.AppSettings.Settings.Add("comstopbits", txtstopbits.Text);

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

                if (String.IsNullOrEmpty(Platform))
                {
                    MessageBox.Show($"Lütfen Edit Butonuna basıp bir proje seçip Select Butonuna basın \n Hata : ", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Btnconnect.Enabled = false;
                    Btnsave.Enabled = true;
                    buttonPlatformSelect.Enabled = true;

                    Btndisconnect.Enabled = false;
                    Btnsend.Enabled = false;
                    Btnedit.Enabled = false;
                    button1.Enabled = false;


                }
                else
                {
                    gbConnection.Enabled = false;

                    Btnedit.Enabled = true;
                    Btnconnect.Enabled = true;
                    Btnsave.Enabled = false;
                    buttonPlatformSelect.Enabled = false;

                    Btndisconnect.Enabled = false;
                    Btnsend.Enabled = false;
                    button1.Enabled = false;

                }





            }
            catch (Exception exc)
            {
                MessageBox.Show(@"Saving Error. " + exc.Message);
            }
        }
        private void SendEnterSerialData()
        {
            try
            {

                SendEnterSerialDataThread = new Thread(Btnsend_ClickAA);
                SendEnterSerialDataThread.Start();
                Console.WriteLine("SendSerialPort Thread Enter Start");
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Read Serial thread. " + e.Message);
            }
        }

        private void Btnconnect_Click(object sender, EventArgs e)
        {
            serialPortIn.PortName = txtportname.Text;
            serialPortIn.BaudRate = int.Parse(txtbaudrate.Text);
            serialPortIn.Parity = (Parity)Enum.Parse(typeof(Parity), txtparity.Text);
            serialPortIn.DataBits = int.Parse(txtdatabits.Text);
            serialPortIn.StopBits = (StopBits)Enum.Parse(typeof(StopBits), txtstopbits.Text);
            try
            {
                serialPortIn.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Seri Port bağlantısı yapılamadı \n Hata : {ex.Message}", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (serialPortIn.IsOpen)
            {
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 200;
                progressBar1.Value = 40;

                ReadSerialData();
                Btnconnect.Enabled = false;
                Btnedit.Enabled = false;
                Btndisconnect.Enabled = true;
                Btnsend.Enabled = true;

                Btnsave.Enabled = false;
                buttonPlatformSelect.Enabled = false;
                button1.Enabled = false;

                if (Platform == "AN" || Platform == "AY" || Platform == "UbootCommand")
                {
                    SendEnterSerialData();



                } else if (Platform == "ConsoleCommand")
                {

                }


            }
        }

        private void SendCommandSerialData()
        {
            try
            {

                SendCommandSerialDataThread = new Thread(Btnsend_ClickA);
                SendCommandSerialDataThread.Start();
                Console.WriteLine("SendSerial Command Thread Start");

            }
            catch (Exception e)
            {
                MessageBox.Show(@"Read Serial thread. " + e.Message);
            }
        }
        public String PlatformInfo(int i)
        {

            switch (Platform)
            {
                case "AN" when i == 0:
                    return AN[0];
                case "AN" when i == 1:
                    return AN[1];

                case "AY" when i == 0:
                    return AY[0];
                case "AY" when i == 1:
                    return AY[1];
                case "Other" when i == 0:
                    return Other[0];
                case "Other" when i == 1:
                    return Other[1];

                default:
                    break;
            }

            Console.WriteLine("Select Proje Name = {0} ", plotform);


            return plotform;
        }

        public void Btnsend_ClickAA()
        {

            string command = PlatformInfo(i);
            Console.WriteLine("Send Command =  ", command);

            string searchAN = "UBOOT";
            string searchAY = "U-BOOT";
            
            bool ret = true;
            while (ret)
            {


                if (serialPortIn.IsOpen)
                {
                    try
                    {
                        readserialvalue = serialPortIn.ReadExisting();

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(@"Read Serial thread. " + e.Message);
                        ret = false;


                    }
                    Console.WriteLine("Thread is active");


                    serialPortIn.WriteLine(command);

                    Thread.Sleep(100);
                    if (readserialvalue.Contains(searchAN) || readserialvalue.Contains(searchAY))
                    {
                        Console.WriteLine("Found search string");
                        i = i + 1;
                        Console.WriteLine("Command array index = {0} ", i);
                        ret = false;
                        SendCommandSerialData();
                        SendEnterSerialDataThread.Join();




                    }
                }
                else
                {
                    MessageBox.Show($"Port Kapandı \n Hata : ", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ret = false;

                }

            }
            Console.WriteLine("EnterSerial port thread finish ");





        }


        public void Btnsend_ClickA()
        {

            
            string command = PlatformInfo(i);
            Console.WriteLine("Send this command= {0} ", command);

            string searchAN = "UBOOT";
            string searchAY = "U-BOOT";
            if (serialPortIn.IsOpen)
            {
                bool ret = true;
                serialPortIn.WriteLine(command);

                while (ret)
                {
                    try
                    {
                        readserialvalue = serialPortIn.ReadExisting();

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(@"Read Serial thread. " + e.Message);
                        ret = false;


                    }
                    Console.WriteLine("SerialCommand Thread active");

                    
                    

                    Thread.Sleep(100);
                    if (readserialvalue.Contains(searchAN) || readserialvalue.Contains(searchAY))
                    {
                        Console.WriteLine("Serial Port Search Found");

                        Console.WriteLine("Serial command thread array index = {0} ", i);


                        serialPortIn.WriteLine("reset");

                        //SendEnterSerialData();
                        SendCommandSerialDataThread.Join();





                    }
                }

            }
            Console.WriteLine("Serial Command thread is finish");





        }







        private void ReadSerialData()
        {
            try
            {
                ReadSerialDataThread = new Thread(ReadSerial);
                ReadSerialDataThread.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Read Serial thread. " + e.Message);
            }
        }
    
         

        private void ReadSerial()
        {
            while (serialPortIn.IsOpen)
            {
                readserialvalue = serialPortIn.ReadExisting();
                ShowSerialData(readserialvalue);
                Console.WriteLine(readserialvalue);


                File.AppendAllText(LogPath, readserialvalue + Environment.NewLine);


                Thread.Sleep(100);
            }
        }


        public delegate void ShowSerialDatadelegate(string r);

        private void ShowSerialData(string s)
        {
            if (txtreaddata.InvokeRequired)
            {
                ShowSerialDatadelegate SSDD = ShowSerialData;
                Invoke(SSDD, s);
            }
            else
            {
                txtreaddata.AppendText(Environment.NewLine + s);
                txtreaddata.ScrollToCaret();
            }
        }

        private void Btndisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPortIn.IsOpen)
                {
                    serialPortIn.Close();
                    Btnconnect.Enabled = true;
                    Btnedit.Enabled = true;
                    Btndisconnect.Enabled = false;
                    Btnsend.Enabled = false;
                    buttonPlatformSelect.Enabled = false;

                    gbConnection.Enabled = false;
                    Btnsave.Enabled = false;
                    button1.Enabled = false;



                    if (SendCommandSerialDataThread.IsAlive)
                    {
                        SendCommandSerialDataThread.Join();

                    }
                    if (SendEnterSerialDataThread.IsAlive)
                    {
                        SendEnterSerialDataThread.Join();
                    }

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Disconnect error. " + exception.Message);
            }
        }

        private void Btnsend_Click(object sender, EventArgs e)
        {
            if (serialPortIn.IsOpen)
            {
                serialPortIn.WriteLine(txtwritedata.Text);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonPlatformSelect_Click(object sender, EventArgs e)
        {
            Platform = comboBoxPlatform.Text;
            buttonPlatformSelect.Enabled = false;
            button1.Enabled = true;
            Btnedit.Enabled = true;

            gbConnection.Enabled = false;
            Btnsave.Enabled = false;
            Btndisconnect.Enabled = false;
            Btnsend.Enabled = false;
            Btnconnect.Enabled = false;
            button1.Enabled = false;

            Console.WriteLine(Platform);
            if (Platform.Equals("MbootCommand"))
            {
                string otherpath = "mbootcommand.txt";
                string OtherPath = Path.Combine(applicationPath, otherpath);
                Console.WriteLine(OtherPath);

                if (File.Exists(OtherPath))
                {
                    Other[0] = "\n";
                    Other[1] = File.ReadLines(OtherPath).First();

                    //Other[1] = File.ReadLines(OtherPath);
                    Console.WriteLine(Other[1]);
                    button1.Enabled = false;
                    Btnconnect.Enabled = true;

                    gbConnection.Enabled = false;
                    Btnsave.Enabled = false;
                    Btndisconnect.Enabled = false;
                    Btnsend.Enabled = false;
                    Btnedit.Enabled = true;
                    buttonPlatformSelect.Enabled = false;





                }
                else
                {
                    MessageBox.Show($"Lütfen mbootcommand.txt dosyasını Program ile aynı dizine koyun \n Hata : ", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }else if (Platform == "AN" || Platform == "AY" )
            {
                button1.Enabled = true;
                Btnconnect.Enabled = false;

                gbConnection.Enabled = false;
                Btnsave.Enabled = false;
                Btndisconnect.Enabled = false;
                Btnsend.Enabled = false;
                Btnedit.Enabled = true;
                buttonPlatformSelect.Enabled = false;
            }else if (Platform.Equals("ConsoleCommand"))
            {
                button1.Enabled = false;
                Btnconnect.Enabled = true;

                gbConnection.Enabled = false;
                Btnsave.Enabled = false;
                Btndisconnect.Enabled = false;
                Btnsend.Enabled = false;
                Btnedit.Enabled = true;
                buttonPlatformSelect.Enabled = false;

            }
            else if (Platform.Equals("Log"))
            {
                button1.Enabled = false;
                Btnconnect.Enabled = true;

                gbConnection.Enabled = false;
                Btnsave.Enabled = false;
                Btndisconnect.Enabled = false;
                Btnsend.Enabled = false;
                Btnedit.Enabled = true;
                buttonPlatformSelect.Enabled = false;
            }






        }

        public int usbcontrol()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            int usbcount = 0;
            string usbname = null;
            foreach (DriveInfo d in allDrives)
            {
                if (d.DriveType == DriveType.Removable)
                {
                    usbcount = usbcount + 1;
                    Console.WriteLine("usb adı usb adı {0} ", d);
                    usbname = d.ToString();

                }
            }
            if (usbcount != 1)
            {
                MessageBox.Show($"Lütfen sadece TV'ye takacağınız USB'yi takın!  \n Hata : ", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonPlatformSelect.Enabled = true;

                return -1;
            }

            string ANoffline = "fusion_writer_AN1.bin";
            string AYoffline = "fusion_writer_AY1.bin";
            if (!String.IsNullOrEmpty(usbname))
            {
                string ANusbpath = Path.Combine(usbname, ANoffline);
                string AYusbpath = Path.Combine(usbname, AYoffline);
                List<string> list = new List<string>();
                foreach (string file in Directory.GetFiles(usbname))
                {
                    string fileName = Path.GetFileName(file);
                    list.Add(fileName);


                }
                list = list.Distinct().ToList();
                Console.WriteLine("list uzunlugu {0}", list.Count);
                //count how many items are in list
                string stringToCheck = null;
                int found = 0;
                int offlinefilecount = 0;



                if (Platform.Equals("AN") && File.Exists(ANusbpath) && !File.Exists(AYusbpath))
                {
                    stringToCheck = "fusion_writer_AN";
                    offlinefilecount = 5;
                    Console.WriteLine("AN File exists... ");
                }
                
                else if (Platform.Equals("AY") && File.Exists(AYusbpath) &&  !File.Exists(ANusbpath))
                {

                    Console.WriteLine("AY File exists... ");
                    stringToCheck = "fusion_writer_AY";
                    offlinefilecount = 10;
                }
                else
                {

                    Console.WriteLine("İlgili Offline image usb de yok yada Birden Fazla Proje için var !");
                    MessageBox.Show($"İlgili Offline Image USB'de yok ya da birden Fazla proje için var!\n Hata : ", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    buttonPlatformSelect.Enabled = true;
                    return -1;
                }

                try
                {
                    List<string> result = list.FindAll(ele => ele.StartsWith(stringToCheck, StringComparison.Ordinal));
                    Console.WriteLine(result.Count);
                    found = result.Count;

                }
                catch (Exception exception)
                {
                    MessageBox.Show("Disconnect error. " + exception.Message);
                    buttonPlatformSelect.Enabled = true;

                    return -1;
                }



                if (found == offlinefilecount)
                {
                    Console.WriteLine("USB içinde dosyalar dogru!");

                }
                else if (found > offlinefilecount)
                {
                    Console.WriteLine("USB yi kontrol edin fazla dosya var !");
                    MessageBox.Show($"USB'yi kontrol edin. Fazla dosya var!\n Hata : ", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    buttonPlatformSelect.Enabled = true;

                    return -1;

                }
                else if (offlinefilecount > found)
                {
                    Console.WriteLine("USB yi kontrol edin az dosya var !");
                    MessageBox.Show($"USB'yi kontrol edin. Az dosya var!\n Hata : ", "Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    buttonPlatformSelect.Enabled = true;

                    return -1;

                }


            }
            return 0;

        }








        private void button1_Click(object sender, EventArgs e)
        {
            int returnvalue = usbcontrol();
            if (returnvalue == 0)
            {
                MessageBox.Show($"USB içindeki dosyalar DÜZGÜN. Başlayabilirsin. ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gbConnection.Enabled = false;
                Btnsave.Enabled = false;
                Btndisconnect.Enabled = false;
                Btnsend.Enabled = false;
                buttonPlatformSelect.Enabled = false;
                button1.Enabled = false;

                Btnconnect.Enabled = false;
                Btnedit.Enabled = false;


                if (Btnsave.Enabled != true && !String.IsNullOrEmpty(Platform))
                {
                    Btnconnect.Enabled = true;
                    Btnedit.Enabled = true;


                }





            }



        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
    

