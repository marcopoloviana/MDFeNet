using MDFeNet.DataSources;
using MDFeNet.ViewComponents.Messages;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interação lógica para ConfigurarStatements.xam
    /// </summary>
    public partial class ConfigurarStatements : UserControl, ISetupScreen
    {
        private List<ModelStatement> Statements { get; set; }

        public UserControl CurrentControl
        {
            get
            {
                return this;
            }
        }

        public ConfigurarStatements()
        {
            InitializeComponent();

            Statements = new List<ModelStatement>();
            FillListBox();

            AplicarPadroesDataGrid();
        }

        private void AplicarPadroesDataGrid()
        {
            dataGrid.AutoGenerateColumns = true;
            dataGrid.IsReadOnly = true;
            dataGrid.RowBackground = (Brush)new BrushConverter().ConvertFrom("#FFFDFDFD");
            dataGrid.CanUserDeleteRows = true;
            dataGrid.CanUserAddRows = false;
            dataGrid.CanUserResizeRows = false;
            dataGrid.SelectionMode = DataGridSelectionMode.Single;
            dataGrid.SelectionUnit = DataGridSelectionUnit.FullRow;
            dataGrid.FontSize = 15;
            dataGrid.MinRowHeight = 27;
            dataGrid.Cursor = Cursors.Hand;
            dataGrid.HorizontalGridLinesBrush = Brushes.LightGray;
            dataGrid.VerticalGridLinesBrush = Brushes.LightGray;
            dataGrid.FontSize = 15;
            dataGrid.MinRowHeight = 20;
            dataGrid.AlternatingRowBackground = Brushes.Lavender;
        }

        private void FillListBox()
        {
            /*
Emitente
Motorista
Veiculo
Autorizado ( pode ser inserido na hora tbm)
NFeVinculada ( chaves de acesso escolhidas de uma listagem de notas do banco)
a classe IdeMDFe tem algumas propriedqades q vem do bd e outras nao

    */

            Statements.Add(new ModelStatement("Emitente", MDFeNetConfig.ReadStatementForModel("Emitente")));
            Statements.Add(new ModelStatement("Motorista", MDFeNetConfig.ReadStatementForModel("Motorista")));
            Statements.Add(new ModelStatement("Veiculo", MDFeNetConfig.ReadStatementForModel("Veiculo")));
            Statements.Add(new ModelStatement("Autorizado", MDFeNetConfig.ReadStatementForModel("Autorizado")));
            Statements.Add(new ModelStatement("NFeVinculada", MDFeNetConfig.ReadStatementForModel("NFeVinculada")));

            listBox.ItemsSource = Statements;
            listBox.SelectedIndex = 0;
        }

        public bool IsValid()
        {
            return false;
        }

        public void Save()
        {
            foreach (ModelStatement ms in Statements)
                MDFeNetConfig.WriteStatementForModel(ms.ModelName, ms.Statement);
        }

        private void btExecutar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DatasourceConfiguration conf = MDFeNetConfig.ReadFromLocal();
                DataTable dt = conf.RetrieveDataFromSql(txSQL.Text);
                dataGrid.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MsgBox.SimpleText(ex.Message);
            }
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ModelStatement ms = (ModelStatement)listBox.SelectedValue;
            if (ms == null)
                return;

            txSQL.Text = ms.Statement;
        }

        private void txSQL_TextChanged(object sender, TextChangedEventArgs e)
        {
            ModelStatement ms = (ModelStatement)listBox.SelectedValue;
            if (ms == null)
                return;

            ms.Statement = txSQL.Text;
        }
    }

    public class ModelStatement
    {
        public string ModelName { get; set; }
        public string Statement { get; set; }

        public ModelStatement(string name, string stmt)
        {
            ModelName = name;
            Statement = stmt;
        }
    }
}
