using Blazored.LocalStorage;
using LXProtocols.AvolitesWebAPI.Blazor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace LXTouch
{
    public class LXLayoutService:INotifyPropertyChanged
    {
        private ILocalStorageService localStorage = null;
        private IAvolitesTitan titan = null;

        public LXLayoutService(ILocalStorageService LocalStorage,IAvolitesTitan titan)
        {
            localStorage = LocalStorage;
            this.titan = titan;
        }

        public async Task InitialiseAsync()
        {
            await LoadLayout();  
        }

        private LXLayout currentLayout = null;

        public LXLayout CurrentLayout 
        {
            get { return currentLayout; }
            set
            {
                if(currentLayout != value)
                {
                    if (currentLayout != null)
                    {
                        currentLayout.PropertyChanged -= CurrentLayout_PropertyChanged;
                    }
                    currentLayout = value;
                    if(currentLayout != null)
                    {
                        currentLayout.PropertyChanged += CurrentLayout_PropertyChanged;
                    }
                }
            }
        }

        private void CurrentLayout_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(PropertyChanged != null) PropertyChanged(sender, e);
        }

        #region Save and Load

        public async Task NewLayout()
        {
            CurrentLayout = new LXLayout();
        }

        public async Task LoadLayout()
        {
            CurrentLayout = await localStorage.GetItemAsync<LXLayout>("LXLayout:current") ?? new LXLayout();
            string address  = await localStorage.GetItemAsync<string>("Titan:ipAddress");// IPAddress.Parse(await localStorage.GetItemAsync<string>("Titan:ipAddress") ?? IPAddress.Loopback.ToString());
            int port = await localStorage.GetItemAsync<int?>("Titan:port") ?? 4430;

            titan.Connect(address,port);
        }

        public async Task SaveLayout()
        {
            await localStorage.SetItemAsync("LXLayout:current", CurrentLayout);
            await localStorage.SetItemAsync("Titan:ipAddress", titan.ConsoleAddress.ToString());
            await localStorage.SetItemAsync("Titan:port", titan.ConsolePort);
        }

        #endregion

        #region Notify Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
