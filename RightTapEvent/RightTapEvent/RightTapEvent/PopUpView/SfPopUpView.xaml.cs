using Syncfusion.DataSource;
using Syncfusion.GridCommon.ScrollAxis;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewContextMenu
{
    public partial class SfPopUpView : ContentView
    {
        #region Fields

        int sortorder = 0;
        Contacts item;
        SfListViewExt listview;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the value which indicates that instance of <see cref="SfListView"/>.
        /// </summary>
        public SfListViewExt ListView
        {
            get { return listview; }
            set
            {
                if (listview != value)
                {
                    listview = value;
                    OnListViewChanged(listview);
                }
            }
        }

        #endregion

        #region Constructor

        public SfPopUpView()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Layouts the <see cref="ContentView.Content"/> based on x and y position.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void ShowPopup(double x, double y)
        {
            this.IsVisible = true;
            this.Layout(new Rectangle(x, y, 100, 100));
        }

        ///<summary>
        /// Dismisses the pop-up.
        /// </summary>
        public void Dismiss()
        {
            this.IsVisible = false;
        }

        #endregion

        #region CallBacks

        private void OnListViewChanged(SfListViewExt listview) 
        {
            if (listview != null)
            {
                listview.ScrollStateChanged += SfListView_ScrollStateChanged;
                listview.ItemTapped += SfListView_ItemTapped;
                if (Device.RuntimePlatform == Device.UWP)
                    listview.ItemRightTapped += Listview_ItemRightTapped;
            }
        }

        private void Listview_ItemRightTapped(object sender, ItemRightTappedEventArgs e)
        {
            item = e.ItemData as Contacts;
            this.ShowPopup(e.Position.X, e.Position.Y);
        }

        private void SfListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            this.Dismiss();
        }

        private void SfListView_ScrollStateChanged(object sender, ScrollStateChangedEventArgs e)
        {
            this.Dismiss();
        }

        private void Deletebtn_Clicked(object sender, EventArgs e)
        {
            if (ListView == null)
                return;

            var source = ListView.ItemsSource as IList;

            if (source != null && source.Contains(item))
            {
                source.Remove(item);
                this.Dismiss();
            }
            else
                App.Current.MainPage.DisplayAlert("Alert", "Unable to delete the item", "OK");

            item = null;
            source = null;
        }

        private void Sortbtn_Clicked(object sender, EventArgs e)
        {
            if (ListView == null)
                return;

            ListView.DataSource.SortDescriptors.Clear();
            this.Dismiss();
            ListView.DataSource.LiveDataUpdateMode = LiveDataUpdateMode.AllowDataShaping;
            if (sortorder == 0)
            {
                ListView.DataSource.SortDescriptors.Add(new SortDescriptor { PropertyName = "ContactName", Direction = ListSortDirection.Descending });
                sortorder = 1;
            }
            else
            {
                ListView.DataSource.SortDescriptors.Add(new SortDescriptor { PropertyName = "ContactName", Direction = ListSortDirection.Ascending });
                sortorder = 0;
            }
        }

        #endregion
    }
}
