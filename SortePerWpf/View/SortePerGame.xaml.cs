using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SortePerWpf.View
{
    /// <summary>
    /// Interaction logic for SortePerGame.xaml
    /// </summary>
    public partial class SortePerGame : UserControl
    {
        public SortePerGame()
        {
            InitializeComponent();

            List<Image> images = new List<Image>()
            {
                new Image() {Source = new BitmapImage(new Uri("/Assets/B1.png", UriKind.Relative)) },
                new Image() {Source = new BitmapImage(new Uri("/Assets/B2.png", UriKind.Relative)) },
                new Image() {Source = new BitmapImage(new Uri("/Assets/bear.png", UriKind.Relative)) },
                new Image() {Source = new BitmapImage(new Uri("/Assets/bee.png", UriKind.Relative)) },
                new Image() {Source = new BitmapImage(new Uri("/Assets/bull.png", UriKind.Relative)) },
                new Image() {Source = new BitmapImage(new Uri("/Assets/B2.png", UriKind.Relative)) },
                new Image() {Source = new BitmapImage(new Uri("/Assets/B2.png", UriKind.Relative)) },
                new Image() {Source = new BitmapImage(new Uri("/Assets/B2.png", UriKind.Relative)) },
                new Image() {Source = new BitmapImage(new Uri("/Assets/B2.png", UriKind.Relative)) },
                new Image() {Source = new BitmapImage(new Uri("/Assets/B2.png", UriKind.Relative)) },
                new Image() {Source = new BitmapImage(new Uri("/Assets/B2.png", UriKind.Relative)) },
                new Image() {Source = new BitmapImage(new Uri("/Assets/B2.png", UriKind.Relative)) }
            };

            CurrentPlayer.CardImages = images;
        }
    }
}
