using System;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ColorPicker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Color currentColor;

        public MainPage()
        {
            this.InitializeComponent();
            WatchCursor();
        }

        public async void WatchCursor()
        {
            while (true)
            {
                await Task.Delay(TimeSpan.FromMilliseconds(10));
                UpdatePixelValues();
                UpdateLabels();
            }
        }

        private void UpdateLabels()
        {
            this.RedValueLabel.Text = currentColor.R.ToString();
            this.GreenValueLabel.Text = currentColor.G.ToString();
            this.BlueValueLabel.Text = currentColor.B.ToString();
            this.CurrentPixelRectangle.Fill = new SolidColorBrush(currentColor);
        }

        private void UpdatePixelValues()
        {
            var pointerPosition = Windows.UI.Core.CoreWindow.GetForCurrentThread().PointerPosition;
            var color = PixelHelper.GetColorAt((int)pointerPosition.X, (int)pointerPosition.Y);
            currentColor = color;
        }
    }
}
