using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LeftButtonContextSliders
{
    public class MyContextMenu : ContextMenu
    {
        public MyContextMenu()
        {
            // NameScope.SetNameScope(this, new NameScope());
            _A_Value = 100;
        }

        /// <summary>
        /// retrieve/set the cell's standard fit description
        /// </summary>
        public byte A_Value
        {
            get { return _A_Value; }
            set { _A_Value = value; }
        }

        public static byte _A_Value;
    }
}
