using SortePerWpf.Model.Cards;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace SortePerWpf.Converters
{
    public class SortePerCardListConverter : IValueConverter
    {
        /// <summary>
        /// Converts from a list of sorte sorte per cards
        /// to a list of images.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SortePerCardConverter spcc = new SortePerCardConverter();

            List<Card> hand = (List<Card>)value;

            if (hand == null)
                return new List<Image>();


            List<Image> images = new List<Image>();

            for (int i = 0; i < hand.Count; i++)
            {
                images.Add((Image)spcc.Convert(hand[i], null, false, null));
            }

            return images;
        }

        /// <summary>
        /// Converts a list of images to a list of cards
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SortePerCardConverter spcc = new SortePerCardConverter();

            List<Image> images = (List<Image>)value;

            if (images == null)
                return new List<Image>();


            List<Card> hand = new List<Card>();

            for (int i = 0; i < images.Count; i++)
            {
                hand.Add((Card)spcc.ConvertBack(images[i], null, false, null));
            }

            return hand;
        }
    }
}
