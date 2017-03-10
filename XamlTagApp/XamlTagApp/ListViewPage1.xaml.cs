using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlTagApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage1 : ContentPage
    {
        public static int id = 0;
        //private ObservableCollection<string> msgList = new ObservableCollection<string>();
        private ObservableCollection<ListItem> msgList = new ObservableCollection<ListItem>();

        ~ListViewPage1()
        {
            System.Diagnostics.Debug.WriteLine("※※※※※※　Child2Page OUT ※※※※※※※※※※※");
        }
        public ListViewPage1()
        {
            InitializeComponent();
            Title = "message";
            msgListView.ItemsSource = msgList;
            System.Diagnostics.Debug.WriteLine("※※※※※※　Child2Page On ※※※※※※※※※※※");
            //this.BindingContext = msgList;
            //InitializeComponent();
            //Editor edt = new Editor() { BackgroundColor = "Black", Padding = "1"  };

        }

        void OnSendTapped(object sender, EventArgs args)
        {
            System.Diagnostics.Debug.WriteLine("OnSendTapped: ");
            try
            {

                if (msgEntry.Text != null && msgEntry.Text.Length > 0)
                {

                    string editorStr = editor.Text;
                    string summaryStr = editor.Text.Substring(0, (editorStr.Length > 10) ? 10 : editorStr.Length);
                    msgList.Add(new ListItem { TextItem = msgEntry.Text, SummaryItem = summaryStr, DetailItem = editorStr, YyyyMMddItem = DateTime.Now.ToString() });
                    //msgList.Add(msgEntry.Text);

                    msgEntry.Text = "";
                    editor.Text = "";

                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("\n\n\n※※※※※※※※※※※※※※※※※※※※※※※※※※※※※\n\n\n");
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
                System.Diagnostics.Debug.WriteLine("\n\n\n※※※※※※※※※※※※※※※※※※※※※※※※※※※※※\n\n\n");
                System.Diagnostics.Debug.WriteLine("message: " + e.Message);

            }


        }

        void OnFirstView(object sender, EventArgs args)
        {
            new Command(() => { msgListView.ScrollTo(msgList[0], ScrollToPosition.Start, true); });
        }

        void OnLastView(object sender, EventArgs args)
        {

        }
        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem != null)
            {
                System.Diagnostics.Debug.WriteLine("\n\n\n\n OnItemSelected EventArgs= " + args.ToString());

                ListItem li = ((ListItem)args.SelectedItem);
                DisplayAlert(li.TextItem, li.DetailItem + "\n" + li.YyyyMMddItem, "閉じる");
                System.Diagnostics.Debug.WriteLine("TextItem= " + li.TextItem);
                System.Diagnostics.Debug.WriteLine("SummaryItem" + li.SummaryItem);
                System.Diagnostics.Debug.WriteLine("DetailItem" + li.DetailItem);
                System.Diagnostics.Debug.WriteLine("YyyyMMddItem" + li.YyyyMMddItem);
            }

            //選択されたままでバグ回避
            msgListView.SelectedItem = null;

        }
        void OnMore(object sender, EventArgs args)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("項目",((ListItem) mi.CommandParameter).TextItem + "です。", "OK");
        }

        void OnDelete(object sender, EventArgs args)
        {
            if (sender != null)
            {
                var mi = ((MenuItem)sender);
                DisplayAlert("削除項目", ((ListItem)mi.CommandParameter).TextItem + "を削除します。", "削除");
                msgList.Remove(((ListItem)mi.CommandParameter));

            }
            /*if (args.SelectedItem != null)
            {
                DisplayAlert("Delete", (((ListItem)args.SelectedItem).TextItem), "OK");
                // DisplayAlert(li.TextItem, li.DetailItem + "\n" + li.YyyyMMddItem, "閉じる");

            }*/
        }

        public void ClickSetting()
        {
            Navigation.PushAsync(new SettingPage1(), true);
        }
    }
}
