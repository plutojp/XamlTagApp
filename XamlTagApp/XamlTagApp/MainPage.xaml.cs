using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamlTagApp
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            //InitializeComponent();
            Children.Add(new Child1Page() {
                BackgroundColor = Color.FromHex("666666"),
            });

            Children.Add(new Child2Page() { BackgroundColor = Color.FromHex("666666")});
        }
    }
}
