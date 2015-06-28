using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RenomeArquivo___2._0.formas
{
    public partial class VisuErro : Form
    {
        string[,] griderro;
        public VisuErro(string[,] griderro)
        {
            InitializeComponent();
            this.griderro = griderro;
        }

        private void VisuErro_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= griderro.GetLength(0)-1; i++)
            {
                dg_listaerro.Rows.Add(griderro[i,0],griderro[i,1],griderro[i,2],griderro[i,3],griderro[i,4],griderro[i,5]);
                i++;
            }
        }
    }
}
