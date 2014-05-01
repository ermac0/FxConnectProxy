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
    partial class ExampleForm : Form
    {
        private const string __Title = "FxConnectProxy Example - ";

        private Type ExampleType { get; set; }
        private IExample Example { get; set; }
        private Config Config { get; set; }

        public ExampleForm()
        {
            InitializeComponent();
            this.webBrowser1.DocumentText = AppRes.Console.Replace("{jQuery}", AppRes.jquery);
        }

        public void Setup(Type type, Config config)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            this.ExampleType = type;
            this.Config = config;

            var tmp = Activator.CreateInstance(type) as IExample;
            this.Text = __Title + tmp.Name;

            this.button1.Enabled = true;
            this.button2.Enabled = false;
        }

        private void WriteToOutput(string text, string cssClass = null)
        {
            try
            {
                this.webBrowser1.Suspend();
                this.webBrowser1.Document.InvokeScript("AddLine", new object[] { text, cssClass });
                this.webBrowser1.Resume();
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.StartExample();
        }

        private void StartExample()
        {
            this.button1.Enabled = false;
            this.button2.Enabled = true;
            Application.DoEvents();

            this.Example = Activator.CreateInstance(this.ExampleType) as IExample;
            this.Example.Log += this.OnExampleLog;
            this.Example.Stopped += this.OnExampleStopped;

            this.WriteToOutput(string.Format(@"Starting example: ""{0}""", this.Example.Name), "start");
            this.WriteToOutput(this.Example.Description, "description");
            this.WriteToOutput("");
            this.WriteToOutput("");

            this.Example.Start(this.Config.Username, this.Config.Password, this.Config.Url, this.Config.AccountType);
        }

        void OnExampleStopped(object sender, EventArgs e)
        {
            try
            {
                this.Invoke((Action)(() =>
                {
                    this.WriteToOutput("");
                    this.WriteToOutput("Stopped.", "start");
                    this.WriteToOutput("");

                    this.button1.Enabled = true;
                    this.button2.Enabled = false;
                }));
            }
            catch { }
            this.Example = null;
        }

        void OnExampleLog(object sender, LogEventArgs e)
        {
            try
            {
                this.Invoke((Action)(() =>
                {
                    this.WriteToOutput(e.Text);
                }));
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.StopExample();
        }

        private void StopExample()
        {
            if (this.Example != null)
            {
                this.WriteToOutput("Stopping example...", "start");
                this.Example.Stop();
                this.Example = null;
            }
        }

        private void ExampleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.StopExample();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.ClearOutput();
        }

        private void ClearOutput()
        {
            try
            {
                this.webBrowser1.Document.InvokeScript("Clear", new object[] { });
            }
            catch { }
        }
    }
}
