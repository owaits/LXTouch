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

        public string Address { get; set; }

        public int Port { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Address = Titan.ConsoleAddress;
            Port = Titan.ConsolePort;

            await Task.CompletedTask;
        }

        protected void Connect()
        {
            Titan.Connect(Address, Port);
        }

        private void Editor_SelectedElementChanged(object sender, EventArgs e)
        {
            StateHasChanged();
        }
    }
}
