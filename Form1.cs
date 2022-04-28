using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaduGadu_v1._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Thread watek1 = new Thread(() => wczytanielogow(listBox1));
            watek1.Start();            
        }
        
        public static string UserID = Form2.nick;
        public static string path = Form2.path;
        public static int x = 0;
        public static int wartosctestowa = 0;


        static void wczytanielogow(ListBox listBox1)
        {
            while (2 > 1)
            {                
                string[] logs = new string[File.ReadAllLines(sciezka.path).Length];              
                logs = File.ReadAllLines(sciezka.path);
                listBox1.Invoke(new Action(delegate ()
                {
                    listBox1.Items.Clear();

                }));
                foreach (string log in logs)
                {
                    listBox1.Invoke(new Action(delegate ()
                    {
                        listBox1.Items.Add(log);                       
                    }));                                       
                }

                Thread.Sleep(1000);  
                if (x == 1)
                {
                    break;
                }
                if (wartosctestowa == 0)
                {
                    File.AppendAllText(path, DateTime.Now + " ");
                    File.AppendAllText(path, "Użytkownik " + UserID + " zalogował(a) się. " + "\r\n");
                    wartosctestowa++;
                }
            }
        }
                   
        private void button1_Click(object sender, EventArgs e)
        {
            var Form2 = new Form2();
            Form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string wiadomosc = textBox1.Text;
            if (wiadomosc == "" || String.IsNullOrWhiteSpace(wiadomosc))
            {

            }
            else
            {
                File.AppendAllText(path, DateTime.Now + " ");
                File.AppendAllText(path, UserID + ": " + wiadomosc + "\r\n");
            }
            textBox1.Clear();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            File.AppendAllText(path, DateTime.Now + " ");
            File.AppendAllText(path, "Użytkownik " + UserID + " wylogował(a) się. " + "\r\n");
            x++;            
            Application.Exit();
        }

    }

    
}
