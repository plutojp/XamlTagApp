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
        //private ObservableCollection<string> msgList = new ObservableCollection<string>();
        private ObservableCollection<ListItem> msgList = new ObservableCollection<ListItem>();

        public Child2Page()
        {
            InitializeComponent();
            Title = "message";
            msgListView.ItemsSource = msgList;
            //this.BindingContext = msgList;
            //InitializeComponent();
            //Editor edt = new Editor() { BackgroundColor = "Black", Padding = "1"  };

        }

        void OnSendTapped(object sender, EventArgs args)
        {

            try {
         
                if (msgEntry.Text != null && msgEntry.Text.Length > 0)
                {
                    msgList.Add(new ListItem{ TextItem= msgEntry.Text, DetailItem = editor.Text});
                    //msgList.Add(msgEntry.Text);

                    msgEntry.Text = "";
                    editor.Text = "";

                }

            } catch (Exception e){
                //System.Diagnostics.Debug.WriteLine("\n\n\n※※※※※※※※※※※※※※※※※※※※※※※※※※※※※\n\n\n");
                //System.Diagnostics.Debug.WriteLine("※※※※※※ stack trace※※※※※※: \n" + e.StackTrace);
                //System.Diagnostics.Debug.WriteLine("\n\n\n※※※※※※※※※※※※※※※※※※※※※※※※※※※※※\n\n\n");
                System.Diagnostics.Debug.WriteLine("message: " + e.Message);

            }
            

        }
    }
}
