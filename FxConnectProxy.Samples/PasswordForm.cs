using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FxConnectProxy.Samples
{
    partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
            this.TbPass.Text = this.TbConfirm.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ConfirmPassword();
        }

        private void ConfirmPassword()
        {
            if (this.TbPass.Text != this.TbPass.Text)
            {
                MessageBox.Show("Passwords must match.", "Error");
                return;
            }

            if (this.ConfirmClicked != null)
            {
                this.ConfirmClicked(this, new ConfirmClickedEventArgs()
                {
                    Password = this.TbPass.Text,
                });
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public event EventHandler<ConfirmClickedEventArgs> ConfirmClicked;
    }
}
