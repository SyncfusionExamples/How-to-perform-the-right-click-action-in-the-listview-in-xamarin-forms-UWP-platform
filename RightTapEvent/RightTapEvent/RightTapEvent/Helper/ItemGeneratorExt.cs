using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListViewContextMenu
{
    public class ItemGeneratorExt : ItemGenerator
    {
        public SfListViewExt ListView { get; set; }

        public ItemGeneratorExt(SfListViewExt listView) : base(listView)
        {
            this.ListView = listView;
        }

        protected override ListViewItem OnCreateListViewItem(int itemIndex, ItemType type, object data = null)
        {

            if (type == ItemType.Record)
                return new ListViewItemExt(this.ListView);
            return base.OnCreateListViewItem(itemIndex, type, data);
        }
    }
    public class ListViewItemExt : ListViewItem
    {
        public SfListViewExt ListView { get; set; }
        public ListViewItemExt(SfListViewExt listView)
        {
            this.ListView = listView;
        }
    }
}
