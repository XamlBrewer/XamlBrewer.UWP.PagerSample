using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using WinUI = Microsoft.UI.Xaml.Controls;

namespace XamlBrewer.UWP.PagerSample.Views
{
    public sealed partial class PipsPage : Page
    {
        public PipsPage()
        {
            this.InitializeComponent();
        }

        public List<string> Pictures => new List<string>
        {
            "/Assets/Pictures/picture_1.png",
            "/Assets/Pictures/picture_2.png",
            "/Assets/Pictures/picture_3.png",
            "/Assets/Pictures/picture_4.png",
            "/Assets/Pictures/picture_5.png",
            "/Assets/Pictures/picture_6.png",
            "/Assets/Pictures/picture_7.png",
            "/Assets/Pictures/picture_8.png"
        };

        private void ImageRepeater_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pager.SelectedPageIndex = (sender as FlipView).SelectedIndex;
        }

        private void Pager_SelectedIndexChanged(WinUI.PipsPager sender, WinUI.PipsPagerSelectedIndexChangedEventArgs args)
        {
            ImageRepeater.SelectedIndex = args.NewPageIndex;
        }
    }
}
