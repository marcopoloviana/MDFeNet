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
        List<ISetupScreen> SetupControls { get; set; }
        int CurrentSetup { get; set; }
        public AdicionarConjuntoDados()
        {
            InitializeComponent();

            CurrentSetup = -1;
            SetupControls = new List<ISetupScreen>();
            SetupControls.Add(new ConfigurarConexaoBanco());
            SetupControls.Add(new ConfigurarStatements());

            Next();
        }

        private void Next()
        {
            try
            {
                SetupControls[CurrentSetup].Save();
            }
            catch { }

            if ((CurrentSetup + 2) >= SetupControls.Count)
                btSalvar.IsEnabled = true;
            else
                btSalvar.IsEnabled = false;
               
            if ((CurrentSetup + 1) >= SetupControls.Count)
                return;

            CurrentSetup += 1;
            ShowCurrentSetup();
        }

        private void ShowCurrentSetup()
        {
            GridContainer.Children.Clear();
            GridContainer.Children.Add(SetupControls[CurrentSetup].CurrentControl);
        }

        private void Prev()
        {
            btSalvar.IsEnabled = false;
            if ((CurrentSetup - 1) < 0)
                return;

            CurrentSetup -= 1;
            ShowCurrentSetup();
        }

        private void GridTitulo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btAvancar_Click(object sender, RoutedEventArgs e)
        {
            Next();
        }

        private void btAnterior_Click(object sender, RoutedEventArgs e)
        {
            Prev();
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetupControls[CurrentSetup].Save();
            }
            catch { }

            Close();
        }
    }
}
