using WinUI = Microsoft.UI.Xaml.Controls;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace XamlBrewer.UWP.PagerSample.Views
{
    public sealed partial class PipsPage : Page
    {
        public PipsPage()
        {
            this.InitializeComponent();

            // Selects the first picture, with previous button active.
            Pager.SelectedPageIndex = Pictures.Count;
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
            // Keeps the selection in the middle of the pager.
            Pager.SelectedPageIndex = ImageRepeater.SelectedIndex;
        }

        private void Pager_SelectedIndexChanged(WinUI.PipsPager sender, WinUI.PipsPagerSelectedIndexChangedEventArgs args)
        {
            // Good that this doesn't create an infinite loop.
            Pager.SelectedPageIndex = Pager.SelectedPageIndex % Pictures.Count + Pictures.Count;
            ImageRepeater.SelectedIndex = Pager.SelectedPageIndex % Pictures.Count;
        }
    }
}
