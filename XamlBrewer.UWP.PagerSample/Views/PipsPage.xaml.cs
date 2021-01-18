using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

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
    }
}
