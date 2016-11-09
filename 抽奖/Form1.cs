using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace 抽奖
{
    public partial class Form1 : Form
    {
        bool rolling;
        string fname;
        Random rd = new Random();
        string[] NameStr=new string[5000];
        int N;
        StreamReader fin;
        public Form1()
        {
            rolling = false;
            InitializeComponent();
        }
        private void Roll(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (rolling)
            {
                //textBox1.Text = NameStr[(i++) % N];
                textBox1.Text = NameStr[rd.Next(0, N - 1)];
                timer1.Enabled = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog f1 = new OpenFileDialog();
            f1.InitialDirectory = ".\\";
            f1.Filter = "文本文件|*.txt";
            //f1.RestoreDirectory = true;
            f1.FilterIndex = 1;
            if (f1.ShowDialog() == DialogResult.OK)
            {
                fname = f1.FileName;
                fin = new StreamReader(@fname);
                N = 0;
                while((NameStr[N] = fin.ReadLine()) != null)
                    N++;
                //for (int i = 0; i < N; ++i) Console.WriteLine(NameStr[i]);
                button2.Enabled = true;
                label2.Refresh();
                label2.Text = fname;
                label2.Refresh();
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            rolling = false;
            this.button2.Enabled = false;
            timer1.Interval = 100;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (rolling == false)
            {
                this.button2.Enabled = false;
                button2.Text = "停止摇号";
                timer1.Tick += new EventHandler(Roll);
                timer1.Enabled = true;
                rolling = true;
                this.button2.Enabled = true;
            }
            else
            {
                this.button2.Enabled = false;
                timer1.Enabled = false;
                rolling = false;
                button2.Text = "开始摇号";
                this.button2.Enabled = true;
            }
        }
        
    }
}
