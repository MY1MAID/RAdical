using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Radical3
{
    public partial class MessageBox : MaterialForm
    {
        static MessageBox newMessageBox;
        static string ButtonID;
        MaterialSkinManager ThemeManager = MaterialSkinManager.Instance;
        public MessageBox()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey400, Primary.Grey800, Primary.Grey800, Accent.Indigo700, TextShade.BLACK);
        }

        public static string ShowBox(string txtMessage)
        {
            newMessageBox = new MessageBox();
            newMessageBox.label2.Text = txtMessage;
            newMessageBox.ShowDialog();
            return ButtonID;
        }
        public static string ShowBox(string txtMessage, string txtTitle)
        {
            newMessageBox = new MessageBox();
            newMessageBox.label1.Text = txtTitle;
            newMessageBox.label2.Text=txtMessage;
            newMessageBox.ShowDialog();
            return ButtonID;
        }
        private void materialButton1_Click(object sender, EventArgs e)
        {
            ButtonID = "1";
            this.Close();
        }

    }
}
