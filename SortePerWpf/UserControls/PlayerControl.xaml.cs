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

namespace SortePerWpf.UserControls
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        public string PlayerName
        {
            get { return (string)GetValue(PlayerNameProperty); }
            set { SetValue(PlayerNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlayerName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayerNameProperty =
            DependencyProperty.Register("PlayerName", typeof(string), typeof(PlayerControl), new PropertyMetadata("Unknown"));

        public List<Image> CardImages
        {
            get { return (List<Image>)GetValue(CardImagesProperty); }
            set { SetValue(CardImagesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CardImages.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CardImagesProperty =
            DependencyProperty.Register("CardImages", typeof(List<Image>), typeof(PlayerControl), new PropertyMetadata(null, new PropertyChangedCallback(CardImageChanged)));

        private static void CardImageChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            if (!(o is PlayerControl))
                return;

            ((PlayerControl)o).RenderCardsAgain();
        }

        public PlayerControl()
        {
            InitializeComponent();

            Loaded += delegate { RenderCardsAgain(); };
        }

        private int GetCardCanvasOffsetX()
        {
            // Get canvas width
            double canvasWidth = CardCanvas.ActualWidth;

            // Get card amounts
            int cAmount = CardImages.Count;

            // Get card width
            double cardWidth = CardImages[0].Width;

            // The total width of the cards
            double cardsWidth = cardWidth * cAmount;

            // Get the offset for each card
            int xOffset = (canvasWidth >= cardsWidth) ? 0 : (int)((cardsWidth - canvasWidth) / cAmount);

            return xOffset;
        }

        private void SetImagesSize(int height, int width)
        {
            for (int i = 0; i < CardImages.Count; i++)
            {
                CardImages[i].Height = height;
                CardImages[i].Width = width;
            }
        }

        private void RenderCardsAgain()
        {
            // Remove all children
            CardCanvas.Children.Clear();

            // If there is no images to render return
            if (CardImages.Count == 0)
                return;

            // Get Canvas Height
            int canvasHeight = (int)CardCanvas.ActualHeight;
            int canvasWidth = (int)CardCanvas.ActualWidth;

            // Set cards images size
            SetImagesSize(canvasHeight, 100);

            // Get Offset & width of card
            int cardWidth = (int)CardImages[0].Width;
            int xOffset = GetCardCanvasOffsetX();

            // render Cards
            for (int i = 0; i < CardImages.Count; i++)
            {
                Image curImage = CardImages[i];

                int offset = (cardWidth * i) - (xOffset * i);
                Canvas.SetLeft(curImage, offset);

                CardCanvas.Children.Add(curImage);
            }
        }
    }
}
