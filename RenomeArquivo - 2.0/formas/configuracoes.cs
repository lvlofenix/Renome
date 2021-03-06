﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using RenomeArquivo___2._0.classes.configs;
using RenomeArquivo___2._0.classes;

namespace RenomeArquivo___2._0.formas
{
    public partial class configuracoes : Form
    {
        string line = "";
        string text = File.ReadAllText(@".\conf.cf");
        System.IO.StreamReader file = new System.IO.StreamReader(@".\conf.cf");
        messages mensagens = new messages();
        coreconfig coreconfig = new coreconfig();
        public configuracoes()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            MessageBox.Show(mensagens.TbDuvajud, mensagens.TbDuvTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void configuracoes_Load(object sender, EventArgs e)
        {
            while ((line = file.ReadLine()) != null)
            {
                //ATIVAR CONTADORES - VERIFICANDO SE ESTA ATIVO OU DESATIVO.
                 if (line.Substring(0, 4) == "CONT")
                {
                    if (line.Substring(7) == "FALSE")
                    {
                        
                        pb_cont.Image = Properties.Resources.lightbulb_off;
                    }
                    else
                    {
                        pb_cont.Image = Properties.Resources.lightbulb;
                    }
                }

                //ATIVAR LOGS - ATIVAO OU DESATIVA LOG.
                else if (line.Substring(0, 3) == "LOG")
                {
                    if (line.Substring(6) == "FALSE")
                    {
                        pb_log.Image = Properties.Resources.lightbulb_off;
                    }
                    else
                    {
                        pb_log.Image = Properties.Resources.lightbulb;
                    }
                }

                //ATIVAR TRAY - ATIVAO OU DESATIVA TRAY AUTOMATICO.
                else if (line.Substring(0, 4) == "TRAY")
                {
                    if (line.Substring(7) == "FALSE")
                    {
                        pb_tray.Image = Properties.Resources.lightbulb_off;
                    }
                    else
                    {
                        pb_tray.Image = Properties.Resources.lightbulb;
                    }
                }
                else if (line.Substring(0, 5) == "EMAIL")
                {
                    if (line.Substring(8) == "FALSE")
                    {
                        pb_email.Image = Properties.Resources.lightbulb_off;
                    }
                    else
                    {
                        pb_email.Image = Properties.Resources.lightbulb;
                    }
                }
                 else if (line.Substring(0, 6) == "LANGUE")
                 {
                     if (line.Substring(9) == "PTBR")
                     {
                         pb_eua.Image = Properties.Resources.eua;
                         pb_br.Image = Properties.Resources.br1;

                     }
                     else
                     {
                         pb_eua.Image = Properties.Resources.us;
                         pb_br.Image = Properties.Resources.br;
                     }
                 }
                 else if (line.Substring(0, 5) == "RELAE")
                 {
                     if (line.Substring(8) == "FALSE")
                     {
                         pb_rela.Image = Properties.Resources.lightbulb_off;

                     }
                     else
                     {
                         pb_rela.Image = Properties.Resources.lightbulb;
                     }
                 }
            }
            file.Close();
            file.Dispose();
            lingua();
        }

        private void lingua()
        {
            mensagens.qualLang();
            lb_ajuda.Text = mensagens.LabelConfig;
            gb_opcoes.Text = mensagens.Gopsvisu;
            lb_ativcont.Text = mensagens.Labelativacont;
            lb_geralog.Text = mensagens.LabelGeraLog;
            lb_desamin.Text = mensagens.LabelDesamini;
            gb_ferram.Text = mensagens.Gferra;
            lb_enviaesta.Text = mensagens.LabelEnvia;
            lb_verifiatua.Text = mensagens.LabelAtul;
            gb_idioma.Text = mensagens.GLangu;
            lb_ptbr.Text = mensagens.LabelPortu;
            lb_us.Text = mensagens.LabelUs;
            lb_reporterro.Text = mensagens.LabelRela;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(mensagens.TbDuvVisu, mensagens.TbDuvTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void pb_email_Click(object sender, EventArgs e)
        {
            if (coreconfig.ativa_email())
            {
                pb_email.Image = Properties.Resources.lightbulb;
            }
            else
            {
                pb_email.Image = Properties.Resources.lightbulb_off;
            }
        }

        private void pb_log_Click(object sender, EventArgs e)
        {
            if (coreconfig.ativa_log())
            {
                pb_log.Image = Properties.Resources.lightbulb;
            }
            else
            {
                pb_log.Image = Properties.Resources.lightbulb_off;
            }
        }

        private void pb_tray_Click(object sender, EventArgs e)
        {
            if (coreconfig.ativa_tray())
            {
                pb_tray.Image = Properties.Resources.lightbulb;
            }
            else
            {
                pb_tray.Image = Properties.Resources.lightbulb_off;
            }
        }

        private void pb_cont_Click(object sender, EventArgs e)
        {
            if (coreconfig.ativa_contadores())
            {
                pb_cont.Image = Properties.Resources.lightbulb;
            }
            else
            {
                pb_cont.Image = Properties.Resources.lightbulb_off;
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(mensagens.TbDuvVisu, mensagens.TbDuvTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void pb_eua_Click(object sender, EventArgs e)
        {
            if (coreconfig.lingua_us())
            {
                pb_br.Image = Properties.Resources.br;
                pb_eua.Image = Properties.Resources.us;
                MessageBox.Show(mensagens.Mbstradu);
            }
        }

        private void pb_br_Click(object sender, EventArgs e)
        {
            if (coreconfig.lingua_ptbr())
            {
                pb_br.Image = Properties.Resources.br1;
                pb_eua.Image = Properties.Resources.eua;
                MessageBox.Show(mensagens.Mbstradu);
            }
        }

        private void pb_rela_Click(object sender, EventArgs e)
        {
            if (coreconfig.ativa_relae())
            {
                pb_rela.Image = Properties.Resources.lightbulb;
            }
            else
            {
                pb_rela.Image = Properties.Resources.lightbulb_off;
            }
        }
    }
}
