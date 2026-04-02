# How to perform the right-click action in the listview in Xamarin.Forms UWP platform?
This example demonstrates how to perform the right-click action in UWP platform by customizing the ListView and ListViewItem.

## Sample

```xaml
<local:SfListViewExt x:Name="listView" ItemSize="70" SelectionMode="Single"
                        ItemsSource="{Binding Items}" ItemSpacing="0,0,5,0">
    <local:SfListViewExt.DataSource>
        <dataSource:DataSource>
            <dataSource:DataSource.SortDescriptors>
                <dataSource:SortDescriptor PropertyName="ContactName" Direction="Ascending"/>
            </dataSource:DataSource.SortDescriptors>
        </dataSource:DataSource>
    </local:SfListViewExt.DataSource>
    <local:SfListViewExt.GroupHeaderTemplate>
        <DataTemplate>
            <StackLayout BackgroundColor="#D3D3D3">
                <Label Text="{Binding Key}" TextColor="Black"
                        Margin="20,5,0,0" FontSize="18"
                        FontAttributes="Bold" VerticalTextAlignment="Center"/>
            </StackLayout>
        </DataTemplate>
    </local:SfListViewExt.GroupHeaderTemplate>
    <local:SfListViewExt.ItemTemplate>
        <DataTemplate>
            <Grid x:Name="grid" RowSpacing="1" >
                <code>
                . . .
                . . .
                <code>
            </Grid>
        </DataTemplate>
    </local:SfListViewExt.ItemTemplate>
    <local:SfPopUpView IsVisible="{Binding ShowPopUp, Mode=TwoWay}"
                    ListView="{x:Reference listView}"/>
</local:SfListViewExt>

Code behind:
if (Device.RuntimePlatform == Device.UWP)
    listview.ItemRightTapped += Listview_ItemRightTapped

private void Listview_ItemRightTapped(object sender, ItemRightTappedEventArgs e)
{
    item = e.ItemData as Contacts;
    this.ShowPopup(e.Position.X, e.Position.Y);
}

```

See [How to perform the right-click action in the listview in Xamarin.Forms UWP platform](https://www.syncfusion.com/kb/9983/how-to-perform-the-right-click-action-in-the-listview-in-xamarin-forms-uwp-platform) for more details.
## <a name="requirements-to-run-the-demo"></a>Requirements to run the demo ##

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/).
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## <a name="troubleshooting"></a>Troubleshooting ##
### Path too long exception
If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.