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

namespace MDFeNet.ViewComponents.Messages
{
    /// <summary>
    /// Lógica interna para TextMessageBox.xaml
    /// </summary>
    public partial class TextMessageBox : Window
    {
        public TextMessageBox(string text)
        {
            InitializeComponent();

            textBlock.Text = text;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
