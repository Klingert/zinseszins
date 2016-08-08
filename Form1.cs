using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZinsesZinsZinsen
{
    public partial class Form1 : Form
    {
        private double MonthlySaving { get; set; }
        private int RunTime { get; set; }
        private double InterestRate { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox4.Text = "";
                textBox5.Text = "";
                double tempDbl = 0;
                int tempInt = 0;

                if (!Double.TryParse(textBox1.Text, out tempDbl))
                {
                    MessageBox.Show("Please enter a number for \"" + label1.Text + "\"." );
                    return;
                }
                else
                {
                    MonthlySaving = tempDbl;
                }

                if (!Int32.TryParse(textBox2.Text, out tempInt))
                {
                    MessageBox.Show("Please enter a number for \"" + label2.Text + "\".");
                    return;
                }
                else
                {
                    RunTime = tempInt;
                }

                if (!Double.TryParse(textBox3.Text, out tempDbl))
                {
                    MessageBox.Show("Please enter a number for \"" + label6.Text + "\".");
                    return;
                }
                else
                {
                    InterestRate = tempDbl;
                }

                double result = Calculate();
                textBox4.Text = string.Format("{0:n}", result);
                result = 12 * MonthlySaving * RunTime;
                textBox5.Text = string.Format("{0:n}", result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private double Calculate()
        {
            double result = 0;

            try
            {
                for (int i = 0; i < RunTime; i++)
                {
                    result += 12 * MonthlySaving;
                    result = result * (100 + InterestRate) / 100;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return result;
        }
    }
}
