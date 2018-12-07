using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ListViewContextMenu
{
    public class SfListViewExt : SfListView
    {
        public event ItemRightTappedEventHandler ItemRightTapped;
        public void RaiseItemRightTapped(ItemRightTappedEventArgs e)
        {
            if (ItemRightTapped != null)
                this.ItemRightTapped(this, e);
        }
    }

    public delegate void ItemRightTappedEventHandler(object sender, ItemRightTappedEventArgs e);

    public class ItemRightTappedEventArgs : EventArgs
    {
        #region Fields

        private object itemData = null;

        private Point position;

        #endregion

        #region Constructor

        public ItemRightTappedEventArgs(object itemData, Point position)
        {
            this.itemData = itemData;
            this.position = position;
        }

        #endregion

        #region Property

        public object ItemData
        {
            get { return itemData; }
        }

        public Point Position
        {
            get { return position; }
        }

        #endregion
    }
}
