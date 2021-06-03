using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LXTouch.Components
{
    public partial class LXElement:IAsyncDisposable
    {
        private LXLayoutElement layout = null;

        [Parameter]
        public LXLayoutElement Layout 
        {
            get { return layout; }
            set
            {
                if(layout != value)
                {
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
            InvokeAsync(() => StateHasChanged());
        }

        public async ValueTask DisposeAsync()
        {
            Layout = null;
            await Task.CompletedTask;
        }
    }
}
