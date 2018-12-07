using Syncfusion.DataSource;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewContextMenu
{
    public partial class MainPage : ContentPage
    {
        #region Constructor

        public MainPage()
        {
            InitializeComponent();
            this.listView.ItemGenerator = new ItemGeneratorExt(this.listView);
        }
        #endregion
    }
}
