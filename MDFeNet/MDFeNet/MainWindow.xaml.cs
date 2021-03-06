﻿using MDFeNet.DataSources;
using MDFeNet.ViewComponents.ConfiguracaoDataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MDFeNet
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AdicionarConjuntoDados acd = new AdicionarConjuntoDados();
            acd.ShowDialog();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string sql = @"SELECT CNPJ, RAZAO_SOCIAL, NOME_FANTASIA, FROM LOJAS";
            MDFeNetConfig.WriteStatementForModel("Emitente", sql);
        }
    }
}
