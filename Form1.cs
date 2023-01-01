using Squirrel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Test101
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            CheckforUpdates();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddVersionNumver();

        }

        private void AddVersionNumver()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo VerisonInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            this.Text += $" v.{VerisonInfo.FileVersion}";
        }

        private async void CheckforUpdates()
        {
            try
            {
                using (var mgr = await UpdateManager.GitHubUpdateManager("https://github.com/hy043/Test101"))
                {
                    var release = await mgr.UpdateApp();
                }
            }
            catch (Exception e)
            {

              Debug.WriteLine("faild to check update:" + e.ToString());
            }
        }


    }
}
     
