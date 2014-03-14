using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WPFClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Így lehet a WCF Service-t meghívni a legegyszerűbben :
            ServiceReference1.Service1Client c = new ServiceReference1.Service1Client();
            textBox1.Text = c.GetData(10).ToString();

            //Vagy lehet használni az app.config-ban megadott interface-i is:
            ServiceReference1.IService1 c2 = new ServiceReference1.Service1Client();
            textBox1.Text = c2.GetData(10).ToString();
        }
    }
}
