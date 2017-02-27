using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamlTagApp
{
    public partial class Child1Page : ContentPage
    {
        public Child1Page()
        {
            InitializeComponent();
            calcBtn.Clicked += (sender, e) =>
            {
                double d = 0d;
                if (double.TryParse(inputForm.Text, out d))
                {
                    viewText.Text = $"{XamlTagApp.Calc.GetTax(d)}円";
                }
            };
        }
        
    }
}
