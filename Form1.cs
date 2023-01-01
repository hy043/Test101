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
        UpdateManager manager;
        public Form1()
        {
            InitializeComponent();

            CheckforUpdates();
        }


        private async Task CheckforUpdates()
        {
            manager = await UpdateManager.GitHubUpdateManager(@"https://github.com/hy043/Test101");
          
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo VerisonInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

            this.Text += $" v.{VerisonInfo.FileVersion}";

        }

        private async void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            var updateinfo = await manager.CheckForUpdate();
            if (updateinfo.ReleasesToApply.Count > 0)
            {
                DialogResult dr = ShowDialog();
                if (dr == DialogResult.Yes)
                {
                    await manager.UpdateApp();
                    MessageBox.Show("updated");
                }
                else if (dr == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("you're up to date");
            }
        }
    }
}
