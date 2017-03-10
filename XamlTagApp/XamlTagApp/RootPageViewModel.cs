using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.ComponentModel;

using Xamarin.Forms;

namespace XamlTagApp
{
    // public class RootPageViewModel : INotifyPropertyChanged

    public class RootPageViewModel : INotifyPropertyChanged
    {
        //public ObservableCollection<MainMenuItem> Menus { get; } = new ObservableCollection<MainMenuItem>
        //{
        //    new MainMenuItem {MenuTitle="Sub1",PageName="Sub1Page" },
        //    new MainMenuItem {MenuTitle="Sub2",PageName="Sub2Page" },
        //    new MainMenuItem {MenuTitle="Sub3",PageName="Sub3Page" },
        //    new MainMenuItem {MenuTitle="Sub4",PageName="Sub4Page" },
        //    new MainMenuItem {MenuTitle="Sub5",PageName="Sub5Page" },
        //    new MainMenuItem {MenuTitle="Sub6",PageName="Sub6Page" },
        //    new MainMenuItem {MenuTitle="Sub7",PageName="Sub7Page" },

        //};

        //private INavigationService NavigationService { get; }
        //private bool isPresented;
        //public bool IsPresented
        //{
        //    get { return this.isPresented; }
        //    set { this.SetProperty(ref this.isPresented, value); }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        //public RootPageViewModel()
        //{
        //    this.NavigationService = navigationService;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="menuItem"></param>
        ///// <returns></returns>
        //public async Task PageChangeAsync(MenuItem menuItem)
        //{
        //    await this.NavigationService.Navigate($"NavigationPage/{menuItem.PageName}");
        //    this.IsPresented = false;
        //}
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
