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

        public double Width { get; set; } = 160;

        public double Height { get; set; } = 90;

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
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
