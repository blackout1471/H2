using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using SortePerWpf.Model.Cards;
using SortePerWpf.Model.Players;

namespace SortePerWpf.Converters
{

    /// <summary>
    /// Converts a card or image to the opposite
    /// based upon sorte per game
    /// if parameter is set to true it will inverse operation
    /// </summary>
    public class SortePerCardConverter : IValueConverter
    {
        /// <summary>
        /// Convert from a card to an image
        /// if parameter is true operation will be inversed
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool par = (!(parameter is bool)) ? false : (bool)parameter;

            if (par)
                return ConvertBack(value, targetType, false, culture);

            Card c = (Card)value;

            if (c == null)
                return null;

            Image img = ConvertCardToImage(c);

            return img;
        }

        /// <summary>
        /// Convert from an image to a card
        /// If the parameter is true the operation will be inversed
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool par = (!(parameter is bool)) ? false : (bool)parameter;

            if (par)
                return ConvertBack(value, targetType, false, culture);

            Image i = (Image)value;

            if (i == null)
                return null;

            Card c = ConvertImageToCard(i);

            return c;
        }

        /// <summary>
        /// Convert from a card to an image
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        private Image ConvertCardToImage(Card card)
        {
            Image img = new Image();

            switch(card.Value)
            {
                case 0:
                    img.Source = new BitmapImage(new Uri("/Assets/bear.png", UriKind.Relative));
                    break;
                case 1:
                    img.Source = new BitmapImage(new Uri("/Assets/bee.png", UriKind.Relative));
                    break;
                case 2:
                    img.Source = new BitmapImage(new Uri("/Assets/bull.png", UriKind.Relative));
                    break;
                case 3:
                    img.Source = new BitmapImage(new Uri("/Assets/camel.png", UriKind.Relative));
                    break;
                case 4:
                    img.Source = new BitmapImage(new Uri("/Assets/cat.png", UriKind.Relative));
                    break;
                case 5:
                    img.Source = new BitmapImage(new Uri("/Assets/crab.png", UriKind.Relative));
                    break;
                case 6:
                    img.Source = new BitmapImage(new Uri("/Assets/crocodile.png", UriKind.Relative));
                    break;
                case 7:
                    img.Source = new BitmapImage(new Uri("/Assets/dog.png", UriKind.Relative));
                    break;
                case 8:
                    img.Source = new BitmapImage(new Uri("/Assets/duck.png", UriKind.Relative));
                    break;
                case 9:
                    img.Source = new BitmapImage(new Uri("/Assets/fish.png", UriKind.Relative));
                    break;
                case 10:
                    img.Source = new BitmapImage(new Uri("/Assets/grasshopper.png", UriKind.Relative));
                    break;
                case 11:
                    img.Source = new BitmapImage(new Uri("/Assets/ladybug.png", UriKind.Relative));
                    break;
                case 12:
                    img.Source = new BitmapImage(new Uri("/Assets/mouse.png", UriKind.Relative));
                    break;
            }

            return img;
        }

        /// <summary>
        /// Convert from an image to a card
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private Card ConvertImageToCard(Image image)
        {
            Card card = new Card(0);

            switch (image.Source.ToString())
            {
                case "/Assets/bear.png":
                    card = new Card(0);
                    break;
                case "/Assets/bee.png":
                    card = new Card(1);
                    break;
                case "/Assets/bull.png":
                    card = new Card(2);
                    break;
                case "/Assets/camel.png":
                    card = new Card(3);
                    break;
                case "/Assets/cat.png":
                    card = new Card(4);
                    break;
                case "/Assets/crab.png":
                    card = new Card(5);
                    break;
                case "/Assets/crocodile.png":
                    card = new Card(6);
                    break;
                case "/Assets/dog.png":
                    card = new Card(7);
                    break;
                case "/Assets/duck.png":
                    card = new Card(8);
                    break;
                case "/Assets/fish.png":
                    card = new Card(9);
                    break;
                case "/Assets/grasshopper.png":
                    card = new Card(10);
                    break;
                case "/Assets/ladybug.png":
                    card = new Card(11);
                    break;
                case "/Assets/mouse.png":
                    card = new Card(12);
                    break;
            }

            return card;
        }
    }
}
