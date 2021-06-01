using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LXTouch
{
    public class LXLayout:INotifyPropertyChanged
    {
        
        public double Width { get; set; } = 1600;

        public double Height { get; set; } = 900;

        [JsonIgnore]
        public Color BackgroundColour { get; set; } = Color.FromArgb(255,255,255,255);

        public string BackgroundColourSerialize { get { return ColorTranslator.ToHtml(BackgroundColour); } set { BackgroundColour = ColorTranslator.FromHtml(value); } }

        public bool SnapToGrid { get; set; } = true;

        public double GridSize { get; set; } = 20;

        private List<LXLayoutElement> elements = new List<LXLayoutElement>();

        public IEnumerable<LXLayoutElement> Elements
        {
            get { return elements; }
            set { elements.AddRange(value); }
        }

        public void AddElement(LXLayoutElement element)
        {
            elements.Add(element);
            RaisePropertyChanged("Elements");
        }

        public void RemoveElement(LXLayoutElement element)
        {
            elements.Remove(element);
            RaisePropertyChanged("Elements");
        }

        #region Notify Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


    }
}
