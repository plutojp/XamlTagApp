using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace XamlTagApp
{
    public class TestViewModel : ContentView
    {
        public TestViewModel()
        {
            Content = new Label { Text = "Hello View" };
        }
    }
}
