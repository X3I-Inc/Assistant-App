using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Emit;


namespace Auto_Assistant
{
    public partial class Form1 : Form
    {
        public List<string> Tasks = new List<string>();
        public List<DateTime> TimeStart = new List<DateTime>();
        List<DateTime> TimeEnd = new List<DateTime>();
        public int currentTaskIndex = 0;
        DateTime NowDate = DateTime.Now;
        System.TimeSpan notify = new System.TimeSpan(0, 0, 30, 0);

        public int milliseconds = 2000;
        public int MinutesLeft = 0;
        public Thread thread1;
        public Thread thread2;
        public Form1()
        {
            InitializeComponent();
            
            thread1 = new Thread(new ThreadStart(MyFunction));
            //thread2 = new Thread(new ThreadStart(update_label));
            thread1.Start();








        }
        public void MyFunction()
        {
            
           /* TimeStart.Add(new DateTime(2024, 10, 2, 13, 10, 0));
            TimeEnd.Add(new DateTime(2024, 10, 2, 13, 25, 0));
            Tasks.Add("Some Task");*/
            /*TimeStart.Add(new DateTime(2024, 9, 30, 20, 35, 0));
            TimeEnd.Add(new DateTime(2024, 9, 30, 20, 45, 0));*/
            while(Tasks.Count() <= 0)
            {
                if(Tasks.Count() > 0)
                {
                    break;
                }
            }
            do
            {


                NowDate = DateTime.Now;

                //Console.WriteLine(TimeStart[currentTaskIndex].Subtract(NowDate));
                if (TimeStart[currentTaskIndex].Subtract(NowDate) <= notify)
                {

                    MinutesLeft = TimeStart[currentTaskIndex].Subtract(NowDate).Minutes;
                    label1.ResetText();
                    label1.Text = ($"you got work in {MinutesLeft} minutes" + NowDate);
                    label1.Refresh();


                }
                if (TimeStart[currentTaskIndex] < NowDate)
                {
                    //Console.WriteLine("more");
                    while (TimeEnd[currentTaskIndex] < NowDate)
                    {
                        NowDate = DateTime.Now;
                    }
                    currentTaskIndex++;
                }
                Thread.Sleep(milliseconds);

            } while (currentTaskIndex < Tasks.Count());

            
            // Some work here
        }
        /*  public void update_label()
          {
              label1.Text = ($"you got work in {MinutesLeft} minutes" + NowDate);
              label1.Refresh();
          }*/
        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimeStart.Add(dateTimePicker1.Value);
            TimeEnd.Add(dateTimePicker2.Value);
            Tasks.Add(textBox1.Text);
            
            listBox1.Items.Add(textBox1.Text);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
