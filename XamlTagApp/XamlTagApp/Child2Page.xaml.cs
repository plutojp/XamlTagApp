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
        ObservableCollection<ListItem> listItems = new ObservableCollection<ListItem>();
        public Child2Page()
        {
            InitializeComponent();
            AddlistItem(0);

            var cell = new DataTemplate(typeof(TextCell));
            cell.SetBinding(TextCell.TextColorProperty,"TextItem");
            cell.SetBinding(TextCell.DetailProperty, "DetailItem");

            var list = new ListView {
                ItemsSource=listItems,
                ItemTemplate = cell,
            };

        }

        void AddlistItem(int n)
        {
            foreach (var j in Enumerable.Range(n,25))
            {
                listItems.Add(new ListItem { TextItem = "TextData＝" + j, DetailItem = "DetailItem＝" + j });

            }
        }
    }
}
