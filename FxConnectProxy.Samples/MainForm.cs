using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FxConnectProxy.Samples
{
    public partial class MainForm : Form
    {
        private const string __FolderName = "FxConnectProxy.Samples";
        private const string __ConfigFile = "config.js";

        private Config Config { get; set; }

        public MainForm()
        {
            InitializeComponent();

            this.Config = this.LoadConfig();
            this.PopulateDemos();
        }

        private void PopulateDemos()
        {
            var examples = this.GetType().Assembly.GetTypes()
                .Where(x => !x.IsAbstract && !x.IsInterface && typeof(IExample).IsAssignableFrom(x))
                .Select(x => Activator.CreateInstance(x) as IExample);

            this.listBox1.Items.Clear();

            foreach (var e in examples.OrderBy(x => x.Order).ThenBy(x => x.Name))
            {
                if (e.IsHidden)
                {
                    continue;
                }

                this.listBox1.Items.Add(new ListItem(e.Name, e.GetType()));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.ShowConfigDialog();
        }

        private void ShowConfigDialog()
        {
            var dialog = new ConfigForm();

            dialog.SaveClicked += this.OnSaveClicked;
            dialog.Setup(this.Config);

            this.Hide();
            dialog.ShowDialog(this);
            this.Show();
        }

        void OnSaveClicked(object sender, SaveConfigEventArgs e)
        {
            this.Config = e.Config;
            this.SaveConfig(this.Config);
        }

        private void SaveConfig(Config config)
        {
            var baseDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), __FolderName);
            Directory.CreateDirectory(baseDir);

            if (!config.SavePassword)
            {
                config.Password = null;
            }

            var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(Config));

            using (var s = File.Open(Path.Combine(baseDir, __ConfigFile), FileMode.Create))
            {
                serializer.WriteObject(s, config);
            }
        }

        private Config LoadConfig()
        {
            var baseDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), __FolderName);
            var path = Path.Combine(baseDir, __ConfigFile);

            if (File.Exists(path))
            {
                var config = new Config();
                var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(config.GetType());

                using (var s = File.OpenRead(path))
                {
                    config = (Config)serializer.ReadObject(s);
                }

                return config;
            }

            return null;
        }

        class ListItem
        {
            public string Text { get; set; }

            public Type Type { get; set; }

            public override string  ToString()
            {
 	             return "  " + (string.IsNullOrEmpty(this.Text) ? "Item" : this.Text);
            }

            public ListItem()
            {
            }

            public ListItem(string text, Type type)
            {
                this.Text = text;
                this.Type = type;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.LaunchExample();
        }

        private void LaunchExample()
        {
            // Validate config.
            if (this.Config == null)
            {
                MessageBox.Show("Configure account first.", "Error");
                return;
            }

            if (string.IsNullOrEmpty(this.Config.Username))
            {
                MessageBox.Show("Provide User.", "Error");
                return;
            }
            if (string.IsNullOrEmpty(this.Config.Url))
            {
                MessageBox.Show("Provide URL.", "Error");
                return;
            }
            if (string.IsNullOrEmpty(this.Config.AccountType))
            {
                MessageBox.Show("Provide Account Type.", "Error");
                return;
            }

            var confirmed = false;

            if (string.IsNullOrEmpty(this.Config.Password))
            {
                var passForm = new PasswordForm();
                passForm.ConfirmClicked += (s, e) =>
                    {
                        this.Config.Password = e.Password;

                        // Allow for an empty password if user confirms!
                        confirmed = true;
                    };
                passForm.ShowDialog(this);
            }

            if (string.IsNullOrEmpty(this.Config.Password) && !confirmed)
            {
                MessageBox.Show("Password not provided.", "Error");
                return;
            }

            var t = this.listBox1.SelectedItem as ListItem;
            if (t == null)
            {
                MessageBox.Show("Select example to run.", "Error");
                return;
            }

            var form = new ExampleForm();
            form.Setup(t.Type, this.Config);
            this.Hide();
            form.ShowDialog(this);
            this.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = this.listBox1.SelectedItem as ListItem;
            if (item != null)
            {
                var inst = Activator.CreateInstance(item.Type) as IExample;
                this.textBox1.Text = inst.Description;
            }
        }
    }
}
