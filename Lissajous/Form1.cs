using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Lissajous
{
    public partial class Form1 : Form
    {

        private Graphics FirstItem, SecondItem, ThirdItem, FourthItem;
        private Pen myPen = new Pen(Color.Black, 1);
        private double oldy0 = 0, oldwy = 0, olddeltaf = 0, oldx0 = 0, oldwx = 0;

 

        private Thread myThread;
        public Form1()
        {
            InitializeComponent(); 
            FirstItem = pictureBox1.CreateGraphics();
            SecondItem = pictureBox2.CreateGraphics();
            ThirdItem = pictureBox3.CreateGraphics();
            // FourthItem = pictureBox4.CreateGraphics();
            myThread = new Thread(new ThreadStart(Count));
           // myThread.Start();
        }
        private void paint()
        {
            try
            {
                double y0 = Convert.ToDouble(textBox3.Text), wy = Convert.ToDouble(textBox2.Text), deltaf = Convert.ToDouble(textBox1.Text);
                double x0 = Convert.ToDouble(textBox4.Text), wx = Convert.ToDouble(textBox5.Text);
                double n1 = Convert.ToDouble(textBox6.Text), n2 = Convert.ToDouble(textBox7.Text);
                double n1wy = Convert.ToDouble(textBox9.Text), n2wy = Convert.ToDouble(textBox8.Text);
                double n1y0 = Convert.ToDouble(textBox11.Text), n2y0 = Convert.ToDouble(textBox10.Text);
                double n1x0 = Convert.ToDouble(textBox13.Text), n2x0 = Convert.ToDouble(textBox12.Text);
                double n1wx = Convert.ToDouble(textBox15.Text), n2wx = Convert.ToDouble(textBox14.Text);

                Random randobj = new Random();

                if (oldy0 != y0 || oldwy != wy || olddeltaf != deltaf)
                {
                    FirstItem.Clear(BackColor);
                    FirstItem.DrawLine(myPen, new Point(0, 95), new Point(380, 95));
                    FirstItem.DrawLine(myPen, new Point(190, 0), new Point(190, 190));

                    for (double i = 0; i < 20; i += 0.005)
                    {
                        FirstItem.DrawLine(myPen, 
                                           new PointF((float)(i * 19), (float)(y0 * Math.Cos(i * wy + deltaf) * 9.5 + 95)), 
                                           new PointF((float)((i + 0.007) * 19), (float)(y0 * Math.Cos((i + 0.007) * wy + deltaf) * 9.5 + 95)));
                    }


                }

                if (oldx0 != x0 || oldwx != wx)
                {
                    SecondItem.Clear(BackColor);
                    SecondItem.DrawLine(myPen, new Point(0, 95), new Point(380, 95));
                    SecondItem.DrawLine(myPen, new Point(190, 0), new Point(190, 190));

                    for (double i = 0; i < 20; i += 0.005)
                    {
                        SecondItem.DrawLine(myPen, 
                                            new PointF((float)(i * 19), (float)(x0 * Math.Cos(i * wx) * 9.5 + 95)), 
                                            new PointF((float)((i + 0.007) * 19), (float)(x0 * Math.Cos((i + 0.007) * wx) * 9.5 + 95)));
                    }

                }

                ThirdItem.Clear(BackColor);
                ThirdItem.DrawLine(myPen, new Point(0, 160), new Point(380, 160));
                ThirdItem.DrawLine(myPen, new Point(190, 0), new Point(190, 320));


                for (double i = 0; i < 7; i += 0.002)
                {   
                    ThirdItem.DrawLine(myPen, 
                                        new PointF((float)(x0 * ((double)randobj.Next(Convert.ToInt32(n1x0 * 1000), Convert.ToInt32(n2x0 * 1000)) / 100000) * 
                                                    Math.Cos(i * (wx * ((double)randobj.Next(Convert.ToInt32(n1wx * 1000), Convert.ToInt32(n2wx * 1000)) / 100000))) * 19 + 190), 
                                                   (float)(y0 * ((double)randobj.Next(Convert.ToInt32(n1y0 * 1000), Convert.ToInt32(n2y0 * 1000)) / 100000) *
                                                    Math.Cos(i * (wy * ((double)randobj.Next(Convert.ToInt32(n1wy * 1000), Convert.ToInt32(n2wy * 1000)) / 100000)) + deltaf * 
                                                    ((double)randobj.Next(Convert.ToInt32(n1 * 1000), Convert.ToInt32(n2 * 1000)) / 100000)) * 19 + 160)), 
                                        new PointF((float)(x0 * ((double)randobj.Next(Convert.ToInt32(n1x0 * 1000), Convert.ToInt32(n2x0 * 1000)) / 100000) * 
                                                    Math.Cos((i + 0.001) * (wx * ((double)randobj.Next(Convert.ToInt32(n1wx * 1000), Convert.ToInt32(n2wx * 1000)) / 100000))) * 19 + 190), 
                                                   (float)(y0 * ((double)randobj.Next(Convert.ToInt32(n1y0 * 1000), Convert.ToInt32(n2y0 * 1000)) / 100000)  * 
                                                    Math.Cos((i + 0.001) * (wy * ((double)randobj.Next(Convert.ToInt32(n1wy * 1000), Convert.ToInt32(n2wy * 1000)) / 100000)) + deltaf * 
                                                    ((double)randobj.Next(Convert.ToInt32(n1 * 1000), Convert.ToInt32(n2 * 1000)) / 100000)) * 19 + 160)));
                }


                oldy0 = y0; oldwy = wy; olddeltaf = deltaf;
                oldx0 = x0; oldwx = wx;
            }
            catch (Exception)
            {
                MessageBox.Show(
                "Поля должны содержать числа",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button2,
                MessageBoxOptions.DefaultDesktopOnly);
                //Environment.Exit(-1);
            }
        }
        public void Count()
        {
            /*for (double i = 0; ; i += 0.002)
            {
                FourthItem.DrawLine(myPen,
                    new PointF((float)(10 * Math.Cos(i * 3.14 * 19 + 190)), (float)(10 * Math.Cos(i * 3.14 * 19 + 160))),
                    new PointF((float)(10 * Math.Cos((i + 0.001) * 3.14 * 19 + 190)), (float)(10 * Math.Cos((i + 0.001) * 3.14 * 19 + 160))));
            }*/
            double i = 0;
            bool flag = true;
            while (true)
            {
                FourthItem.DrawLine(myPen,
                    new PointF((float)(5 * Math.Cos(i * 9) * 24.1 + 241), (float)(5 * Math.Cos(i * 8) * 24.1 + 241)),
                    new PointF((float)(5 * Math.Cos((i + 0.0001) * 9) * 24.1 + 241), (float)(5 * Math.Cos((i + 0.0001) * 8) * 24.1 + 241)));
                if (i >= 8)
                {
                    //FourthItem.Clear(BackColor);
                    myPen = new Pen(Color.Red, 2);
                    flag = false;
                }
                if (i <= 0)
                {
                    //FourthItem.Clear(BackColor);
                    myPen = new Pen(Color.Black, 1);
                    flag = true;
                }
                if (flag == true)
                {
                    i += 0.0002;
                }
                else
                {
                    i -= 0.0002;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.paint();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
