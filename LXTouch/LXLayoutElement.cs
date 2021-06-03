using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace LXTouch
{
    public enum Style
    {
        Button,
        Fader        
    }

    public class LXLayoutElement:INotifyPropertyChanged
    {
        public Style Style { get; set; }

        public bool SnapGrid { get; set; }

        public double PositionX { get; set; }

        public double PositionY { get; set; }

        private double width = 160;

        public double Width
        {
            get { return width; }
            set
            {
                if(width != value)
                {
                    width = value;
                    RaisePropertyChanged();
                }
            }
        }

        private double height = 90;

        public double Height
        {
            get { return height; }
            set
            {
                if (height != value)
                {
                    height = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string legend;

        public string Legend 
        {
            get { return legend; }
            set
            {
                if(legend != value)
                {
                    legend = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int UserNumber { get; set; } = 1;

        #region Notify Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if(PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
