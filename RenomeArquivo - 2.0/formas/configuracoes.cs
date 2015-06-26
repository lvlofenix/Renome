using System;
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
        System.IO.StreamReader file = new System.IO.StreamReader(@".\conf.cf");
        messages mensagens = new messages();

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
            MessageBox.Show("Envia informações de uso do software de forma anonima para ajudar a identificar problemas e melhorias.","INFORMAÇÕES ANONIMAS DE USO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                //ATIVAR BARRA - ATIVAO OU DESATIVA A BARRA DE STATUS.
                else if (line.Substring(0, 5) == "BARRA")
                {
                    if (line.Substring(8) == "FALSE")
                    {
                        pb_barra.Image = Properties.Resources.lightbulb_off;
                    }
                    else
                    {
                        pb_barra.Image = Properties.Resources.lightbulb;
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
            }
            file.Close();
            lingua();
        }

        private void lingua()
        {
            mensagens.qualLang();
            lb_ajuda.Text = mensagens.LabelConfig;
            gb_opcoes.Text = mensagens.Gopsvisu;
            lb_ativcont.Text = mensagens.Labelativacont;
            lb_geralog.Text = mensagens.LabelGeraLog;
            lb_ativabarr.Text = mensagens.LabelAtivBarra;
            lb_desamin.Text = mensagens.LabelDesamini;
            gb_ferram.Text = mensagens.Gferra;
            lb_enviaesta.Text = mensagens.LabelEnvia;
            lb_verifiatua.Text = mensagens.LabelAtul;
            gb_idioma.Text = mensagens.GLangu;
            lb_ptbr.Text = mensagens.LabelPortu;
            lb_us.Text = mensagens.LabelUs;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desativa recursos do softwares para focar no desempenho. \n \r Ajuda a melhorar o tempo para grandes quantidades de arquivos.", "MODO TURBO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void pb_email_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@".\conf.cf");
            while ((line = file.ReadLine()) != null)
            {
                if (line.Substring(0, 5) == "EMAIL")
                {
                    string text = File.ReadAllText(@".\conf.cf");
                    if (line.Substring(8) == "FALSE")
                    {
                        pb_email.Image = Properties.Resources.lightbulb;
                        text = text.Replace("EMAIL = FALSE", "EMAIL = TRUE");
                        file.Close();
                        File.WriteAllText(@".\conf.cf", text);
                        break;
                        
                    }
                    else
                    {
                        pb_email.Image = Properties.Resources.lightbulb_off;
                        text = text.Replace("EMAIL = TRUE", "EMAIL = FALSE");
                        file.Close();
                        File.WriteAllText(@".\conf.cf", text);
                        break;
                    }
                }
            }
        }

        private void pb_log_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@".\conf.cf");
            while ((line = file.ReadLine()) != null)
            {
                if (line.Substring(0, 3) == "LOG")
                {
                    string text = File.ReadAllText(@".\conf.cf");
                    if (line.Substring(6) == "FALSE")
                    {
                        pb_log.Image = Properties.Resources.lightbulb;
                        text = text.Replace("LOG = FALSE", "LOG = TRUE");
                        file.Close();
                        File.WriteAllText(@".\conf.cf", text);
                        break;

                    }
                    else
                    {
                        pb_log.Image = Properties.Resources.lightbulb_off;
                        text = text.Replace("LOG = TRUE", "LOG = FALSE");
                        file.Close();
                        File.WriteAllText(@".\conf.cf", text);
                        break;
                    }
                }
            }
        }

        private void pb_tray_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@".\conf.cf");
            while ((line = file.ReadLine()) != null)
            {
                if (line.Substring(0, 4) == "TRAY")
                {
                    string text = File.ReadAllText(@".\conf.cf");
                    if (line.Substring(7) == "FALSE")
                    {
                        pb_tray.Image = Properties.Resources.lightbulb;
                        text = text.Replace("TRAY = FALSE", "TRAY = TRUE");
                        file.Close();
                        File.WriteAllText(@".\conf.cf", text);
                        break;

                    }
                    else
                    {
                        pb_tray.Image = Properties.Resources.lightbulb_off;
                        text = text.Replace("TRAY = TRUE", "TRAY = FALSE");
                        file.Close();
                        File.WriteAllText(@".\conf.cf", text);
                        break;
                    }
                }
            }
        }

        private void pb_barra_Click(object sender, EventArgs e)
        {
                    
            System.IO.StreamReader file = new System.IO.StreamReader(@".\conf.cf");
            while ((line = file.ReadLine()) != null)
            {
                if (line.Substring(0, 5) == "BARRA")
                {
                    string text = File.ReadAllText(@".\conf.cf");
                    if (line.Substring(8) == "FALSE")
                    {
                        pb_barra.Image = Properties.Resources.lightbulb;
                        text = text.Replace("BARRA = FALSE", "BARRA = TRUE");
                        file.Close();
                        File.WriteAllText(@".\conf.cf", text);
                        break;

                    }
                    else
                    {
                        pb_barra.Image = Properties.Resources.lightbulb_off;
                        text = text.Replace("BARRA = TRUE", "BARRA = FALSE");
                        file.Close();
                        File.WriteAllText(@".\conf.cf", text);
                        break;
                    }
                }
            }
        }

        private void pb_cont_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@".\conf.cf");
            while ((line = file.ReadLine()) != null)
            {
                if (line.Substring(0, 4) == "CONT")
                {
                    string text = File.ReadAllText(@".\conf.cf");
                    if (line.Substring(7) == "FALSE")
                    {
                        pb_cont.Image = Properties.Resources.lightbulb;
                        text = text.Replace("CONT = FALSE", "CONT = TRUE");
                        file.Close();
                        File.WriteAllText(@".\conf.cf", text);
                        break;

                    }
                    else
                    {
                        pb_cont.Image = Properties.Resources.lightbulb_off;
                        text = text.Replace("CONT = TRUE", "CONT = FALSE");
                        file.Close();
                        File.WriteAllText(@".\conf.cf", text);
                        break;
                    }
                }
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("A desativação dos retornos visuais fazem o software trabalhar mais rápido.", "DESATIVAÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void pb_eua_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@".\conf.cf");
            while ((line = file.ReadLine()) != null)
            {
                if (line.Substring(0, 6) == "LANGUE")
                {
                    string text = File.ReadAllText(@".\conf.cf");
                    if (line.Substring(9) == "PTBR")
                    {
                        pb_br.Image = Properties.Resources.br;
                        pb_eua.Image = Properties.Resources.us;
                        text = text.Replace("LANGUE = PTBR", "LANGUE = INGL");
                        file.Close();
                        File.WriteAllText(@".\conf.cf", text);
                        break;
                    }
                }
            }
        }

        private void pb_br_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@".\conf.cf");
            while ((line = file.ReadLine()) != null)
            {
                if (line.Substring(0, 6) == "LANGUE")
                {
                    string text = File.ReadAllText(@".\conf.cf");
                    if (line.Substring(9) == "INGL")
                    {
                        pb_br.Image = Properties.Resources.br1;
                        pb_eua.Image = Properties.Resources.eua;
                        text = text.Replace("LANGUE = INGL", "LANGUE = PTBR");
                        file.Close();
                        File.WriteAllText(@".\conf.cf", text);
                        break;
                    }
                }
            }
        }
    }
}
