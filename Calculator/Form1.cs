using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Calc C;
        int k;

        public Form1()
        {
            InitializeComponent();

            C = new Calc();
            textBox1.Text = "0";
        }

        public void CorrectNumber()
        {
            // если есть знак "бесконечность" - не дает писать цифры после него
            if (textBox1.Text.IndexOf("∞") != -1)
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);

            // ситуация: слева ноль, а после него НЕ запятая, тогда ноль можно удалить
            if (textBox1.Text[0] == '0' && (textBox1.Text.IndexOf(",") != 1))
                textBox1.Text = textBox1.Text.Remove(0, 1);

            // аналогично пердыдущему, только для отрицательного числа
            if (textBox1.Text[0] == '-')
                if (textBox1.Text[1] == '0' && (textBox1.Text.IndexOf(",") != 2))
                    textBox1.Text = textBox1.Text.Remove(1, 1);
        }

        private bool CanPress()
        {
            if (!butMult.Enabled)
                return false;

            if (!butDiv.Enabled)
                return false;
            if (!butPlus.Enabled)
                return false;
            if (!butMinus.Enabled)
                return false;

            return true;
        }

        private void FreeButtons()
        {
            butMult.Enabled = true;
            butDiv.Enabled = true;
            butPlus.Enabled = true;
            butMinus.Enabled = true;
        }

        private void but1_Click(object sender, EventArgs e)
        {
            textBox1.Text += '1';

            CorrectNumber();
        }

        private void but2_Click(object sender, EventArgs e)
        {
            textBox1.Text += '2';

            CorrectNumber();
        }

        private void but3_Click(object sender, EventArgs e)
        {
            textBox1.Text += '3';

            CorrectNumber();
        }

        private void but4_Click(object sender, EventArgs e)
        {
            textBox1.Text += '4';

            CorrectNumber();
        }

        private void but5_Click(object sender, EventArgs e)
        {
            textBox1.Text += '5';

            CorrectNumber();
        }

        private void but6_Click(object sender, EventArgs e)
        {
            textBox1.Text += '6';

            CorrectNumber();
        }

        private void but7_Click(object sender, EventArgs e)
        {
            textBox1.Text += '7';

            CorrectNumber();
        }

        private void but8_Click(object sender, EventArgs e)
        {
            textBox1.Text += '8';

            CorrectNumber();
        }

        private void but9_Click(object sender, EventArgs e)
        {
            textBox1.Text += '9';

            CorrectNumber();
        }

        private void but0_Click(object sender, EventArgs e)
        {
            textBox1.Text += '0';

            CorrectNumber();
        }

        private void butEq_Click(object sender, EventArgs e)
        {
            if (!butMult.Enabled)
                textBox1.Text = C.Multiplication(Convert.ToDouble(textBox1.Text)).ToString();
            if (!butDiv.Enabled)
                textBox1.Text = C.Division(Convert.ToDouble(textBox1.Text)).ToString();
            if (!butPlus.Enabled)
                textBox1.Text = C.Sum(Convert.ToDouble(textBox1.Text)).ToString();
            if (!butMinus.Enabled)
                textBox1.Text = C.Substraction(Convert.ToDouble(textBox1.Text)).ToString();

            C.clear_A();
            FreeButtons();

            k = 0;
        }

        private void butPlus_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.put_A(Convert.ToDouble(textBox1.Text));
                butPlus.Enabled = false;
                textBox1.Text = "0";
            }
        }

        private void butMinus_Click(object sender, EventArgs e)
        {
            if (CanPress())
            {
                C.put_A(Convert.ToDouble(textBox1.Text));
                butMinus.Enabled = false;
                textBox1.Text = "0";
            }
        }

        private void butMult_Click(object sender, EventArgs e)
        {
            C.put_A(Convert.ToDouble(textBox1.Text));
            butMult.Enabled = false;
            textBox1.Text = "0";
        }

        private void butDiv_Click(object sender, EventArgs e)
        {
            C.put_A(Convert.ToDouble(textBox1.Text));
            butDiv.Enabled = false;
            textBox1.Text = "0";
        }

        private void butCLR_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";

            C.clear_A();
            FreeButtons();

            k = 0;
        }

        /*private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }*/

    }
}
