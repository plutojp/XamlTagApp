using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XamlTagApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new CalcPage();
            //MainPage = new ListViewPage1();
            //MainPage = new XamlTagApp.MainPage();
            //Master Detail Page に関しては調査中
            //MainPage = new XamlTagApp.MasterDetailPage11();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
