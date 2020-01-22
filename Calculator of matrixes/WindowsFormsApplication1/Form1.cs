using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
         Point WindowsPosition;

        public Form1()
        {
            InitializeComponent();
        }

        void Movement(MouseEventArgs e) // Перевірка ,яка кнопка мишки натиснута 
        {
            if (e.Button == MouseButtons.Left)
                WindowsPosition = MousePosition;
        }

        void Movement_2(MouseEventArgs e) // Переміщення об`єктів
        {

            if (e.Button == MouseButtons.Left)
            {
                int PositionX = MousePosition.X - WindowsPosition.X;
                int PositionY = MousePosition.Y - WindowsPosition.Y;
                Point Loc = new Point(Location.X + PositionX, Location.Y + PositionY);
                Location = Loc;
                WindowsPosition = MousePosition;
            }

            
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Movement(e);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Movement(e);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Movement_2(e);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Movement_2(e);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            Movement(e);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            Movement_2(e);
        }

        private void pictureBox6_MouseDown(object sender, MouseEventArgs e)
        {
            Movement(e);
        }

        private void pictureBox6_MouseMove(object sender, MouseEventArgs e)
        {
            Movement_2(e);
        }

        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            Movement(e);
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            Movement_2(e);
        }

        private void pictureBox6_Click(object sender, EventArgs e) // Кнопка згорання програми
        {
            if (base.WindowState == FormWindowState.Normal)
            {
                base.WindowState = FormWindowState.Minimized;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e) // Кнопка виходу
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e) // Додавання
        {

            string[] lines1 = textBox1.Text.Split('\n');
            string[] lines2 = textBox2.Text.Split('\n');
            Matrix t = new Matrix();
            try
            {
                for (int i = 0; i < lines1.Length; i++)
                {
                    string[] Temp = lines1[i].Split(' ');

                    for (int j = 0; j < Temp.Length; j++)
                    {
                        if (i == 0 && j==0)
                        { t = new Matrix(lines1.Length, Temp.Length); }
                        t[i, j] = float.Parse(Temp[j]);  // Заповнення першої матриці (textBox1)

                    }
                 }

                Matrix t1 = new Matrix();

                for (int i = 0; i < lines2.Length; i++)
                {
                    string[] Temp = lines2[i].Split(' ');

                    for (int j = 0; j < Temp.Length; j++)
                    {
                        if (i == 0 && j == 0)
                        { t1 = new Matrix(lines2.Length, Temp.Length); }
                        t1[i, j] = float.Parse(Temp[j]); // Заповнення другої матриці (textBox2)
                    
                    }
                }
                label2.Text = (t1+t).ToString(); // Виклик функції(додавання) класу
            }
            catch (Exception)
            { }
          
        }
        
          private void button6_Click(object sender, EventArgs e) // Очичення матриць
        {
            textBox1.Text = "";
            textBox2.Text = "";
            label2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] lines1 = textBox1.Text.Split('\n');
            string[] lines2 = textBox2.Text.Split('\n');
            string[] lines3 = label2.Text.Split('\n');
            Matrix M = new Matrix();
            try
            {
                for (int i = 0; i < lines1.Length; i++)
                {
                    string[] Temp = lines1[i].Split(' ');

                    for (int j = 0; j < Temp.Length; j++)
                    {
                        if (i == 0 && j == 0)
                        { M = new Matrix(lines1.Length, Temp.Length); }
                        M[i, j] = float.Parse(Temp[j]);

                    }
                }

                Matrix M_1 = new Matrix();
               
                for (int i = 0; i < lines2.Length; i++)
                {
                    string[] Temp = lines2[i].Split(' ');

                    for (int j = 0; j < Temp.Length; j++)
                    {
                        if (i == 0 && j == 0)
                        { M_1 = new Matrix(lines2.Length, Temp.Length); }
                        M_1[i, j] = float.Parse(Temp[j]); 

                    }
                }

                Matrix M_2 = new Matrix();
                for (int i = 0; i < lines1.Length; i++)
                {
                    string[] Temp = lines3[i].Split(' ');
                    for (int j = 0; j < lines2.Length; j++)
                    {

                        for (int q = 0; q < lines1.Length && q < lines2.Length; q++)
                        {
                           M_2[i, j] += M[i, q] * M_1[q, j];
                           
                        }

                        label2.Text = (M * M_1).ToString(); // Виклик функції(множення) класу
                        
                    }
                  }

            }
            catch (Exception)
            { }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] lines1 = textBox1.Text.Split('\n');
            string[] lines2 = textBox2.Text.Split('\n');
            Matrix N = new Matrix();
            try
            {
                for (int i = 0; i < lines1.Length; i++)
                {
                    string[] Temp = lines1[i].Split(' ');

                    for (int j = 0; j < Temp.Length; j++)
                    {
                        if (i == 0 && j == 0)
                        { N = new Matrix(lines1.Length, Temp.Length); }
                        N[i, j] = float.Parse(Temp[j]); 

                    }

                }

                Matrix N_1 = new Matrix();
             
                for (int i = 0; i < lines2.Length; i++)
                {
                    string[] Temp = lines2[i].Split(' ');

                    for (int j = 0; j < Temp.Length; j++)
                    {
                        if (i == 0 && j == 0)
                        { N_1 = new Matrix(lines2.Length, Temp.Length); }
                        N_1[i, j] = float.Parse(Temp[j]); 

                    }
                }
                label2.Text = (N_1 - N).ToString(); // Виклик функції(віднімання) класу
            }
            catch (Exception)
            { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] lines1 = textBox1.Text.Split('\n');
            Matrix N = new Matrix();
            try
            {
                for (int i = 0; i < lines1.Length; i++)
                {
                    string[] Temp = lines1[i].Split(' ');

                    for (int j = 0; j < Temp.Length; j++)
                    {
                        if (i == 0 && j == 0)
                        { N = new Matrix(lines1.Length, Temp.Length); }
                        N[i, j] = float.Parse(Temp[j]); 

                    }

                }

                label2.Text = N.Opr().ToString(); // Виклик функції(визначник) класу
            }
            catch
            { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] lines1 = textBox1.Text.Split('\n');
            string[] lines2 = textBox2.Text.Split('\n');
         
            Matrix M = new Matrix();
            try
            {
                for (int i = 0; i < lines1.Length; i++)
                {
                    string[] Temp = lines1[i].Split(' ');

                    for (int j = 0; j < Temp.Length; j++)
                    {
                        if (i == 0 && j == 0)
                        { M = new Matrix(lines1.Length, Temp.Length); }
                        M[i, j] = float.Parse(Temp[j]); 
                     }
                  }

                Matrix M_1 = new Matrix();

                for (int i = 0; i < lines2.Length; i++)
                {
                    string[] Temp = lines2[i].Split(' ');

                    for (int j = 0; j < Temp.Length; j++)
                    {
                        if (i == 0 && j == 0)
                        { M_1 = new Matrix(lines2.Length, Temp.Length); }
                        M_1[i, j] = float.Parse(Temp[j]); 

                    }
                }

                label2.Text = (M ^ M_1).ToString(); // Виклик функції(піднесення до степеню) класу
            }
            catch (Exception)
            { }

          }

      }
}
