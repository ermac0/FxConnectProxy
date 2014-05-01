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
    partial class ConfigForm : Form
    {
        private const string __DefaultUrl = "http://www.fxcorporate.com/Hosts.jsp";

        public ConfigForm()
        {
            InitializeComponent();

            this.CbAccount.Items.Clear();
            this.CbAccount.Items.Add("Demo");
            this.CbAccount.Items.Add("Real");
        }

        public void Setup(Config config)
        {
            if (config == null)
            {
                // Use default
                config = new Config()
                {
                    AccountType = "Demo",
                    Url = __DefaultUrl,
                };
            }

            this.TbPassword.Text = config.Password;
            this.TbUrl.Text = string.IsNullOrEmpty(config.Url) ? __DefaultUrl : config.Url;
            this.TbUser.Text = config.Username;
            this.CChangeAccount.Checked = config.ChangeAccount;
            this.CSavePassword.Checked = config.SavePassword;

            if (config.ChangeAccount)
            {
                this.CbAccount.Text = config.AccountType;
                this.CbAccount.Enabled = true;
            }
            else
            {
                this.CbAccount.Text = "Demo";
                this.CbAccount.Enabled = false;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (this.SaveClicked != null)
            {
                var config = new Config();
                config.AccountType = this.CbAccount.Text;
                config.Password = this.CSavePassword.Checked ? this.TbPassword.Text : null;
                config.Url = this.TbUrl.Text;
                config.Username = this.TbUser.Text;
                config.SavePassword = this.CSavePassword.Checked;
                config.ChangeAccount = this.CChangeAccount.Checked;

                this.SaveClicked(this, new SaveConfigEventArgs()
                {
                    Config = config,
                });
            }

            this.Close();
        }

        public event EventHandler<SaveConfigEventArgs> SaveClicked;

        private void CChangeAccount_CheckedChanged(object sender, EventArgs e)
        {
            this.CbAccount.Enabled = this.CChangeAccount.Checked;
        }
    }
}
