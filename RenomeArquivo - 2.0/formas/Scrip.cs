﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RenomeArquivo___2._0.formas
{
    public partial class Scrip : Form
    {
        public Scrip()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string text = "URL=" + tb_folder.Text +Environment.NewLine;
            text += "MOD=" + cb_mod.Text;
            File.WriteAllText(@".\scr\" + tb_nome.Text + ".script", text);
            atualizaBox();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                tb_folder.Text = folderBrowserDialog1.SelectedPath;
        }

        private void Scrip_Load(object sender, EventArgs e)
        {atualizaBox();}

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if(tb_nome.Text != null || tb_nome.Text != "")
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(@".\scr\" + lb_scripts.SelectedItem.ToString() + ".script");
                fi.Delete();
                atualizaBox();
            }
            else
            {
                System.IO.FileInfo fi = new System.IO.FileInfo(@".\scr\" + tb_nome.Text + ".script");
                fi.Delete();
                atualizaBox();
            }
        }

        private void atualizaBox()
        {
            //combo box script
            lb_scripts.Items.Clear();
            string[] scrip = Directory.GetFiles(@".\scr");
            for (int i = 0; i <= scrip.Length - 1; i++)
            {
                lb_scripts.Items.Add(scrip[i].Replace(@".\scr\", "").Replace(".script", ""));
            }
            //list box mod
            scrip = Directory.GetFiles(@".\cmod");
            for (int i = 0; i <= scrip.Length - 1; i++)
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(scrip[i]);
                line = file.ReadLine();
                cb_mod.Items.Add(line);
            }
        }

        private void lb_scripts_Click(object sender, EventArgs e)
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(@".\scr\" + lb_scripts.SelectedItem.ToString() + ".script");
            line = file.ReadLine();
            tb_folder.Text = line.Replace("URL=", "");
            line = file.ReadLine();
            cb_mod.Text = line.Replace("MOD=", "");
            tb_nome.Text = lb_scripts.SelectedItem.ToString();
            file.Close();
        }
    }
}
