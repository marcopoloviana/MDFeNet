using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDFeNet.ViewComponents.Messages
{
    public class MsgBox
    {
        public static void SimpleText(string text)
        {
            new TextMessageBox(text).ShowDialog();
        }
    }
}
