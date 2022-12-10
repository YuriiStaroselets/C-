namespace winform_lab_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toogleElements(false);
        }

        private void toogleElements(bool isShow)
        {
            labelResultHeader.Visible = isShow;
            labelResult.Visible = isShow;
            labelResult2.Visible = isShow;
            textResult.Visible = isShow;
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            if (comboBoxInterval.SelectedItem != null)
            {
                textResult.Text = "";
                string stringInterval = comboBoxInterval.SelectedItem.ToString().Replace("[", "");
                stringInterval = stringInterval.Replace("]", "");

                int[] interval = { -1, -1 };
                interval[0] = Convert.ToInt32(stringInterval.Split(",")[0]);
                interval[1] = Convert.ToInt32(stringInterval.Split(",")[1]);
                int amount = Convert.ToInt32(numericAmount.Value);

                int minimum, maximum;
                minimum = 30;
                maximum = -30;
                textResult.Text += minimum + " ";
                for (int i = 0; i < amount - 1; i++)
                {
                    int number = new Random().Next(interval[0], interval[1]);
                    textResult.Text += number + " ";
                    if(number % 2 != 0)
                    {
                        if (number < minimum) minimum = number;
                        if (number > maximum) maximum = number;
                    }
                }
                labelResult.Text = "(" + maximum + ", " + minimum + ")" ;
                toogleElements(true);
            }
            else
            {
                MessageBox.Show("Виберіть інтервал", "Помилка!");
            }


        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            toogleElements(false);
            numericAmount.Value = 5;
            comboBoxInterval.SelectedItem = null;
            comboBoxInterval.Text = "виберіть інтервал";
            textResult.Text = "";
        }
    }
}