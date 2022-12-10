using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        Class_geomet geomet;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = -20;
            numericUpDown1.Maximum = 30;

            numericUpDown3.Minimum = 5;
            numericUpDown3.Maximum = 30;

            numericUpDown2.Minimum = 1;
            numericUpDown2.Maximum = 25;

            numericUpDown4.Minimum = 1;
            numericUpDown4.Maximum = 30;

            button1.Enabled = false;
            button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            geomet = new Class_geomet(Convert.ToInt32(numericUpDown3.Value));
            geomet.SequenceFirstElem = Convert.ToInt32(numericUpDown1.Value);
            geomet.SequenceStep = Convert.ToInt32(numericUpDown2.Value);
            geomet.array_value();
            label5.Text = geomet.ToString();
            button1.Enabled = true;
            button3.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k = Convert.ToInt32(numericUpDown4.Value);
            MessageBox.Show(geomet.k_elem(k).ToString(), k + "-ий елемент послідовності");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int size = geomet.return_elements().Length;
            if (numericUpDown3.Value <= size)
            {
                MessageBox.Show(geomet.Sum(Convert.ToInt32(numericUpDown3.Value)).ToString(), "Сума");
            }
            else
            {
                MessageBox.Show("Завеликий діапазон, максимальне значення: " + size, "Увага!!!");
            }
        }
    }
}
