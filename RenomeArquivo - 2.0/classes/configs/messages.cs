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
        public string MinimizeTrayFinish = "";
        public string MinimizeTrayTitle1 = "";
        public string MinimizeTrayTitle2 = "";
        public string MinimizeTrayTip = "";
        //Labels
        public string LabelCarregados = "";
        public string LabelRenomes = "";
        public string LabelFalhas = "";
        public string TitleBoxSucess = "";
        public string LabelInicio = "";
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
        //GRIDS
        public string GvLabelNome = "";
        public string GvLabelTamanho = "";
        public string GvLabelTipo = "";
        public string GvLabelData = "";
        //DIVS
        public string Gopcoes = "";
        public string Gacao = "";
        public string Glog = "";
        //configurações
        public string LabelConfig = "";
        public string Gopsvisu = "";
        public string Labelativacont = "";
        public string LabelGeraLog = "";
        public string LabelAtivBarra = "";
        public string LabelDesamini = "";
        public string Gferra = "";
        public string LabelEnvia = "";
        public string LabelAtul = "";
        public string GLangu = "";
        public string LabelPortu = "";
        public string LabelUs = "";
        public string LabelRela = "";
        //text box
        public string TbDuvajud = "";
        public string TbDuvVisu = "";
        public string TbDuvTitle = "";
        //members list box
        public string MlDateI = "";
        public string MlDateII = "";
        public string MlRandI = "";
        public string MlRandII = "";
        public string MlRandIII = "";
        public string MlTamaKb = "";
        public string MlTamaMb = "";
        public string MlTipI = "";
        public string MlTipII = "";
        //traducao alert
        public string Mbstradu = "";



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
                //MinimizeTrayClick = " Clique aqui para esconder ou mostrar a janela!!";
                MinimizeTrayFinish = " Ufa, terminamos!!";
                MinimizeTrayTitle1 = " Até cansei...";
                MinimizeTrayTitle2 = " Não se preocupe!!";
                //MinimizeTrayTitle3 = " É só clicar!!";
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
                LabelInicio = "inicio: ";
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
                //GRIDS
                //DIVS
                Gopcoes = "OPÇÕES";
                Gacao = "AÇÃO";
                Glog = "LOGS";
                //configurações
                LabelConfig = "CONFIGURAÇÕES";
                Gopsvisu = "Opções Visuais";
                Labelativacont = "Ativa contadores";
                LabelGeraLog = "Gerar logs";
                LabelAtivBarra = "Ativar barra de progresso";
                LabelDesamini = "Ativar minimização automatica";
                Gferra = "Ferramentas";
                LabelEnvia = "Enviar estatísticas de forma anonima";
                LabelAtul = "Verificar atualizações";
                GLangu = "Idioma";
                LabelPortu = "Portugues Brasil";
                LabelUs = "Ingles";
                LabelRela = "Ativar relatório de erros.";
                //text box
                TbDuvajud = "Envia informações de uso do software de forma anonima para ajudar a identificar problemas e melhorias.";
                TbDuvTitle = "Posso ajudar??";
                TbDuvVisu = "A desativação dos retornos visuais fazem o software trabalhar mais rápido.";
                //members list box
                MlDateI = "DE CRIAÇÃO: DD-MM-AAAA";
                MlDateII = "DE CRIAÇÃO:  DD-MM-AA HH:MM:SS";
                MlRandI = "NUMEROS";
                MlRandII = "LETRAS";
                MlRandIII = "NUMEROS E LETRAS";
                MlTamaKb = "KB'S";
                MlTamaMb = "MB'S";
                MlTipI = "MODO GENERICO";
                MlTipII = "COMPLETO";
                //messagebox
                Mbstradu = "Reinicie o software para aplicar as alterações.";
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
                //MinimizeTrayClick = " Click here to hide or show the window!!";
                MinimizeTrayFinish = " Phew, finished!!";
                MinimizeTrayTitle1 = " until tired...";
                MinimizeTrayTitle2 = " Do not worry!!";
                //MinimizeTrayTitle3 = " Just click!!";
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
                LabelInicio = "start:";
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
                //GRIDS
                //DIVS
                Gopcoes = "OPTIONS";
                Gacao = "ACTION";
                Glog = "LOGS";
                //configurações
                LabelConfig = "SETTINGS";
                Gopsvisu = "Visual options";
                Labelativacont = "Active counters";
                LabelGeraLog = "Generate logs";
                LabelAtivBarra = "Enable progress bar";
                LabelDesamini = "Automatic minimization";
                Gferra = "Tools";
                LabelEnvia = "Send statistics anonymous way";
                LabelAtul = "Check for Updates";
                GLangu = "Language";
                LabelPortu = "Portuguese Brazil";
                LabelUs = "Ingles";
                LabelRela = "Enable error reporting.";
                //text box
                TbDuvajud = "Send usage information from anonymous way software to help identify problems and improvements.";
                TbDuvTitle = "Help-me!!";
                TbDuvVisu = "Disabling the visual returns make the software work faster.";
                //members list box
                MlDateI = "CREATION: DD-MM-YYYY";
                MlDateII = "CREATION: DD-MM-YY HH: MM: SS";
                MlRandI = "NUMBERS";
                MlRandII = "LETTERS";
                MlRandIII = "NUMBERS AND LETTERS";
                MlTamaKb = "KB'S";
                MlTamaMb = "MB'S";
                MlTipI = "GENERAL WAY";
                MlTipII = "COMPLETE";
                //messagebox
                Mbstradu = "Restart software to apply the changes.";
            }
        }
    }
}
