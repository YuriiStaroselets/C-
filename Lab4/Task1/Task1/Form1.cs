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
        string text = string.Empty;
        Class_regex regexObj = new Class_regex();
        int coutOfSelectedWords = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            isButtonsEnabled(false);
            button5.Enabled = false;
            button6.Enabled = false;
            button4.Enabled = false;
        }

        public string[] getSplitedWords(string text)
        {
            string[] symbols = { " ", ",", "!", "?", ":", "\"","\'", "\r\n", "\r", "\n"};
            string[] newStr = text.Split(symbols, StringSplitOptions.RemoveEmptyEntries);
            return newStr;
        }

        public string[] getEndWith()
        {
            return new string[0]; 
        }

        public void isButtonsEnabled(bool enabled)
        {
            button1.Enabled = enabled;
            button2.Enabled = enabled;
            button3.Enabled = enabled;
            button7.Enabled = enabled;
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            text = Clipboard.GetText();
            string[] lines = getSplitedWords(text);
            foreach (string item in lines)
            {
                listBox1.Items.Add(item.Trim());
            }
            if(listBox1.Items.Count > 0)
            {
                isButtonsEnabled(true);
                button4.Enabled = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            button5.Enabled = false;
            button6.Enabled = false;
            button4.Enabled = false;
            isButtonsEnabled(false);
            textBox1.Text = String.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string searchingWord = textBox1.Text.Trim();
            selectSearchingWords(listBox1, searchingWord, @"(\w*)");
            button5.Enabled = true;
            button6.Enabled = true;
        }

        public void selectSearchingWords(ListBox listbox, string searchingWord, string extension="")
        {
            coutOfSelectedWords = 0;
            for (int i = 0; i < listbox.Items.Count; i++)
            {
                if (regexObj.isRegexMatches(searchingWord, listbox.Items[i].ToString()))
                {
                    listbox.SelectedIndex = i;
                    coutOfSelectedWords++;
                }
            }
        }

        public string reverseWord(string word)
        {
            return String.Join(string.Empty, word.ToCharArray().Reverse());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
            button5.Enabled = false;
            button6.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Кількість знайдених слів: " + coutOfSelectedWords);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
            string searchingWord = textBox1.Text.Trim();
            selectSearchingWords(listBox1, reverseWord(searchingWord));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
            if (radioButton1.Checked)
            {
                selectSearchingWords(listBox1, @"\w*(а+|е+)\w*");
                MessageBox.Show("Слів з буквами (а, е): " + coutOfSelectedWords);
            }
            else if(radioButton2.Checked)
            {
                selectSearchingWords(listBox1, @"\w*(л+|ц+|т+)\w*");
                MessageBox.Show("Слів з буквами (л, ц, т): " + coutOfSelectedWords);
            }
            else
            {
                MessageBox.Show("Виберіть варіант!!!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] words = regexObj.getRegexMatches(text, @"\w*(не)\b");
            foreach(string word in words)
            {
                listBox2.Items.Add(word);
            }
            if(listBox2.Items.Count <= 0)
            {
                MessageBox.Show("Слів з закінченням (-не) НЕ знайдено !!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string myRegexWords = string.Empty;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                string item = listBox1.Items[i].ToString();
                if (regexObj.isMyRegexMatches(item))
                {
                    myRegexWords += item + "\n";
                }
            }
            if(myRegexWords == string.Empty)
            {
                MessageBox.Show("НЕМА співпадінь !!!");
            }
            else
            {
                MessageBox.Show(myRegexWords);
            }
        }
    }
}
