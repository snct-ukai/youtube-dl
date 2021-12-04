using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoLibrary;

namespace youtube_dl
{
    public partial class Form1 : Form
    {
        string fpath,url;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            fpath = fbd.SelectedPath;
            label1.Text = fpath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fpath != null && url != null)
            {
                var youtube = YouTube.Default;
                var video = youtube.GetVideo(url);
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = video.FullName;
                try
                {
                    string path = fpath + "/" + sfd.FileName;
                    System.IO.File.WriteAllBytes(path, video.GetBytes());
                    MessageBox.Show("ダウンロード完了", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process p = System.Diagnostics.Process.Start(path);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            url = textBox1.Text;
        }
    }
}
