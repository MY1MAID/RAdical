using AngouriMath;
using MathNet.Symbolics;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Drawing.Text;
using static Guna.UI2.WinForms.Suite.Descriptions;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Radical_ver._2._0
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile("C:/Users/Admin/source/repos/RAdical/Radical ver.2.0/Radical ver.2.0/Resources/Aqum.ttf"); // §æ§Ñ§Û§Ý §ê§â§Ú§æ§ä§Ñ
            FontFamily family = fontCollection.Families[0];
            // §³§à§Ù§Õ§Ñ§×§Þ §ê§â§Ú§æ§ä §Ú §Ú§ã§á§à§Ý§î§Ù§å§Ö§Þ §Õ§Ñ§Ý§Ö§Ö
            Font font = new Font(family, 15);
        }

        static bool isDouble(string line)
        {
            line = line.Replace('.', ',');
            if (line.Contains("(")) line = line[0] + line.Substring(2, line.Length - 3);
            return double.TryParse(line, out double _);
        }
        static string CalculateExpr(string line, int dg)
        {
            
            if (isDouble(line))
            {   
                if (Convert.ToDouble(line) >= 0) line = Math.Round(Math.Sqrt(Convert.ToDouble(line)), dg).ToString();
                else line = Math.Round(Math.Sqrt(Math.Abs(Convert.ToDouble(line))), dg).ToString() + "i";
                return line;
            }
            else
            {
                line = "sqrt(" + line + ")";
                var expr = Infix.ParseOrThrow(line);
                line = Infix.Format(Algebraic.Expand(expr));
                Entity ent = line;
                line = (ent.Simplify()).ToString();
                line = Regex.Replace(line, @"sqrt\((\d+)\)", match =>
                Math.Round(Math.Sqrt(double.Parse(match.Groups[1].Value)),dg).ToString(CultureInfo.CurrentCulture));
                line = Regex.Replace(line, @"sqrt\(-(\d+)\)", match =>
                Math.Round(Math.Sqrt(Math.Abs(double.Parse(match.Groups[1].Value))),dg).ToString(CultureInfo.CurrentCulture) + "i ");
                return line;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "1";
            } else
            {
                textBox1.Text += "1";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "2";
            }
            else
            {
                textBox1.Text += "2";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "3";
            }
            else
            {
                textBox1.Text += "3";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "4";
            }
            else
            {
                textBox1.Text += "4";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "5";
            }
            else
            {
                textBox1.Text += "5";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "6";
            }
            else
            {
                textBox1.Text += "6";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "7";
            }
            else
            {
                textBox1.Text += "7";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "8";
            }
            else
            {
                textBox1.Text += "8";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "9";
            }
            else
            {
                textBox1.Text += "9";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "0";
            }
            else
            {
                textBox1.Text += "0";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 1) textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            else textBox1.Text = "0";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = CalculateExpr(textBox1.Text, Convert.ToInt32(numericUpDown1.Text));
        }

        private void button14_Click(object sender, EventArgs e)
        {   if (textBox1.Text != "0")
            {
                if (textBox1.Text[0] == '-' && textBox1.Text[1] == '(') textBox1.Text = textBox1.Text.Substring(2, textBox1.Text.Length - 3);
                else textBox1.Text = "-(" + textBox1.Text + ")";
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text += '.';
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "0";
            }
            else
            {
                textBox1.Text += "00";
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text += '^';
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox1.Text += '+';
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "0") textBox1.Text += '-';
            else textBox1.Text = "-";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox1.Text += '*';
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox1.Text += '/';
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (!Char.IsDigit(textBox1.Text[textBox1.Text.Length - 1])) textBox1.Text = Math.PI.ToString().Replace(',', '.');
            if (textBox1.Text == "0")
            {
                textBox1.Text = Math.PI.ToString().Replace(',','.');
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (!Char.IsDigit(textBox1.Text[textBox1.Text.Length - 1])) textBox1.Text += "cot(";
            if (textBox1.Text == "0") textBox1.Text = "cot(";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (!Char.IsDigit(textBox1.Text[textBox1.Text.Length - 1])) textBox1.Text += "sin(";
            if (textBox1.Text == "0") textBox1.Text = "sin(";
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (!Char.IsDigit(textBox1.Text[textBox1.Text.Length - 1])) textBox1.Text += "cos(";
            if (textBox1.Text == "0") textBox1.Text = "cos(";
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (!Char.IsDigit(textBox1.Text[textBox1.Text.Length - 1])) textBox1.Text += "tan(";
            if (textBox1.Text == "0") textBox1.Text = "tan(";
        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (!Char.IsDigit(textBox1.Text[textBox1.Text.Length - 1])) textBox1.Text += "arcsin(";
            if (textBox1.Text == "0") textBox1.Text = "arcsin(";
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (!Char.IsDigit(textBox1.Text[textBox1.Text.Length - 1])) textBox1.Text += "arccos(";
            if (textBox1.Text == "0") textBox1.Text = "arccos(";
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (!Char.IsDigit(textBox1.Text[textBox1.Text.Length - 1])) textBox1.Text += "arctan(";
            if (textBox1.Text == "0") textBox1.Text = "arctan(";
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (!Char.IsDigit(textBox1.Text[textBox1.Text.Length - 1])) textBox1.Text += "arccot(";
            if (textBox1.Text == "0") textBox1.Text = "arccot(";
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (!Char.IsDigit(textBox1.Text[textBox1.Text.Length - 1])) textBox1.Text += "(";
            if (textBox1.Text == "0") textBox1.Text = "(";
        }

        private void button32_Click(object sender, EventArgs e)
        {
            textBox1.Text += ")";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}