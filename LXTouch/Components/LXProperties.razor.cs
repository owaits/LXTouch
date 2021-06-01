using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LXTouch.Components
{
    public partial class LXProperties
    {
        private LXEditor editor = null;

        [CascadingParameter]
        public LXEditor Editor 
        {
            get { return editor; }
            set
            {
                if(editor != value)
                {
                    if (editor != null)
                    {
                        editor.SelectedElementChanged -= Editor_SelectedElementChanged;
                    }
                    editor = value;
                    if(editor != null)
                    {
                        editor.SelectedElementChanged += Editor_SelectedElementChanged;
                    }                   
                }
            }
        }

        private void Editor_SelectedElementChanged(object sender, EventArgs e)
        {
            StateHasChanged();
        }
    }
}
