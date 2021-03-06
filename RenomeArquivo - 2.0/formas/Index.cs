﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using RenomeArquivo___2._0.classes;
using RenomeArquivo___2._0.formas;
using RenomeArquivo___2._0.classes.etc;

namespace RenomeArquivo___2._0
{
    public partial class Index : Form
    {
        public Index()
        {
            check.verificaIntegridade();
            mensagens.qualLang();
            InitializeComponent();
        }
        //threads, classes e variaveis globais
         messages mensagens = new messages();
         checkUp check = new checkUp();
         VisuErro telaerro;
         DateTime fileCreateDate;
         FileInfo tamanho;
         Thread carrega;
         Thread trabalha;
         Thread email;
        private float tamanhomb = 0;
        private int falhas = 0;
        private int mil = 0;
        private string modo = String.Empty;
        private int quants = 0;
        private int cont = 0;
        private string text = String.Empty;
        private string[,] griderro;
        private Boolean cturbo = false;
        private Boolean ccontador = false;
        private Boolean clogs = false;
        private Boolean ctray = false;
        private Boolean cemail = false;

        //AÇÃO DOS BOTOES
        //inicia o processo
        public void lb_iniciar_Click(object sender, EventArgs e)
        {
            text = File.ReadAllText(@".\conf.cf");
            if (dg_lista.RowCount >= 2)
            {
                iniciandoTrabalhos();
            }
        }

        public void iniciandoTrabalhos()
        {
            if (lb_iniciar.Text == mensagens.BtlabelIniciar )
            {
                gb_opcoes.Enabled = false;
                trabalha = new Thread(iniciaProcesso);
                trabalha.Start();
                lb_iniciar.Text = mensagens.BtlabelAbortar;
                lb_iniciar.ForeColor = Color.Red;
                if (mil > 999 & text.IndexOf("TRAY = FALSE") == -1)
                {
                    notifyIcon1.Visible = true;
                    this.Visible = false;
                    notifyIcon1.BalloonTipText = mensagens.MinimizeTrayTip;
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon1.BalloonTipTitle = mensagens.MinimizeTrayTitle2;
                    notifyIcon1.ShowBalloonTip(500);
                }
                
            }
            else
            {
                gb_opcoes.Invoke((MethodInvoker)delegate { gb_opcoes.Enabled = true; });
                lb_iniciar.Invoke((MethodInvoker)delegate { lb_iniciar.Text = mensagens.BtlabelIniciar; });
                lb_iniciar.Invoke((MethodInvoker)delegate { lb_iniciar.ForeColor = Color.Green; });
                trabalha.Abort();
            }
        }

        //limpa campos e variaveis
        private void lb_limpa_Click(object sender, EventArgs e)
        {
            limpa();
            cont = 0;
            log.Invoke((MethodInvoker)delegate { log.Text = ""; });
        }

        private void rb_numerico_CheckedChanged(object sender, EventArgs e)
        {
            campoSelecionado();
        }

        private void rb_alfa_CheckedChanged(object sender, EventArgs e)
        {
            campoSelecionado();
        }

        private void rb_nome_CheckedChanged(object sender, EventArgs e)
        {
            campoSelecionado();
        }

        private void rb_data_CheckedChanged(object sender, EventArgs e)
        {
            campoSelecionado();
        }

        private void rb_tipo_CheckedChanged(object sender, EventArgs e)
        {
            campoSelecionado();
        }

        private void rb_tamanho_CheckedChanged(object sender, EventArgs e)
        {
            campoSelecionado();
        }

        private void rb_aleatorio_CheckedChanged(object sender, EventArgs e)
        {
            campoSelecionado();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            configuracoes configs = new configuracoes();
            configs.ShowDialog();
        }

        public void novoLog(string novo, Color cor)
        {
                cont++;
                novo = Environment.NewLine + cont + " > " + novo;
                log.Invoke((MethodInvoker)delegate { log.SelectionColor = cor; });
                log.Invoke((MethodInvoker)delegate { log.AppendText(novo); });
                log.Invoke((MethodInvoker)delegate { log.SelectionStart = log.Text.Length; });
                log.Invoke((MethodInvoker)delegate { log.SelectionLength = log.Text.Length + 1; });
                log.Invoke((MethodInvoker)delegate { log.SelectionColor = Color.Black; });
                log.Invoke((MethodInvoker)delegate { log.AppendText("\t(" + DateTime.Now + ")"); });
                log.Invoke((MethodInvoker)delegate { log.ScrollToCaret(); });
        }

        private void label16_Click(object sender, EventArgs e)
        {
            cont = 0;
            log.Invoke((MethodInvoker)delegate { log.Text = ""; });
        }

        private void Index_Load(object sender, EventArgs e)
        {
            lingua();
            nd_numerico.Value = 0;
            cb_alfa.Text = "A";
            nd_alfa.Value = 0;
            tb_nome.Enabled = false;
            nd_nome.Value = 0;
            //setando os data
            cb_data.Items.Add(mensagens.MlDateI);
            cb_data.Items.Add(mensagens.MlDateII);
            cb_data.Text = mensagens.MlDateI;
            //setando tipo
            cb_tipo.Items.Add(mensagens.MlTipI);
            cb_tipo.Items.Add(mensagens.MlTipII);
            cb_tipo.Text = mensagens.MlTipI;
            //setando tamanho
            cb_tamanho.Items.Add(mensagens.MlTamaKb);
            cb_tamanho.Items.Add(mensagens.MlTamaMb);
            cb_tamanho.Text = mensagens.MlTamaKb;
            //setando aleatorio
            cb_aleatorio.Items.Add(mensagens.MlRandI);
            cb_aleatorio.Items.Add(mensagens.MlRandII);
            cb_aleatorio.Items.Add(mensagens.MlRandIII);
            cb_aleatorio.Text = mensagens.MlRandI;
            //buscando scripts
            string[] itensScripts = check.verificaScripts();
            for(int i =0; i  <= itensScripts.Length-1; i++)
            {
                cb_script.Items.Add(itensScripts[i].Replace(".script",""));
            }
        }

        //minetray
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            notifyIcon1.Visible = false;
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            notifyIcon1.Visible = true;
        }
        //minetray

        private void lb_sobre_Click(object sender, EventArgs e)
        {
            AboutBox sobre = new AboutBox();
            sobre.Show();
        }

        private void lb_carrega_arquivos_Click_1(object sender, EventArgs e)
        {
            text = File.ReadAllText(@".\conf.cf");
            if (lb_carrega_arquivos.Text == mensagens.BtLabelCarregar)
            {
                lb_carrega_arquivos.Text = mensagens.BtlabelCancelar;
                lb_carrega_arquivos.ForeColor = Color.Red;
                carrega = new Thread(pegaCaminho);
                carrega.ApartmentState = ApartmentState.STA;
                carrega.Start();
                lb_iniciar.Enabled = false;
            }
            else
            {
                lb_carrega_arquivos.ForeColor = Color.Navy;
                lb_carrega_arquivos.Text = mensagens.BtLabelCarregar;
                lb_iniciar.Enabled = true;
                novoLog(mensagens.UpCancel, Color.Red);
                carrega.Abort();
                limpa();
            }
        }

        private void pb_logerro_Click(object sender, EventArgs e)
        {
            telaerro = new VisuErro(griderro);
            telaerro.ShowDialog();
        }

        private void lb_scripts_Click(object sender, EventArgs e)
        {
            Scrip scripts = new Scrip();
            scripts.ShowDialog();
        }

        private void lingua()
        {
            //BOTÕES
            lb_iniciar.Text = mensagens.BtlabelIniciar;
            lb_carrega_arquivos.Text = mensagens.BtLabelCarregar;
            lb_limpa.Text = mensagens.BtLabelLimpa;
            lb_configs.Text = mensagens.BtLabelConfig;
            lb_sobre.Text = mensagens.BtLabelSobre;
            gv_lista.Text = mensagens.LabelCarregados;
            lb_renome.Text = mensagens.LabelRenomes;
            lb_falha.Text = mensagens.LabelFalhas;
            lb_inicio1.Text = mensagens.LabelInicio;
            lb_inicio2.Text = mensagens.LabelInicio;
            lb_inicio3.Text = mensagens.LabelInicio;
            //CHECKS
            lb_numerico.Text = mensagens.CbLabelNum;
            lb_alfanumerico.Text = mensagens.CbLabelalpha;
            lb_nome.Text = mensagens.CbLabelNome;
            lb_data.Text = mensagens.CbLabelData;
            lb_tipo.Text = mensagens.CbLabelTipo;
            lb_tamanho.Text = mensagens.CbLabelTamn;
            lb_aleatorio.Text = mensagens.CbLabelRand;
            //GRIDS
            gb_opcoes.Text = mensagens.Gopcoes;
            gb_acao.Text = mensagens.Gacao;
            gb_log.Text = mensagens.Glog;
            //CAMPOS
            cb_data.Text = mensagens.MlDateI;
            cb_tipo.Text = mensagens.MlTipI;
            cb_aleatorio.Text = mensagens.MlRandI;
            cb_tamanho.Text = mensagens.MlTamaMb;
            //SCRIPTS
            
        }

        private void finalizacao()
        {
            notifyIcon1.BalloonTipText = mensagens.MinimizeTrayFinish;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipTitle = mensagens.MinimizeTrayTitle1;
            notifyIcon1.ShowBalloonTip(500);
            this.Invoke((MethodInvoker)delegate { this.Visible = true; });
            if (quants == 0 & falhas == 0)
            {
                MessageBox.Show(mensagens.TotalSucess, mensagens.TitleBoxSucess, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(quants + mensagens.TotalSucess, mensagens.TitleBoxSucess, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (falhas > 0 & text.IndexOf("RELAE = TRUE") > -1)
            {
                pb_logerro.Invoke((MethodInvoker)delegate { pb_logerro.Visible = true; });
            }
            else
            {
                pb_logerro.Invoke((MethodInvoker)delegate { pb_logerro.Visible = false; });
            }
            email = new Thread(enviaestatic);
            email.Start();
            iniciandoTrabalhos();
        }

        //MEOTODOS
        //pega o caminho dos arquivosCONF
        [STAThread]
        private void pegaCaminho()
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                limpa();
                alimentador(openFileDialog1.SafeFileNames, openFileDialog1.FileName.Replace(openFileDialog1.SafeFileName, ""));
            }
            else
            {
                lb_iniciar.Invoke((MethodInvoker)delegate { lb_iniciar.Enabled = true; });
                Invoke((MethodInvoker)delegate { lb_carrega_arquivos.Enabled = true; });
                Invoke((MethodInvoker)delegate { lb_carrega_arquivos.ForeColor = Color.Navy; });
                Invoke((MethodInvoker)delegate { lb_carrega_arquivos.Text = mensagens.BtLabelCarregar; });
                novoLog(mensagens.UpCancel, Color.Red);
                carrega.Abort();
                limpa();
            }
        }

        //alimenta a lista e as strings de controle
        private void alimentador(string[] arquivos, string caminho)
        {
            int quantos = 0;
            //alimenta string do caminho.
            novoLog(mensagens.LogUrl + caminho, Color.Blue);
            dg_lista.Invoke((MethodInvoker)delegate { dg_lista.Rows.Clear(); });
            //alimenta listbox
            for (int i = 0; i <= arquivos.Length - 1; i++)
            {
                tamanho = new FileInfo(caminho + arquivos[i]);
                float tamanhoMB = (tamanho.Length / 1014f) / 1014f;
                fileCreateDate = File.GetCreationTime(caminho + arquivos[i]);
                string data = Convert.ToString(fileCreateDate);
                dg_lista.Invoke((MethodInvoker)delegate { dg_lista.Rows.Add(arquivos[i], tamanhoMB, Path.GetExtension(caminho + arquivos[i]), data); });
                novoLog(arquivos[i] + mensagens.UpSucess, Color.Green);
                if (text.IndexOf("CONT = FALSE") == -1)
                {
                    gv_lista.Invoke((MethodInvoker)delegate { gv_lista.Text = mensagens.LabelCarregados + i; });
                    quantos = i;
                }
            }
            if (text.IndexOf("CONT = FALSE") == -1)
            {
                quantos = quantos + 1;
                gv_lista.Invoke((MethodInvoker)delegate { gv_lista.Text = mensagens.LabelCarregados + quantos; });
            }
            mil = quantos;
            lb_iniciar.Invoke((MethodInvoker)delegate { lb_iniciar.Enabled = true; });
            lb_carrega_arquivos.Invoke((MethodInvoker)delegate { lb_carrega_arquivos.Enabled = true; });
            lb_carrega_arquivos.ForeColor = Color.Navy;
            lb_carrega_arquivos.Invoke((MethodInvoker)delegate { lb_carrega_arquivos.Text = mensagens.BtLabelCarregar; });
            carrega.Abort();
        }

        //ativa campos
        private void campoSelecionado()
        {
            desativaCampo();
            if (rb_numerico.Checked) { nd_numerico.Enabled = true; modo = "numerico"; }
            else
            {
                if (rb_alfa.Checked) { cb_alfa.Enabled = true; nd_alfa.Enabled = true; modo = "alfa"; }
                else
                {
                    if (rb_nome.Checked) { tb_nome.Enabled = true; nd_nome.Enabled = true; modo = "nome"; }
                    else
                    {
                        if (rb_data.Checked) { cb_data.Enabled = true; modo = "data"; }
                        else
                        {
                            if (rb_tipo.Checked) { cb_tipo.Enabled = true; modo = "tipo"; }
                            else
                            {
                                if (rb_tamanho.Checked) { cb_tamanho.Enabled = true; modo = "tamanaho"; }
                                else { cb_aleatorio.Enabled = true; modo = "aleatorio"; }
                            }
                        }
                    }
                }
            }
        }

        //desativa tudo
        private void desativaCampo()
        {
            nd_numerico.Enabled = false;
            cb_alfa.Enabled = false;
            nd_alfa.Enabled = false;
            tb_nome.Enabled = false;
            nd_nome.Enabled = false;
            cb_data.Enabled = false;
            cb_tipo.Enabled = false;
            cb_tamanho.Enabled = false;
            cb_aleatorio.Enabled = false;
        }

        //limpa todos os campos
        private void limpa()
        {
            dg_lista.Invoke((MethodInvoker)delegate { dg_lista.Rows.Clear(); });
            gv_lista.Invoke((MethodInvoker)delegate { gv_lista.Text = mensagens.LabelCarregados + 0; });
            lb_renome.Invoke((MethodInvoker)delegate { lb_renome.Text = mensagens.LabelRenomes + 0; });
            lb_falha.Invoke((MethodInvoker)delegate { lb_falha.Text = mensagens.LabelFalhas + 0; });
            nd_numerico.Invoke((MethodInvoker)delegate { nd_numerico.Value = 0; });
            nd_alfa.Invoke((MethodInvoker)delegate { nd_alfa.Value = 0; });
            nd_nome.Invoke((MethodInvoker)delegate { nd_nome.Value = 0; });
            cb_alfa.Invoke((MethodInvoker)delegate { cb_alfa.ResetText(); });
            pb_logerro.Invoke((MethodInvoker)delegate { pb_logerro.Visible = false; });
            cb_script.Invoke((MethodInvoker)delegate {cb_script.Text = null; });
        }

        //faz a verificação de qual modo vai ser e inicia a classe correta
        private void iniciaProcesso()
        {
            //setando variaveis iniciais
            int quantos = 0;
            int qtderror = 0;
            string modo = "";
            falhas = 0;
            string caminho = openFileDialog1.FileName.Replace(openFileDialog1.SafeFileNames[0], "");
            griderro = new string[openFileDialog1.SafeFileNames.Length, 6];
            atualizaPermi();
            //renomeando de forma numerica
            if (rb_numerico.Checked)
            {
                modo = lb_numerico.Text;
                decimal valor = nd_numerico.Value;
                rc_numerico numerico = new rc_numerico();
                for (int i = 0; i <= openFileDialog1.SafeFileNames.Length-1; i++)
                {
                    valor++;
                    if (numerico.renome_numerico(caminho, openFileDialog1.SafeFileNames[i], valor, Path.GetExtension(openFileDialog1.SafeFileNames[i])))
                    {
                        novoLog(openFileDialog1.SafeFileNames[i] + mensagens.ReSucess, Color.Green);
                        if (ccontador == true)
                        {
                            quantos = quantos + 1;
                            lb_renome.Invoke((MethodInvoker)delegate { lb_renome.Text = mensagens.LabelRenomes + quantos; });
                        }
                    }
                    else
                    {
                        if(clogs == true)
                        {
                            novoLog(openFileDialog1.SafeFileNames[i] + mensagens.ReFail + " - " + numerico.erro, Color.Red);
                            alimentaGridError(qtderror, openFileDialog1.SafeFileNames[i], numerico.erro, Convert.ToString(valor), Convert.ToString(tamanhomb = (tamanho.Length / 1024f) / 1024f), Path.GetExtension(openFileDialog1.SafeFileNames[i]), Convert.ToString(fileCreateDate = File.GetCreationTime(caminho + openFileDialog1.SafeFileNames[i])));
                            qtderror++;
                        }
                        if (ccontador == true)
                        {
                            falhas++;
                            lb_falha.Invoke((MethodInvoker)delegate { lb_falha.Text = mensagens.LabelFalhas + falhas; });
                        }
                    }
                }
            }

            //por tamanho
            else if (rb_tamanho.Checked)
            {
                modo = lb_tamanho.Text;
                rc_tamanho tamanho = new rc_tamanho();
                string qual = "";
                cb_tamanho.Invoke((MethodInvoker)delegate { qual = cb_tamanho.Text; });
                for (int i = 1; i <= openFileDialog1.SafeFileNames.Length; i++)
                {
                    if (tamanho.renome_tamanho(caminho, openFileDialog1.SafeFileNames[i], Path.GetExtension(openFileDialog1.SafeFileNames[i]), qual))
                    {
                        if (text.IndexOf("CONT = FALSE") == -1)
                        {
                            quantos = quantos + 1;
                            lb_renome.Invoke((MethodInvoker)delegate { lb_renome.Text = mensagens.LabelRenomes + quantos; });
                        }
                        novoLog(openFileDialog1.SafeFileNames[i] + mensagens.ReSucess, Color.Green);
                    }
                    else
                    {
                        if (text.IndexOf("CONT = FALSE") == -1)
                        {
                            falhas++;
                            lb_falha.Invoke((MethodInvoker)delegate { lb_falha.Text = mensagens.LabelFalhas + falhas; });
                        }
                        novoLog(openFileDialog1.SafeFileNames[i] + mensagens.ReFail, Color.Red);
                    }
                }
            }

            //por alfanumerico
            else if (rb_alfa.Checked)
            {
                modo = lb_alfanumerico.Text;
                char texto = "z"[0];
                cb_alfa.Invoke((MethodInvoker)delegate { texto = cb_alfa.Text[0]; });
                char z = "Z"[0];
                decimal numero = nd_alfa.Value;
                rc_alphanumerico alpha = new rc_alphanumerico();
                for (int i = 1; i <= openFileDialog1.SafeFileNames.Length; i++)
                {
                    if (alpha.renome_alphanumerico(caminho, openFileDialog1.SafeFileNames[i], numero, texto, Path.GetExtension(openFileDialog1.SafeFileNames[i])))
                    {
                        if (text.IndexOf("CONT = FALSE") == -1)
                        {
                            quantos = quantos + 1;
                            lb_renome.Invoke((MethodInvoker)delegate { lb_renome.Text = mensagens.LabelRenomes + quantos; });
                        }
                        novoLog(openFileDialog1.SafeFileNames[i] + mensagens.ReSucess, Color.Green);
                        if (texto == z)
                        {
                            numero++;
                            texto = "@"[0];
                        }
                        texto++;
                    }
                    else
                    {
                        if (text.IndexOf("CONT = FALSE") == -1)
                        {
                            falhas++;
                            lb_falha.Invoke((MethodInvoker)delegate { lb_falha.Text = mensagens.LabelFalhas + falhas; });
                        }
                        novoLog(openFileDialog1.SafeFileNames[i] + mensagens.ReFail, Color.Red);
                    }
                }
            }
            //por nome
            else if (rb_nome.Checked)
            {
                modo = lb_nome.Text;
                decimal valor = nd_nome.Value;
                rc_nome nome = new rc_nome();
                for (int i = 1; i <= openFileDialog1.SafeFileNames.Length; i++)
                {
                    valor++;
                    if (nome.renome_nome(caminho, openFileDialog1.SafeFileNames[i], valor, tb_nome.Text, Path.GetExtension(openFileDialog1.SafeFileNames[i])))
                    {
                        if (text.IndexOf("CONT = FALSE") == -1)
                        {
                            quantos = quantos + 1;
                            lb_renome.Invoke((MethodInvoker)delegate { lb_renome.Text = mensagens.LabelRenomes + quantos; });
                        }
                        novoLog(openFileDialog1.SafeFileNames[i] + mensagens.ReSucess, Color.Green);
                    }
                    else
                    {
                        if (text.IndexOf("CONT = FALSE") == -1)
                        {
                            falhas++;
                            lb_falha.Invoke((MethodInvoker)delegate { lb_falha.Text = mensagens.LabelFalhas + falhas; });
                        }
                        novoLog(openFileDialog1.SafeFileNames[i] + mensagens.ReFail, Color.Red);
                    }
                }
            }
            //por data
            else if (rb_data.Checked)
            {
                modo = lb_data.Text;
                string qual = "";
                int controle = 0;
                cb_data.Invoke((MethodInvoker)delegate { qual = cb_data.Text; });
                rc_data data = new rc_data();
                for (int i = 0; i <= openFileDialog1.SafeFileNames.Length - 1; i++)
                {

                    if (data.renomeData(openFileDialog1.FileName.Replace(openFileDialog1.SafeFileNames[0], ""), openFileDialog1.SafeFileNames[i], Path.GetExtension(openFileDialog1.SafeFileNames[i]), qual + "", controle))
                    {
                        if (text.IndexOf("CONT = FALSE") == -1)
                        {
                            quantos = quantos + 1;
                            lb_renome.Invoke((MethodInvoker)delegate { lb_renome.Text = mensagens.LabelRenomes + quantos; });
                        }
                        novoLog(openFileDialog1.SafeFileNames[i] + mensagens.ReSucess, Color.Green);
                    }
                    else
                    {
                        if (text.IndexOf("CONT = FALSE") == -1)
                        {
                            falhas++;
                            lb_falha.Invoke((MethodInvoker)delegate { lb_falha.Text = mensagens.LabelFalhas + falhas; });
                        }
                        novoLog(openFileDialog1.SafeFileNames[i] + mensagens.ReFail, Color.Red);
                    }
                }
            }

            //por tipo
            else if (rb_tipo.Checked)
            {
                modo = lb_data.Text;
                string qual = "";
                cb_tipo.Invoke((MethodInvoker)delegate { qual = cb_tipo.Text; });
                rc_tipo tipo = new rc_tipo();
                for (int i = 1; i <= openFileDialog1.SafeFileNames.Length; i++)
                {
                    if (tipo.renome_tipo(caminho, openFileDialog1.SafeFileNames[i], qual, Path.GetExtension(openFileDialog1.SafeFileNames[i])))
                    {
                        if (text.IndexOf("CONT = FALSE") == -1)
                        {
                            quantos = quantos + 1;
                            lb_renome.Invoke((MethodInvoker)delegate { lb_renome.Text = mensagens.LabelRenomes + quantos; });
                        }
                        novoLog(openFileDialog1.SafeFileNames[i] + mensagens.ReSucess, Color.Green);
                    }
                    else
                    {
                        if (text.IndexOf("CONT = FALSE") == -1)
                        {
                            falhas++;
                            lb_falha.Invoke((MethodInvoker)delegate { lb_falha.Text = mensagens.LabelFalhas + falhas; });
                        }
                        novoLog(openFileDialog1.SafeFileNames[i] + mensagens.ReFail, Color.Red);
                    }
                }
            }
            //aleatorio
            else if (rb_aleatorio.Checked)
            {
                cb_aleatorio.Invoke((MethodInvoker)delegate { modo = cb_aleatorio.Text; });
                rc_aleatorio aleatorio = new rc_aleatorio();
                for (int i = 1; i <= openFileDialog1.SafeFileNames.Length; i++)
                {
                    if (aleatorio.renome_aleatorio(caminho, openFileDialog1.SafeFileNames[i], Path.GetExtension(openFileDialog1.SafeFileNames[i]), modo))
                    {
                        if (text.IndexOf("CONT = FALSE") == -1)
                        {
                            quantos = quantos + 1;
                            lb_renome.Invoke((MethodInvoker)delegate { lb_renome.Text = mensagens.LabelRenomes + quantos; });
                        }
                        novoLog(openFileDialog1.SafeFileNames[i] + mensagens.ReSucess, Color.Green);
                    }
                    else
                    {
                        if (text.IndexOf("CONT = FALSE") == -1)
                        {
                            falhas++;
                            lb_falha.Invoke((MethodInvoker)delegate { lb_falha.Text = mensagens.LabelFalhas + falhas; });
                        }
                        novoLog(openFileDialog1.SafeFileNames[i] + mensagens.ReFail, Color.Red);
                    }
                }

            }
            quants = quantos;
            this.modo = modo;
            finalizacao();
        }

        private void enviaestatic()
        {
            try
            {
                string logaas = "";
                log.Invoke((MethodInvoker)delegate { logaas = log.Text; });
                email email = new email();
                email.enviaEmail(modo, quants, falhas, logaas, text);
            }
            catch
            {

            }
        }
        private void atualizaPermi()
        {
            string text = File.ReadAllText(@".\conf.cf");
            //contador
            if (text.IndexOf("CONT = FALSE") != -1) ccontador = false;
            else ccontador = true;

            //turbo
            if (text.IndexOf("TURBO = FALSE") != -1) cturbo = false;
            else cturbo = true;

            //log
            if (text.IndexOf("LOG = FALSE") != -1) clogs = false;
            else clogs = true;

            //tray
            if (text.IndexOf("TRAY = FALSE") != -1) ctray = false;
            else ctray = true;

            //email
            if (text.IndexOf("EMAIL = FALSE") != -1) cemail = false;
            else cemail = true;
        }

        private void alimentaGridError(int i,string caminho,string erro,string valor,string tamanho, string extension, string criacao)
        {
            griderro[i, 0] = openFileDialog1.SafeFileNames[i];
            griderro[i, 1] = erro;
            griderro[i, 2] = valor;
            griderro[i, 3] = tamanho;
            griderro[i, 4] = extension;
            griderro[i, 5] = criacao;
        }
    }
}
