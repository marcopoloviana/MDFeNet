using MDFeNet.DataSources;
using MDFeNet.ViewComponents.Messages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MDFeNet.ViewComponents.ConfiguracaoDataSource
{
    /// <summary>
    /// Interação lógica para ConfigurarConexaoBanco.xam
    /// </summary>
    public partial class ConfigurarConexaoBanco : UserControl
    {
        public ConfigurarConexaoBanco()
        {
            InitializeComponent();

            FillCbTypes();
        }

        private void FillCbTypes()
        {
            List<KeyValuePair<DatasourceConfiguration.Provider, string>> dbs = new List<KeyValuePair<DatasourceConfiguration.Provider, string>>();
            dbs.Add(new KeyValuePair<DatasourceConfiguration.Provider, string>(DatasourceConfiguration.Provider.Firebird, "Firebird SQL"));

            cbTipoBanco.ItemsSource = dbs;
            cbTipoBanco.DisplayMemberPath = "Value";
            cbTipoBanco.SelectedValuePath = "Key";
            cbTipoBanco.SelectedIndex = 0;
        }

        private void btTestarConexao_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Testar();
                MsgBox.SimpleText("Conexão OK");
            }
            catch(Exception ex)
            {
                MsgBox.SimpleText(ex.Message);
            }
        }

        private void Testar()
        {
            DatasourceConfiguration conf = new DatasourceConfiguration();
            conf.DataProvider = (DatasourceConfiguration.Provider)cbTipoBanco.SelectedValue;
            conf.Datasource = (txServidor.Text.Contains(":")
                ? txServidor.Text.Split(':')[0]
                : txServidor.Text);
            conf.Port = (txServidor.Text.Contains(":")
                ? int.Parse(txServidor.Text.Split(':')[1])
                : 0);
            conf.UserId = txUsuario.Text;
            conf.Password = txSenha.Password;
            conf.InitialCatalog = txNomeBanco.Text;

            conf.TestConnection();
        }

        public bool Valid()
        {
            try
            {
                Testar();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
