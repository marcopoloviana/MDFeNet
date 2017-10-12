using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MDFeNet.ViewComponents.ConfiguracaoDataSource
{
    /// <summary>
    /// Lógica interna para AdicionarConjuntoDados.xaml
    /// </summary>
    public partial class AdicionarConjuntoDados : Window
    {
        public AdicionarConjuntoDados()
        {
            InitializeComponent();

            GridContainer.Children.Add(new ConfigurarConexaoBanco());
        }

        private void GridTitulo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
