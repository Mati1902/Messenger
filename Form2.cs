using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Permissions;

namespace GaduGadu_v1._1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            deaktywacja(label3, label4, label5);
            sprawdz(label3, label4, label5);
            czas(label3, label4, label5);
            //Thread time = new Thread(czas);
            
            //sprawdzserwer1(label3);
        }

        public static string nick;
        public static string path;
        public uzytkownik user;
        public sciezka link;

        static void deaktywacja(Label label3, Label label4, Label label5)
        {
            label3.Text = "Nieaktywny";
            label4.Text = "Nieaktywny";
            label5.Text = "Nieaktywny";
        }

        //Pierwszy serwer
        static void sprawdzserwer1(Label label3)
        {
           
        }
        //Drugi serwer
        static void sprawdzserwer2(Label label4)
        {
            
        }
        //trzeci serwer
        static void sprawdzserwer3(Label label5)
        {
            
        }
        //czasomierz
        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        static void czas(Label label3, Label label4, Label label5)
        {
            Thread serv1 = new Thread(() => sprawdzserwer1(label3));
            Thread serv2 = new Thread(() => sprawdzserwer2(label4));
            Thread serv3 = new Thread(() => sprawdzserwer3(label5));
            
            //Thread.Sleep(10000);
            //serv1.Abort();
            //serv2.Abort();
            //serv3.Abort();
        }



        static void sprawdz(Label label3, Label label4, Label label5)
        {
            try
            {

                string[] x = File.ReadAllLines(@"\\D-LINK\Chmura\LOG.txt");
                label3.Text = "Aktywny";
            }
            catch
            {
                //label3.Text = "Nieaktywny";
            }


            try
            {
                string[] x = File.ReadAllLines(@"\\MATI-DESKTOP\Linux\LOG.txt");
                //string[] x = File.ReadAllLines(@"C:\errorr.txt");
                label4.Text = "Aktywny";
            }
            catch
            {
                //label4.Text = "Nieaktywny";
            }

            try
            {
                string[] x = File.ReadAllLines(@"\\Q6600\Users\Public\GaduGadu\LOG.txt");
                label5.Text = "Aktywny";
            }
            catch
            {
                //label5.Text = "Nieaktywny";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox2.Checked == false || String.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Nie wybrano serwera lub nie podano nazwy użytkownika!");
            }
            else
            {
                nick = textBox1.Text;
                uzytkownik.UserID = nick;
                sciezka.path = path;
                this.Close();
            }
        }

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (label3.Text == "Nieaktywny" && checkBox1.Checked == true)
            {
                MessageBox.Show("Ten serwer jest NIEAKTYWNY!");
                checkBox1.Checked = false;
            }
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                path = @"\\D-LINK\Chmura\LOG.txt";
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (label4.Text == "Nieaktywny" && checkBox2.Checked == true)
            {
                MessageBox.Show("Ten serwer jest NIEAKTYWNY!");
                checkBox2.Checked = false;
            }
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                path = @"\\MATI-DESKTOP\Linux\LOG.txt";
            }
            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (label5.Text == "Nieaktywny" && checkBox3.Checked == true)
            {
                checkBox3.Checked = false;
                MessageBox.Show("Ten serwer jest NIEAKTYWNY!");
            }
            if (checkBox3.Checked == true)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                path = @"\\Q6600\Users\Public\GaduGadu\LOG.txt";
            }
            
        }
    }

    public class sciezka
    {
        public static string path;
    }

    public class uzytkownik
    {
        public static string UserID;
    }
}
