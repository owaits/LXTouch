using LXProtocols.AvolitesWebAPI.Blazor;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LXTouch.Components
{
    public partial class LXConnection
    {
        [Inject]
        public IAvolitesTitan Titan { get; set; }

        public string Address
        {
            get { return Titan.ConsoleAddress;  }
            set { Titan.ConsoleAddress = value; }                
        }

        public int Port
        {
            get { return Titan.ConsolePort; }
            set { Titan.ConsolePort = value; }
        }

        private void Editor_SelectedElementChanged(object sender, EventArgs e)
        {
            StateHasChanged();
        }
    }
}
