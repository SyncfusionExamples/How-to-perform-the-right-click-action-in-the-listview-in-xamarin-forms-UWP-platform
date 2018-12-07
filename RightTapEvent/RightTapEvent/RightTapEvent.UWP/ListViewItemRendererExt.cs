using ListViewContextMenu;
using ListViewContextMenu.UWP;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(ListViewItemExt), typeof(ListViewItemRendererExt))]
namespace ListViewContextMenu.UWP
{
    public class ListViewItemRendererExt : ListViewItemRenderer 
    {
        public ListViewItemRendererExt()
        {
            this.RightTapped += ListViewItemRendererExt_RightTapped;
        }

        private void ListViewItemRendererExt_RightTapped(object sender, Windows.UI.Xaml.Input.RightTappedRoutedEventArgs e)
        {
            var listviewitem = this.Element as ListViewItemExt;
            if (listviewitem != null)
            {
                var location = this.TransformToVisual(null).TransformPoint(e.GetPosition(this));
                var tappedEventArgs = new ItemRightTappedEventArgs(this.Element.BindingContext, new Xamarin.Forms.Point(location.X, location.Y));
                listviewitem.ListView.RaiseItemRightTapped(tappedEventArgs);
            }
        }
    }
}
