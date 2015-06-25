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
        public string UpCancel = "";
        public string UpSucess = "";
        public string ReSucess = "";
        public string ReCancel = "";
        public string ReFail = "";
        public string LogUrl = "";
        public string ErroDoubleArchive = "";
        public string TotalSucess = "";
        public string TotalFail = "";
        public string MinimizeTrayClick = "";
        public string MinimizeTrayFinish = "";
        public string MinimizeTrayTitle1 = "";
        public string MinimizeTrayTitle2 = "";
        public string MinimizeTrayTitle3 = "";
        public string MinimizeTrayTip = "";
        public string LabelCancelar = " ";
        public string LabelIniciar = "";
        public string LabelAbort = "";
        public string LabelCarregar = "";
        public string LabelCarregados = "";
        public string LabelRenomes = "";
        public string LabelFalhas = "";
        public string TitleBoxSucess = "";

        public void qualLang()
        {
            string text;
            text = File.ReadAllText(@".\conf.cf");
            if (text.IndexOf("LANGUE = PTBR") > -1)
            {
                UpCancel = " Carregamento de arquivos cancelado.";
                UpSucess = " Carregado com sucesso.";
                ReSucess = " Renomeado com sucesso.";
                ReCancel = " Ação de renome cancelada.";
                ReFail = " Falha ao renomear o arquivo: ";
                LogUrl = " Pasta: ";
                ErroDoubleArchive = " Arquivo com o mesmo nome já existe na pasta.";
                TotalSucess = " Arquivos renomeados com sucesso.";
                TotalFail = " Arquivos que não foi possivel aplicar o renomeamento.";
                MinimizeTrayClick = " Clique aqui para esconder ou mostrar a janela!!";
                MinimizeTrayFinish = " Ufa, terminamos!!";
                MinimizeTrayTitle1 = " Até cansei...";
                MinimizeTrayTitle2 = " Não se preocupe!!";
                MinimizeTrayTitle3 = " É só clicar!!";
                MinimizeTrayTip = " Nossos Dinossauros treinados estão trabalhando na sua solicitação!";
                LabelCancelar = " CANCELAR";
                LabelIniciar = "INICIAR";
                LabelAbort = "ABORTAR";
                LabelCarregar = "ARQUIVOS CARREGADOS: ";
                LabelCarregados = "CARREGAR ARQUIVOS";
                LabelRenomes = "ARQUIVOS RENOMEADOS: ";
                LabelFalhas = "FALHAS: ";
                TitleBoxSucess = "SUCESSO!!";
            }
            else
            {
                UpCancel = " File upload canceled.";
                UpSucess = " Successfully loaded.";
                ReSucess = " Renamed successfully.";
                ReCancel = " Renowned action canceled.";
                ReFail = " Failed to rename file: ";
                LogUrl = " Paste: ";
                ErroDoubleArchive = " File with the same name already exists in the folder.";
                TotalSucess = " Renamed files successfully.";
                TotalFail = " Files that it was not possible to apply the renaming.";
                MinimizeTrayClick = " Click here to hide or show the window!!";
                MinimizeTrayFinish = " Phew, finished!!";
                MinimizeTrayTitle1 = " until tired...";
                MinimizeTrayTitle2 = " Do not worry!!";
                MinimizeTrayTitle3 = " Just click!!";
                MinimizeTrayTip = " Our trained Dinosaurs are working on your request!";
                LabelCancelar = " CANCEL";
                LabelIniciar = "START";
                LabelAbort = "ABORT";
                LabelCarregar = "FILES LOADED: ";
                LabelCarregados = "LOADING FILES";
                LabelRenomes = "FILES RENAMED: ";
                LabelFalhas = "FAILURES: ";
                TitleBoxSucess = "SUCCESS!!";
            }
        }
    }
}
