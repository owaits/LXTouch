using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LXTouch.Components
{
    public partial class LXDashboard
    {
        [CascadingParameter]
        public LXEditor Editor { get; set; }

        private LXLayoutService layout = null;

        [Inject]
        public LXLayoutService Layout 
        {
            get { return layout; }
            set
            {
                if(layout != value)
                {
                    if (layout != null)
                    {
                        layout.PropertyChanged -= Layout_PropertyChanged;
                    }
                    layout = value;
                    if(layout != null)
                    {
                        layout.PropertyChanged += Layout_PropertyChanged;
                    }
                }
            }
        }

        private void Layout_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            StateHasChanged();
        }
    }
}
