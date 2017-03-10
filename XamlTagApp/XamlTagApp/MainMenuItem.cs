using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlTagApp.MainMenuItem
{

    public class MainMenuItem
    {
        public MainMenuItem()
        {
            TargetType = typeof(MainMenuItem);
        }
        public int Id { get; set; }
        public string MenuTitle { get; set; }
        public string PageName { get; set; }


        public Type TargetType { get; set; }
    }
}
