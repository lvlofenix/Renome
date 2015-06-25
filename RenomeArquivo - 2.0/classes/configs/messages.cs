using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RenomeArquivo___2._0.formas;
using System.IO;

namespace RenomeArquivo___2._0.classes
{
    class messages
    {
        //Mensagens de LOG
        public string UpCancel = "";
        public string UpSucess = "";
        public string ReSucess = "";
        public string ReCancel = "";
        public string ReFail = "";
        public string LogUrl = "";
        public string ErroDoubleArchive = "";
        public string TotalSucess = "";
        public string TotalFail = "";
        //Mensagens Tray
        public string MinimizeTrayClick = "";
        public string MinimizeTrayFinish = "";
        public string MinimizeTrayTitle1 = "";
        public string MinimizeTrayTitle2 = "";
        public string MinimizeTrayTitle3 = "";
        public string MinimizeTrayTip = "";
        //Labels
        public string LabelCarregados = "";
        public string LabelRenomes = "";
        public string LabelFalhas = "";
        public string TitleBoxSucess = "";
        //Botões Labels
        public string BtLabelCarregar = "";
        public string BtlabelIniciar = "";
        public string BtlabelCancelar = "";
        public string BtlabelAbortar = "";
        public string BtLabelLimpa = "";
        public string BtLabelConfig = "";
        public string BtLabelSobre = "";
        //check
        public string CbLabelNum = "";
        public string CbLabelalpha = "";
        public string CbLabelNome = "";
        public string CbLabelRand = "";
        public string CbLabelData = "";
        public string CbLabelTipo = "";
        public string CbLabelTamn = "";

        public void qualLang()
        {
            string text;
            text = File.ReadAllText(@".\conf.cf");
            if (text.IndexOf("LANGUE = PTBR") > -1)
            {
                //LOG
                UpCancel = " Carregamento de arquivos cancelado.";
                UpSucess = " Carregado com sucesso.";
                ReSucess = " Renomeado com sucesso.";
                ReCancel = " Ação de renome cancelada.";
                ReFail = " Falha ao renomear o arquivo: ";
                LogUrl = " Pasta: ";
                ErroDoubleArchive = " Arquivo com o mesmo nome já existe na pasta.";
                TotalSucess = " Arquivos renomeados com sucesso.";
                TotalFail = " Arquivos que não foi possivel aplicar o renomeamento.";
                //MINE
                MinimizeTrayClick = " Clique aqui para esconder ou mostrar a janela!!";
                MinimizeTrayFinish = " Ufa, terminamos!!";
                MinimizeTrayTitle1 = " Até cansei...";
                MinimizeTrayTitle2 = " Não se preocupe!!";
                MinimizeTrayTitle3 = " É só clicar!!";
                MinimizeTrayTip = " Nossos Dinossauros treinados estão trabalhando na sua solicitação!";
                //BOTOES
                BtlabelCancelar = " CANCELAR";
                BtlabelIniciar = "INICIAR";
                BtlabelAbortar = "ABORTAR";
                BtLabelCarregar = "CARREGAR ARQUIVOS";
                BtLabelLimpa = "LIMPAR CAMPOS E LOGS";
                BtLabelConfig = "CONFIGURAÇÕES";
                BtLabelSobre = "SOBRE";
                //LABELS
                LabelCarregados = "ARQUIVOS CARREGADOS: ";
                LabelRenomes = "ARQUIVOS RENOMEADOS: ";
                LabelFalhas = "FALHAS: ";
                //TITULOS
                TitleBoxSucess = "SUCESSO!!";
                //CHECKS
                CbLabelNum = "NUMÉRICO";
                CbLabelalpha = "ALFANUMÉRICO";
                CbLabelNome = "NOME";
                CbLabelData = "DATA";
                CbLabelTipo = "TIPO";
                CbLabelTamn = "TAMANHO";
                CbLabelRand = "ALEATORIO";
            }
            else
            {
                //LOG
                UpCancel = " File upload canceled.";
                UpSucess = " Successfully loaded.";
                ReSucess = " Renamed successfully.";
                ReCancel = " Renowned action canceled.";
                ReFail = " Failed to rename file: ";
                LogUrl = " Paste: ";
                ErroDoubleArchive = " File with the same name already exists in the folder.";
                TotalSucess = " Renamed files successfully.";
                TotalFail = " Files that it was not possible to apply the renaming.";
                //MINETRAY
                MinimizeTrayClick = " Click here to hide or show the window!!";
                MinimizeTrayFinish = " Phew, finished!!";
                MinimizeTrayTitle1 = " until tired...";
                MinimizeTrayTitle2 = " Do not worry!!";
                MinimizeTrayTitle3 = " Just click!!";
                MinimizeTrayTip = " Our trained Dinosaurs are working on your request!";
                //BOTÕES
                BtlabelCancelar = " CANCEL";
                BtlabelIniciar = "START";
                BtlabelAbortar = "ABORT";
                BtLabelCarregar = "LOAD FILES";
                BtLabelLimpa = "CLEAR CAMPS AND LOGS";
                BtLabelConfig = "CONFIGURE";
                BtLabelSobre = "ABOUT";
                //LABELS
                LabelCarregados = "FILES LOADED: ";
                LabelRenomes = "FILES RENAMED: ";
                LabelFalhas = "FAILURES: ";
                //TITULOS
                TitleBoxSucess = "SUCCESS!!";
                //CHECK
                CbLabelNum = "NUMBER";
                CbLabelalpha = "ALPHANUMERIC";
                CbLabelNome = "NAME";
                CbLabelData = "DATE";
                CbLabelTipo = "TYPE";
                CbLabelTamn = "LEGNTH";
                CbLabelRand = "RANDOM";
            }
        }
    }
}
