using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
   


using Xamarin.Forms;

namespace XamlTagApp
{
    public partial class Child2Page : ContentPage
    {
        private ObservableCollection<string> msgList = new ObservableCollection<string>();

        public Child2Page()
        {
            InitializeComponent();
            Title = "message";
            msgListView.ItemsSource = msgList;
        }

        void OnSendTapped(object sender, EventArgs args)
        {
            if (msgEntry.Text != null && msgEntry.Text.Length > 0)
            {
                msgList.Add(msgEntry.Text);
                msgEntry.Text = "";
            }

        }
    }
}
