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
    public partial class ConfigurarConexaoBanco : UserControl, ISetupScreen
    {
        public UserControl CurrentControl
        {
            get
            {
                return this;
            }
        }

        public ConfigurarConexaoBanco()
        {
            InitializeComponent();

            FillCbTypes();
            FillFromLocal();
        }

        private void FillFromLocal()
        {
            DatasourceConfiguration conf = MDFeNetConfig.ReadFromLocal();
            cbTipoBanco.SelectedValue = conf.DataProvider;
            txServidor.Text = conf.Datasource;
            txUsuario.Text = conf.UserId;
            txSenha.Password = conf.Password;
            txNomeBanco.Text = conf.InitialCatalog;
        }

        private void FillCbTypes()
        {
            List<KeyValuePair<DatasourceConfiguration.Provider, string>> dbs = new List<KeyValuePair<DatasourceConfiguration.Provider, string>>();
            dbs.Add(new KeyValuePair<DatasourceConfiguration.Provider, string>(DatasourceConfiguration.Provider.Firebird, "Firebird SQL"));
            dbs.Add(new KeyValuePair<DatasourceConfiguration.Provider, string>(DatasourceConfiguration.Provider.MS_SQL, "MS SQL"));

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

        private DatasourceConfiguration GetConfig()
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

            return conf;
        }

        private void Testar()
        {
            DatasourceConfiguration conf = GetConfig();
            conf.TestConnection();
        }

        public void Save()
        {
            MDFeNetConfig.SaveToLocal(GetConfig());
        }

        public bool IsValid()
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
