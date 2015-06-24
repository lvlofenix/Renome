﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using RenomeArquivo___2._0.classes;
using System.IO;
using RenomeArquivo___2._0.formas;
using RenomeArquivo___2._0.classes.etc;

namespace RenomeArquivo___2._0
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }
        //threads e variaveis globais
        Thread carrega;
        Thread trabalha;
        Thread email;
        int falhas = 0;
        int mil;
        Boolean aviso = false;
        string modo = "";
        int quants = 0;
        int cont = 0;
        string text;
        //MEOTODOS
        //pega o caminho dos arquivosCONF
        [STAThread]
        private void pegaCaminho()
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                alimentador(openFileDialog1.SafeFileNames, openFileDialog1.FileName);
            }
            else
            {
                lb_iniciar.Invoke((MethodInvoker)delegate { lb_iniciar.Enabled = true; });
                Invoke((MethodInvoker)delegate { lb_carrega_arquivos.Enabled = true; });
                Invoke((MethodInvoker)delegate {lb_carrega_arquivos.ForeColor = Color.Navy;});
                Invoke((MethodInvoker)delegate { lb_carrega_arquivos.Text = "CARREGAR ARQUIVOS"; });
                novoLog("CARREGAMENTO DE ARQUIVOS CANCELADO COM SUCESSO!!", Color.Red);
                carrega.Abort();
                limpa();
            }
        }

        //alimenta a lista e as strings de controle
        
        private void alimentador(string[] arquivos, string caminho)
        {
            FileInfo tamanho;
            int quantos=0;
            string url = caminho.Replace(arquivos[0], "");
            //alimenta string do caminho.
            novoLog("Caminho: " + url,Color.Blue);
            dg_lista.Invoke((MethodInvoker)delegate { dg_lista.Rows.Clear(); });
            //alimenta listbox
            for (int i = 0;i<=arquivos.Length-1;i++ )
            {
                tamanho = new FileInfo(url+arquivos[i]);
                float tamanhoMB = (tamanho.Length / 1014f) / 1014f;
                DateTime fileCreateDate = File.GetCreationTime(url+arquivos[i]);
                string data = fileCreateDate + "";
                dg_lista.Invoke((MethodInvoker)delegate { dg_lista.Rows.Add(arquivos[i], tamanhoMB, Path.GetExtension(url+arquivos[i]),data); });
                novoLog("Arquivo " + arquivos[i] + " Carregado com sucesso",Color.Green);
                if (text.IndexOf("CONT = FALSE") == -1)
                {
                    gv_lista.Invoke((MethodInvoker)delegate { gv_lista.Text = "ARQUIVOS CARREGADOS: " + i; });
                    quantos = i;
                }
            }
            if (text.IndexOf("CONT = FALSE") == -1)
            {
                quantos = quantos + 1;
                gv_lista.Invoke((MethodInvoker)delegate { gv_lista.Text = "ARQUIVOS CARREGADOS: " + quantos; });
            }
            mil = quantos;
            lb_iniciar.Invoke((MethodInvoker)delegate { lb_iniciar.Enabled = true; });
            lb_carrega_arquivos.Invoke((MethodInvoker)delegate { lb_carrega_arquivos.Enabled = true; });
            lb_carrega_arquivos.ForeColor = Color.Navy;
            lb_carrega_arquivos.Invoke((MethodInvoker)delegate { lb_carrega_arquivos.Text = "CARREGAR ARQUIVOS"; });
            carrega.Abort();
        }

        //ativa campos
        private void campoSelecionado()
        {
            desativaCampo();
            if (rb_numerico.Checked) { nd_numerico.Enabled = true; modo = "numerico"; }
                else{if (rb_alfa.Checked) { cb_alfa.Enabled = true; nd_alfa.Enabled = true; modo = "alfa"; }
                    else{if (rb_nome.Checked) { tb_nome.Enabled = true; nd_nome.Enabled = true; modo = "nome"; }
                        else{if (rb_data.Checked) { cb_data.Enabled = true; modo = "data"; }
                            else{if (rb_tipo.Checked) { cb_tipo.Enabled = true; modo = "tipo"; }
                                else{if (rb_tamanho.Checked) { cb_tamanho.Enabled = true; modo = "tamanaho"; }
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
            gv_lista.Invoke((MethodInvoker)delegate { gv_lista.Text = "ARQUIVOS CARREGADOS: 0";});
            lb_renome.Invoke((MethodInvoker)delegate { lb_renome.Text = "ARQUIVOS RENOMEADOS: 0";});
            lb_falha.Invoke((MethodInvoker)delegate { lb_falha.Text = "FALHAS: 0"; });
            nd_numerico.Invoke((MethodInvoker)delegate {nd_numerico.Value = 0;});
            nd_alfa.Invoke((MethodInvoker)delegate {nd_alfa.Value = 0;});
            nd_nome.Invoke((MethodInvoker)delegate {nd_nome.Value = 0;});
            cb_alfa.Invoke((MethodInvoker)delegate {cb_alfa.ResetText();});
            pb_barra.Invoke((MethodInvoker)delegate { pb_barra.Value = 0; });
        }

        //faz a verificação de qual modo vai ser e inicia a classe correta
        private void iniciaProcesso()
        {
            //setando variaveis iniciais
            int quantos = 0;
            string modo = "";
            falhas = 0;
            pb_barra.Invoke((MethodInvoker)delegate {pb_barra.Maximum = openFileDialog1.SafeFileNames.Length - 1;});
            string caminho = openFileDialog1.FileName.Replace(openFileDialog1.SafeFileNames[0], "");

            //renomeando de forma numerica
            if (rb_numerico.Checked)
            {
                modo = lb_numerico.Text;
                decimal valor = nd_numerico.Value;
                rc_numerico numerico = new rc_numerico();
                for(int i = 0;i <= openFileDialog1.SafeFileNames.Length-1 ; i++)
                {
                    valor++;
                    if (numerico.renome_numerico(caminho, openFileDialog1.SafeFileNames[i], valor, Path.GetExtension(openFileDialog1.SafeFileNames[i])))
                    {
                        novoLog("Arquivo "+ openFileDialog1.SafeFileNames[i]+" Renomeado com Sucesso!!",Color.Green);
                        if (text.IndexOf("CONT = FALSE") == -1)
                        {
                            quantos = quantos + 1;
                            lb_renome.Invoke((MethodInvoker)delegate { lb_renome.Text = "ARQUIVOS RENOMEADOS: " + quantos; });
                        }
                    }
                    else
                    {
                        novoLog("Arquivo " + openFileDialog1.SafeFileNames[i] + " Falhou",Color.Red);
                        if (text.IndexOf("CONT = FALSE") == -1)
                        {
                            falhas++;
                            lb_falha.Invoke((MethodInvoker)delegate { lb_falha.Text = "FALHAS: " + falhas; });
                        }
                    }
                    if (text.IndexOf("BARRA = FALSE") == -1)
                    {
                        pb_barra.Invoke((MethodInvoker)delegate { pb_barra.Increment(1); });
                    }
                }
            }

            //por tamanho
            else if(rb_tamanho.Checked)
            {
                modo = lb_tamanho.Text;
                rc_tamanho tamanho = new rc_tamanho();
                string qual="";
                cb_tamanho.Invoke((MethodInvoker)delegate{qual = cb_tamanho.Text;});
                for (int i = 0; i <= openFileDialog1.SafeFileNames.Length - 1; i++)
                {
                    if (tamanho.renome_tamanho(caminho, openFileDialog1.SafeFileNames[i], Path.GetExtension(openFileDialog1.SafeFileNames[i]),qual))
                    {
                        if (text.IndexOf("CONT = FALSE") == -1)
                        {
                            quantos = quantos + 1;
                            lb_renome.Invoke((MethodInvoker)delegate { lb_renome.Text = "ARQUIVOS RENOMEADOS: " + quantos; });
                        }
                        novoLog("Arquivo " + openFileDialog1.SafeFileNames[i] + " Renomeado com Sucesso!!", Color.Green);
                    }
                    else
                    {
                        if (text.IndexOf("CONT = FALSE") == -1)
                        {
                            falhas++;
                            lb_falha.Invoke((MethodInvoker)delegate { lb_falha.Text = "FALHAS: " + falhas; });
                        }
                        novoLog("Arquivo " + openFileDialog1.SafeFileNames[i] + " Falhou",Color.Red);
                    }
                    if (text.IndexOf("BARRA = FALSE") == -1)
                    {
                        pb_barra.Invoke((MethodInvoker)delegate { pb_barra.Increment(1); });
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
                pb_barra.Invoke((MethodInvoker)delegate { pb_barra.Increment(1); });
                rc_alphanumerico alpha = new rc_alphanumerico();
                for (int i = 0; i <= openFileDialog1.SafeFileNames.Length - 1; i++)
                {
                    if (alpha.renome_alphanumerico(caminho, openFileDialog1.SafeFileNames[i], numero, texto, Path.GetExtension(openFileDialog1.SafeFileNames[i])))
                    {
                        if (text.IndexOf("CONT = FALSE") == -1)
                        {
                            quantos = quantos + 1;
                            lb_renome.Invoke((MethodInvoker)delegate { lb_renome.Text = "ARQUIVOS RENOMEADOS: " + quantos; });
                        }
                        novoLog("Arquivo " + openFileDialog1.SafeFileNames[i] + " Renomeado com Sucesso!!", Color.Green);
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
                            lb_falha.Invoke((MethodInvoker)delegate { lb_falha.Text = "FALHAS: " + falhas; });
                        }
                        novoLog("Arquivo " + openFileDialog1.SafeFileNames[i] + " Falhou",Color.Red);
                    }
                    if (text.IndexOf("BARRA = FALSE") == -1)
                    {
                        pb_barra.Invoke((MethodInvoker)delegate { pb_barra.Increment(1); });
                    }
                }
            }
            //por nome
            else if (rb_nome.Checked)
            {
                modo = lb_nome.Text;
                decimal valor = nd_nome.Value;
                rc_nome nome = new rc_nome();
                for (int i = 0; i <= openFileDialog1.SafeFileNames.Length - 1; i++)
                {
                    valor++;
                    if (nome.renome_nome(caminho, openFileDialog1.SafeFileNames[i], valor, tb_nome.Text,Path.GetExtension(openFileDialog1.SafeFileNames[i])))
                    {
                        if (text.IndexOf("CONT = FALSE") == -1)
                        {
                            quantos = quantos + 1;
                            lb_renome.Invoke((MethodInvoker)delegate { lb_renome.Text = "ARQUIVOS RENOMEADOS: " + quantos; });
                        }
                        novoLog("Arquivo " + openFileDialog1.SafeFileNames[i] + " Renomeado com Sucesso!!", Color.Green);
                    }
                    else
                    {
                        if (text.IndexOf("CONT = FALSE") == -1)
                        {
                            falhas++;
                            lb_falha.Invoke((MethodInvoker)delegate { lb_falha.Text = "FALHAS: " + falhas; });
                        }
                        novoLog("Arquivo " + openFileDialog1.SafeFileNames[i] + " Falhou",Color.Red);
                    }
                    if (text.IndexOf("BARRA = FALSE") == -1)
                    {
                        pb_barra.Invoke((MethodInvoker)delegate { pb_barra.Increment(1); });
                    }
                }
            }
            //por data
            else if (rb_data.Checked)
            {
                modo = lb_data.Text;
                string qual="";
                int controle = 0;
                cb_data.Invoke((MethodInvoker)delegate { qual = cb_data.Text; });
                rc_data data = new rc_data();
                for (int i = 0; i <= openFileDialog1.SafeFileNames.Length - 1; i++)
                {

                    if (data.renomeData(openFileDialog1.FileName.Replace(openFileDialog1.SafeFileNames[0], ""), openFileDialog1.SafeFileNames[i], Path.GetExtension(openFileDialog1.SafeFileNames[i]), qual+"",controle))
                    {
                        if(text.IndexOf("CONT = FALSE") == -1)
                        {
                            quantos = quantos + 1;
                            lb_renome.Invoke((MethodInvoker)delegate { lb_renome.Text = "ARQUIVOS RENOMEADOS: " + quantos; });
                        }
                        novoLog("Arquivo " + openFileDialog1.SafeFileNames[i] + " Renomeado com Sucesso!!", Color.Green);
                    }
                    else
                    {
                        if (text.IndexOf("CONT = FALSE") == -1)
                        {
                            falhas++;
                            lb_falha.Invoke((MethodInvoker)delegate { lb_falha.Text = "FALHAS: " + falhas; });
                        }
                        novoLog("Arquivo " + openFileDialog1.SafeFileNames[i] + " Falhou",Color.Red);
                    }
                    if (text.IndexOf("BARRA = FALSE") == -1)
                    {
                        pb_barra.Invoke((MethodInvoker)delegate { pb_barra.Increment(1); });
                    }
                }
            }
            else if(rb_tipo.Checked)
            {
                modo = lb_data.Text;
                string qual = "";
                int controle = 0;
                cb_tipo.Invoke((MethodInvoker)delegate { qual = cb_tipo.Text; });
                rc_tipo tipo = new rc_tipo();
                for (int i = 0; i <= openFileDialog1.SafeFileNames.Length - 1; i++)
                {
                    if (tipo.renome_tipo(caminho, openFileDialog1.SafeFileNames[i], qual, Path.GetExtension(openFileDialog1.SafeFileNames[i])))
                    {
                        if (text.IndexOf("CONT = FALSE") == -1)
                        {
                            quantos = quantos + 1;
                            lb_renome.Invoke((MethodInvoker)delegate { lb_renome.Text = "ARQUIVOS RENOMEADOS: " + quantos; });
                        }
                        novoLog("Arquivo " + openFileDialog1.SafeFileNames[i] + " Renomeado com Sucesso!!", Color.Green);
                    }
                    else
                    {
                        if (text.IndexOf("CONT = FALSE") == -1)
                        {
                            falhas++;
                            lb_falha.Invoke((MethodInvoker)delegate { lb_falha.Text = "FALHAS: " + falhas; });
                        }
                        novoLog("Arquivo " + openFileDialog1.SafeFileNames[i] + " Falhou",Color.Red);
                    }
                    if (text.IndexOf("BARRA = FALSE") == -1)
                    {
                        pb_barra.Invoke((MethodInvoker)delegate { pb_barra.Increment(1); });
                    }
                }
            }
            else if (rb_aleatorio.Checked)
            {
                cb_aleatorio.Invoke((MethodInvoker)delegate { modo = cb_aleatorio.Text; });
                rc_aleatorio aleatorio = new rc_aleatorio();
                for (int i = 0; i <= openFileDialog1.SafeFileNames.Length - 1; i++)
                {
                    if (aleatorio.renome_aleatorio(caminho, openFileDialog1.SafeFileNames[i], Path.GetExtension(openFileDialog1.SafeFileNames[i]),modo))
                    {
                        if (text.IndexOf("CONT = FALSE") == -1)
                        {
                            quantos = quantos + 1;
                            lb_renome.Invoke((MethodInvoker)delegate { lb_renome.Text = "ARQUIVOS RENOMEADOS: " + quantos; });
                        }
                        novoLog("Arquivo " + openFileDialog1.SafeFileNames[i] + " Renomeado com Sucesso!!", Color.Green);
                    }
                    else
                    {
                        if (text.IndexOf("CONT = FALSE") == -1)
                        {
                            falhas++;
                            lb_falha.Invoke((MethodInvoker)delegate { lb_falha.Text = "FALHAS: " + falhas; });
                        }
                        novoLog("Arquivo " + openFileDialog1.SafeFileNames[i] + " Falhou",Color.Red);
                    }
                    if (text.IndexOf("BARRA = FALSE") == -1)
                    {
                        pb_barra.Invoke((MethodInvoker)delegate { pb_barra.Increment(1); });
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
                email email = new email();
                string corpo = log.Text.Replace(")",")<p>");
                corpo = corpo.Replace("Caminho: ", "<FONT COLOR=#000080> Caminho: </FONT>");
                corpo = corpo.Replace("Arquivo", "<FONT COLOR=#4682B4>Arquivo</FONT>");
                corpo = corpo.Replace("||", "<FONT COLOR=#800000>||</FONT>");
                corpo = corpo.Replace("Falhou", "<FONT COLOR=#FF0000>Falhou</FONT>");
                corpo = corpo.Replace(" Renomeado com Sucesso!!", "<FONT COLOR=#008000> Renomeado com Sucesso!!</FONT>");
                email.enviaEmail(modo, quants, falhas, corpo, text);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //AÇÃO DOS BOTOES
        //inicia o processo
        private void lb_iniciar_Click(object sender, EventArgs e)
        {
            text = File.ReadAllText(@".\conf.cf");
            if (dg_lista.RowCount < 2)
            {
            }
            else
            {
                iniciandoTrabalhos();
            }
        }

        public void iniciandoTrabalhos()
        {
            if (lb_iniciar.Text == "INICIAR")
            {
                gb_opcoes.Enabled = false;
                trabalha = new Thread(iniciaProcesso);
                trabalha.Start();
                lb_iniciar.Text = "ABORTAR";
                lb_iniciar.ForeColor = Color.Red;
                if (mil > 999 & text.IndexOf("TRAY = TRUE") == -1)
                {
                    notifyIcon1.Visible = true;
                    this.Visible = false;
                    notifyIcon1.BalloonTipText = "Nossos Dinossauros treinados estão trabalhando na sua solicitação!";
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon1.BalloonTipTitle = "Não se preocupe!";
                    notifyIcon1.ShowBalloonTip(500);
                }
                
            }
            else
            {
                
                limpa();
                gb_opcoes.Invoke((MethodInvoker)delegate { gb_opcoes.Enabled = true; });
                lb_iniciar.Invoke((MethodInvoker)delegate { lb_iniciar.Text = "INICIAR"; });
                lb_iniciar.Invoke((MethodInvoker)delegate { lb_iniciar.ForeColor = Color.Green; });
                trabalha.Abort();
            }
        }

        //carrega arquivos
        private void lb_carrega_arquivos_Click(object sender, EventArgs e)
        {
            text = File.ReadAllText(@".\conf.cf");
            if (lb_carrega_arquivos.Text == "CARREGAR ARQUIVOS")
            {
                lb_carrega_arquivos.Text = "CANCELAR";
                lb_carrega_arquivos.ForeColor = Color.Red;
                carrega = new Thread(pegaCaminho);
                carrega.ApartmentState = ApartmentState.STA;
                carrega.Start();
                lb_iniciar.Enabled = false;
            }
            else
            {
                lb_carrega_arquivos.ForeColor = Color.Navy;
                lb_carrega_arquivos.Text = "CARREGAR ARQUIVOS";
                lb_iniciar.Enabled = true;
                novoLog("CARREGAMENTO DE ARQUIVOS CANCELADO COM SUCESSO!!",Color.Red);
                carrega.Abort();
                limpa();
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
            if(text.IndexOf("LOG = TRUE") == -1)
            {
            }
            else 
            {
            cont++;
            novo = Environment.NewLine + cont + " > " + novo;
            log.Invoke((MethodInvoker)delegate { log.AppendText(novo); });
            log.Invoke((MethodInvoker)delegate { log.SelectionStart = log.Text.Length; });
            log.Invoke((MethodInvoker)delegate { log.SelectionLength = log.Text.Length+1; });
            log.Invoke((MethodInvoker)delegate { log.SelectionColor = Color.Black; });
            log.Invoke((MethodInvoker)delegate { log.AppendText(" || (" + DateTime.Now + ")"); });
            log.Invoke((MethodInvoker)delegate { log.SelectionColor = cor; });
            log.Invoke((MethodInvoker)delegate { log.ScrollToCaret() ; });
            }

        }

        private void label16_Click(object sender, EventArgs e)
        {
            cont = 0;
            log.Invoke((MethodInvoker)delegate { log.Text = ""; });
        }

        private void finalizacao()
        {
            notifyIcon1.BalloonTipText = "Ufa, terminamos!";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipTitle = "Até cansei...";
            notifyIcon1.ShowBalloonTip(500);
            this.Invoke((MethodInvoker)delegate { this.Visible = true; });
            MessageBox.Show("Um total de " + quants + " arquivos renomeados", "SUCESSO!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            email = new Thread(enviaestatic);
            email.Start();
            iniciandoTrabalhos();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.Visible == true)
            {
                this.Visible = false;
            }
            else
            {
                this.Visible = true;
                notifyIcon1.Visible = false;
                if (aviso == false)
                {
                    notifyIcon1.BalloonTipText = "Clique aqui para esconder a janela novamente!";
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon1.BalloonTipTitle = "É só clicar!";
                    notifyIcon1.ShowBalloonTip(500);
                    aviso = true;
                }               
            }
        }

        private void Index_Load(object sender, EventArgs e)
        {
            nd_numerico.Value = 0;
            cb_alfa.Text = "A";
            nd_alfa.Value = 0;
            tb_nome.Enabled = false;
            nd_nome.Value = 0;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (aviso)
            {
                notifyIcon1.BalloonTipText = "Eu estou aqui!!";
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.BalloonTipTitle = "Não se preocupe!";
                notifyIcon1.ShowBalloonTip(500);
            }
            else
            {

            }
            notifyIcon1.Visible = true;
            this.Visible = false;
        }

        private void lb_sobre_Click(object sender, EventArgs e)
        {
            AboutBox sobre = new AboutBox();
            sobre.Show();
        }
    }
}
