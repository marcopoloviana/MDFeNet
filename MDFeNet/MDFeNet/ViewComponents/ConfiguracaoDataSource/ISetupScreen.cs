using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace MDFeNet.ViewComponents.ConfiguracaoDataSource
{
    public interface ISetupScreen
    {
        UserControl CurrentControl { get; }
        bool IsValid();
        void Save();
    }
}
