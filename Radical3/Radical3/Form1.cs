using MaterialSkin;
using MaterialSkin.Controls;
using Python.Runtime;
using Dangl.Calculator;
using System.Windows.Forms;
using System.Linq;
using System;

namespace Radical3
{
    public partial class Form1 : MaterialForm
    {
        MaterialSkinManager ThemeManager = MaterialSkinManager.Instance;
        public Form1()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey300, Primary.Grey800, Primary.Grey800, Accent.Indigo700, TextShade.BLACK);
        }
        static string SimplifyExp(string fct, string exp)
        {
            if (exp == "1") return "sqrt(" + fct + ")";
            if (exp == "2") return "abs(" + fct + ")";
            else
            {
                return "(" + fct + ") ^ ((" + exp + ")/2)";
            }
        }

        static string Algebra(string line)
        {
            PythonEngine.Initialize();
            using (Py.GIL())
            {
                dynamic sympy = Py.Import("sympy");
                dynamic simplification = sympy.simplify;
                dynamic factor = sympy.factor;
                dynamic factor_list = sympy.factor_list;

                line = simplification(line).ToString();
                line = factor(line).ToString();
                line = line.Replace("**", "^");

                try
                {
                    var f = factor_list(line);

                    int cnt = 0;
                    foreach (var l in f[1]) cnt++;

                    for (int i = 0; i < cnt; i++)
                    {
                        string el = SimplifyExp(f[1][i][0].ToString(), f[1][i][1].ToString());
                        if (i == 0) line = el;
                        else line += " * " + el;
                    }

                    line = simplification(line).ToString();
                }
                catch (Python.Runtime.PythonException)
                {
                    string[] spt = new string[2];
                    spt = line.Split('^');
                    line = SimplifyExp(spt[0], spt[1]);
                    line = simplification(line).ToString();
                }

            }
            return line.ToLower();
        }

        static string Arithmetic(string line, int dg)
        {
            line = "sqrt(" + line + ")";

            var expr = Calculator.Calculate(line);

            double res = Math.Round(Convert.ToDouble((expr.Result)), dg);
            return res.ToString();
        }

        static string CalculateExpr(string line, int dg)
        {
            if (!line.Any(Char.IsLetter)) line = Arithmetic(line, dg);
            else line = Algebra(line);
            line = line.Replace("**", "^");

            return line;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (materialMaskedTextBox1.Text == "0")
            {
                materialMaskedTextBox1.Text = materialButton1.Text;
            }
            else
            {
                materialMaskedTextBox1.Text += materialButton1.Text;
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            if (materialMaskedTextBox1.Text == "0")
            {
                materialMaskedTextBox1.Text = materialButton2.Text;
            }
            else
            {
                materialMaskedTextBox1.Text += materialButton2.Text;
            }
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            if (materialMaskedTextBox1.Text == "0")
            {
                materialMaskedTextBox1.Text = materialButton3.Text;
            }
            else
            {
                materialMaskedTextBox1.Text += materialButton3.Text;
            }
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            if (materialMaskedTextBox1.Text == "0")
            {
                materialMaskedTextBox1.Text = materialButton4.Text;
            }
            else
            {
                materialMaskedTextBox1.Text += materialButton4.Text;
            }
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            if (materialMaskedTextBox1.Text == "0")
            {
                materialMaskedTextBox1.Text = materialButton5.Text;
            }
            else
            {
                materialMaskedTextBox1.Text += materialButton5.Text;
            }
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            if (materialMaskedTextBox1.Text == "0")
            {
                materialMaskedTextBox1.Text = materialButton6.Text;
            }
            else
            {
                materialMaskedTextBox1.Text += materialButton6.Text;
            }
        }

        private void materialButton7_Click(object sender, EventArgs e)
        {
            if (materialMaskedTextBox1.Text == "0")
            {
                materialMaskedTextBox1.Text = materialButton7.Text;
            }
            else
            {
                materialMaskedTextBox1.Text += materialButton7.Text;
            }
        }

        private void materialButton8_Click(object sender, EventArgs e)
        {
            if (materialMaskedTextBox1.Text == "0")
            {
                materialMaskedTextBox1.Text = materialButton8.Text;
            }
            else
            {
                materialMaskedTextBox1.Text += materialButton8.Text;
            }
        }

        private void materialButton9_Click(object sender, EventArgs e)
        {
            if (materialMaskedTextBox1.Text == "0")
            {
                materialMaskedTextBox1.Text = materialButton9.Text;
            }
            else
            {
                materialMaskedTextBox1.Text += materialButton9.Text;
            }
        }

        private void materialButton11_Click(object sender, EventArgs e)
        {
            if (materialMaskedTextBox1.Text == "0")
            {
                materialMaskedTextBox1.Text = materialButton11.Text;
            }
            else
            {
                materialMaskedTextBox1.Text += materialButton11.Text;
            }
        }

        private void materialButton10_Click(object sender, EventArgs e)
        {
            if (materialMaskedTextBox1.Text == "0")
            {
                materialMaskedTextBox1.Text = materialButton10.Text;
            }
            else
            {
                materialMaskedTextBox1.Text += materialButton10.Text;
            }
        }

        private void materialButton12_Click(object sender, EventArgs e)
        {
            materialMaskedTextBox1.Text += materialButton21.Text;
        }

        private void materialButton20_Click(object sender, EventArgs e)
        {
            materialMaskedTextBox1.Text = "0";
        }

        private void materialButton18_Click(object sender, EventArgs e)
        {
            if (materialMaskedTextBox1.Text.Length > 1) materialMaskedTextBox1.Text = materialMaskedTextBox1.Text.Remove(materialMaskedTextBox1.Text.Length - 1);
            else materialMaskedTextBox1.Text = "0";
        }

        private void materialButton16_Click(object sender, EventArgs e)
        {
            if (Char.IsDigit(materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1]) || Char.IsLetter(materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1]) || materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1] == ')') materialMaskedTextBox1.Text += '^';
        }

        private void materialButton14_Click(object sender, EventArgs e)
        {
            if (!Char.IsDigit(materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1])) materialMaskedTextBox1.Text = Math.PI.ToString();
            if (materialMaskedTextBox1.Text == "0")
            {
                materialMaskedTextBox1.Text = Math.PI.ToString();
            }
        }

        private void materialBu9tton19_Click(object sender, EventArgs e)
        {
            if (Char.IsDigit(materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1]) || Char.IsLetter(materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1]) || materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1] == ')') materialMaskedTextBox1.Text += '+';
        }

        private void materialButton17_Click(object sender, EventArgs e)
        {
            if (materialMaskedTextBox1.Text == "0") materialMaskedTextBox1.Text = "-";
            if (Char.IsDigit(materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1]) || Char.IsLetter(materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1]) || materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1] == ')') materialMaskedTextBox1.Text += '-';
        }

        private void materialButton15_Click(object sender, EventArgs e)
        {
            if (Char.IsDigit(materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1]) || Char.IsLetter(materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1]) || materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1] == ')') materialMaskedTextBox1.Text += '*';
        }

        private void materialButton13_Click(object sender, EventArgs e)
        {
            if (Char.IsDigit(materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1]) || Char.IsLetter(materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1]) || materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1] == ')') materialMaskedTextBox1.Text += '/';
        }

        private void materialButton21_Click(object sender, EventArgs e)
        {
            if (materialMaskedTextBox1.Text != "0")
            {
                if (materialMaskedTextBox1.Text[0] == '-' && materialMaskedTextBox1.Text[1] == '(') materialMaskedTextBox1.Text = materialMaskedTextBox1.Text.Substring(2, materialMaskedTextBox1.Text.Length - 3);
                else materialMaskedTextBox1.Text = "-(" + materialMaskedTextBox1.Text + ")";
            }
        }

        private void materialButton22_Click(object sender, EventArgs e)
        {
            if (materialMaskedTextBox1.Text.Count(f => (f == '(')) != materialMaskedTextBox1.Text.Count(f => (f == ')'))) materialMaskedTextBox1.Text = "Sytax error";
            else materialMaskedTextBox1.Text = CalculateExpr(materialMaskedTextBox1.Text, Convert.ToInt32(materialSlider1.Value));
        }

        private void materialButton31_Click(object sender, EventArgs e)
        {
            if (materialMaskedTextBox1.Text == "0") materialMaskedTextBox1.Text = "(";
            else if (materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1] == '(') materialMaskedTextBox1.Text += "(";
            else if (Char.IsDigit(materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1]) || Char.IsLetter(materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1]) || materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1] == ')') materialMaskedTextBox1.Text += "*(";
        }

        private void materialButton32_Click(object sender, EventArgs e)
        {
            if (materialMaskedTextBox1.Text.Contains("(")) materialMaskedTextBox1.Text += ")";
        }

        private void materialButton23_Click(object sender, EventArgs e)
        {
            if (!Char.IsDigit(materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1])) materialMaskedTextBox1.Text += "sin(";
            if (materialMaskedTextBox1.Text == "0") materialMaskedTextBox1.Text = "sin(";
        }

        private void materialButton25_Click(object sender, EventArgs e)
        {
            if (!Char.IsDigit(materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1])) materialMaskedTextBox1.Text += "cos(";
            if (materialMaskedTextBox1.Text == "0") materialMaskedTextBox1.Text = "cos(";
        }

        private void materialButton24_Click(object sender, EventArgs e)
        {
            if (!Char.IsDigit(materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1])) materialMaskedTextBox1.Text += "tan(";
            if (materialMaskedTextBox1.Text == "0") materialMaskedTextBox1.Text = "tan(";
        }

        private void materialButton26_Click(object sender, EventArgs e)
        {
            if (!Char.IsDigit(materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1])) materialMaskedTextBox1.Text += "cot(";
            if (materialMaskedTextBox1.Text == "0") materialMaskedTextBox1.Text = "cot(";
        }

        private void materialButton27_Click(object sender, EventArgs e)
        {
            if (!Char.IsDigit(materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1])) materialMaskedTextBox1.Text += "arcsin(";
            if (materialMaskedTextBox1.Text == "0") materialMaskedTextBox1.Text = "arcsin(";
        }

        private void materialButton28_Click(object sender, EventArgs e)
        {
            if (!Char.IsDigit(materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1])) materialMaskedTextBox1.Text += "arccos(";
            if (materialMaskedTextBox1.Text == "0") materialMaskedTextBox1.Text = "arccos(";
        }

        private void materialButton29_Click(object sender, EventArgs e)
        {
            if (!Char.IsDigit(materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1])) materialMaskedTextBox1.Text += "arctan(";
            if (materialMaskedTextBox1.Text == "0") materialMaskedTextBox1.Text = "arctan(";
        }

        private void materialButton30_Click(object sender, EventArgs e)
        {
            if (!Char.IsDigit(materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1])) materialMaskedTextBox1.Text += "arccot(";
            if (materialMaskedTextBox1.Text == "0") materialMaskedTextBox1.Text = "arccot(";
        }

        private void materialSwitch2_CheckedChanged(object sender, EventArgs e)
        {
            if (materialSwitch2.Checked)
            {
                materialButton1.Text = "a";
                materialButton2.Text = "b";
                materialButton3.Text = "c";
                materialButton4.Text = "d";
                materialButton5.Text = "e";
                materialButton6.Text = "f";
                materialButton7.Text = "g";
                materialButton8.Text = "h";
                materialButton9.Text = "x";
                materialButton11.Text = "y";
                materialButton10.Hide();
                materialButton12.Hide();
            }
            else
            {
                materialButton1.Text = "1";
                materialButton2.Text = "2";
                materialButton3.Text = "3";
                materialButton4.Text = "4";
                materialButton5.Text = "5";
                materialButton6.Text = "6";
                materialButton7.Text = "7";
                materialButton8.Text = "8";
                materialButton9.Text = "9";
                materialButton10.Text = "0";
                materialButton10.Show();
                materialButton12.Show();
            }
        }

        private void materialButton33_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialButton34_Click(object sender, EventArgs e)
        {
            MessageBox.ShowBox("Hotline number: +7 922-118-03-01", "Help");

        }

        private void materialButton36_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void materialButton35_Click(object sender, EventArgs e)
        {
            materialCard1.Show();
            materialButton35.Hide();
            materialButton37.Show();
        }

        private void materialSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (materialSwitch1.Checked)
            {
                ThemeManager.Theme = MaterialSkinManager.Themes.DARK;

                ThemeManager.ColorScheme = new ColorScheme(Primary.Grey700, Primary.Grey900, Primary.Grey900, Accent.Indigo700, TextShade.WHITE);
            }
            else
            {
                ThemeManager.Theme = MaterialSkinManager.Themes.LIGHT;
                ThemeManager.ColorScheme = new ColorScheme(Primary.Grey300, Primary.Grey800, Primary.Grey800, Accent.Indigo700, TextShade.BLACK);
            }
        }

        private void materialButton37_Click(object sender, EventArgs e)
        {
            materialCard1.Hide();
            materialButton37.Hide();
            materialButton35.Show();
        }

        private void materialButton19_Click(object sender, EventArgs e)
        {
            if (Char.IsDigit(materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1]) || Char.IsLetter(materialMaskedTextBox1.Text[materialMaskedTextBox1.Text.Length - 1])) materialMaskedTextBox1.Text += '+';
        }
    }
}