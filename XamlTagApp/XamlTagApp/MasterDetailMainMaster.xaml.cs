using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlTagApp.MasterDetailMain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailMainMaster : ContentPage
    {
        public ListView ListView => ListViewMenuItems;

        public MasterDetailMainMaster()
        {
            InitializeComponent();
            BindingContext = new MasterDetailMainMasterViewModel();
        }



        class MasterDetailMainMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailMainMenuItem> MenuItems { get; }
            public MasterDetailMainMasterViewModel()
            {
                MasterDetailMainMenuItems = new ObservableCollection<MasterDetailMainMenuItem>(new[]
                {
                    new MasterDetailMainMenuItem { Id = 0, Title = "Page 1" },
                    new MasterDetailMainMenuItem { Id = 1, Title = "Page 2" },
                    new MasterDetailMainMenuItem { Id = 2, Title = "Page 3" },
                    new MasterDetailMainMenuItem { Id = 3, Title = "Page 4" },
                    new MasterDetailMainMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        }
    }
}
