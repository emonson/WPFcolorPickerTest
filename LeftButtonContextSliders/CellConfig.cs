using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LeftButtonContextSliders
{
    public class CellConfig : INotifyPropertyChanged
    {
        public CellConfig()
        {
            _Cell_Name = "Default Cell";
            _Cell_Value = 100;
            _R = 0;
            _G = 0;
            _B = 0;
            _H = 0.0;
            _S = 0.0;
            _V = 0.0;
        }

        public CellConfig(string name, ushort init_val)
        {
            _Cell_Name = name;
            _Cell_Value = init_val;
            _R = 0;
            _G = 0;
            _B = 0;
            _H = 0.0;
            _S = 0.0;
            _V = 0.0;
        }

        public string Cell_Name
        {
            get { return _Cell_Name; }
            set
            {
                _Cell_Name = value;
                NotifyPropertyChanged("Cell_Name");
            }
        }

        public ushort Cell_Value
        {
            get { return _Cell_Value; }
            set 
            {
                _Cell_Value = value;
                NotifyPropertyChanged("Cell_Value");
            }
        }

        public byte R
        {
            get { return _R; }
            set
            {
                _R = value;
                NotifyPropertyChanged("R");
                checkHSV();
            }
        }

        public byte G
        {
            get { return _G; }
            set
            {
                _G = value;
                NotifyPropertyChanged("G");
                checkHSV();
            }
        }

        public byte B
        {
            get { return _B; }
            set
            {
                _B = value;
                NotifyPropertyChanged("B");
                checkHSV();
            }
        }

        public Color CellColor
        {
            get { return Color.FromArgb(_R, _G, _B); }
            set 
            {
                if (_R != value.R)
                {
                    _R = value.R;
                    NotifyPropertyChanged("R");
                }
                if (_G != value.G)
                {
                    _G = value.G;
                    NotifyPropertyChanged("G");
                }
                if (_B != value.B)
                {
                    _B = value.B;
                    NotifyPropertyChanged("B");
                }
                checkHSV();
            }
        }

        public double H
        {
            get { return _H; }
            set 
            { 
                _H = value;
                NotifyPropertyChanged("H");
                checkRGB();
            }
        }

        public double S
        {
            get { return _S; }
            set
            {
                _S = value;
                NotifyPropertyChanged("S");
                checkRGB();
            }
        }

        public double V
        {
            get { return _V; }
            set
            {
                _V = value;
                NotifyPropertyChanged("V");
                checkRGB();
            }
        }

        private void checkRGB()
        {
            Color newColor;
            newColor = ColorConv.ColorFromHSV(_H, _S, _V);
            if (_R != newColor.R)
            {
                _R = newColor.R;
                NotifyPropertyChanged("R");
            }
            if (_G != newColor.G)
            {
                _G = newColor.G;
                NotifyPropertyChanged("G");
            }
            if (_B != newColor.B)
            {
                _B = newColor.B;
                NotifyPropertyChanged("B");
            }
        }

        private void checkHSV()
        {
            double h, s, v;
            ColorConv.ColorToHSV(Color.FromArgb(_R, _G, _B), out h, out s, out v);
            if (_H != h)
            {
                _H = h;
                NotifyPropertyChanged("H");
            }
            if (_S != s)
            {
                _S = s;
                NotifyPropertyChanged("S");
            }
            if (_V != v)
            {
                _V = v;
                NotifyPropertyChanged("V");
            }
        }

        private ushort _Cell_Value;
        private string _Cell_Name;
        private byte _R;
        private byte _G;
        private byte _B;
        private double _H;
        private double _S;
        private double _V;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
