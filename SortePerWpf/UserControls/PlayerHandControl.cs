using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SortePerWpf.UserControls
{
    public class PlayerHandControl : Canvas
    {
		// Event for when hovering over image
		public delegate void HoverImageEventHandler(object sender, Image image);
		public event HoverImageEventHandler HoverImageEvent;

		// Event for when exiting hovering on image
		public delegate void UnHoverImageEventHandler(object sender, Image image);
		public event UnHoverImageEventHandler UnHoverImageEvent;

		// Event for clicking an image
		public delegate void ClickedImageEventHandler(object sender, Image image);
		public event ClickedImageEventHandler ClickedImageEvent;

		/// <summary>
		/// The images which will be displayed as a hand
		/// </summary>
		public List<Image> CardImages
		{
			get { return cardImages; }
			set 
			{
				if (cardImages == value)
					return;

				cardImages = value;
				UpdateEventsForImages();
				RenderUpdate();
			}
		}

		private List<Image> cardImages;

		/// <summary>
		/// Construct the player hand control
		/// </summary>
		public PlayerHandControl() 
		{
			SizeChanged += RenderSizeChanged;
		}

		/// <summary>
		/// Translates an image in the y direction
		/// </summary>
		/// <param name="image"></param>
		/// <param name="value"></param>
		public void TranslateImageY(Image image, double value)
		{
			Canvas.SetBottom(image, Canvas.GetBottom(image) + value);
		}

		/// <summary>
		/// Sets the z index for an image
		/// </summary>
		/// <param name="image"></param>
		/// <param name="zIndex"></param>
		public void SetZIndex(Image image, int zIndex)
		{
			Canvas.SetZIndex(image, zIndex);
		}

		#region Events

		/// <summary>
		/// Update Events for images
		/// </summary>
		private void UpdateEventsForImages()
		{
			for (int i = 0; i < CardImages.Count; i++)
			{
				CardImages[i].MouseEnter += OnImageMouseEnter;
				CardImages[i].MouseLeave += OnImageMouseExit;
				CardImages[i].MouseLeftButtonDown += OnImageMouseClicked;
			}
		}

		/// <summary>
		/// Called when the mouse is clicked on an image
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnImageMouseClicked(object sender, System.Windows.Input.MouseEventArgs e)
		{
			ClickedImageEvent?.Invoke(this, (Image)e.Source);
		}

		/// <summary>
		/// Called when the mouse enter a image
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnImageMouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
		{
			HoverImageEvent?.Invoke(this, (Image)e.Source);
		}

		/// <summary>
		/// Called when the mouse leaves the image
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnImageMouseExit(object sender, System.Windows.Input.MouseEventArgs e)
		{
			UnHoverImageEvent?.Invoke(this, (Image)e.Source);
		}

		/// <summary>
		/// Event when the canvas size changes
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void RenderSizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
		{
			RenderUpdate();
		}

        #endregion

        #region Render Methods

        /// <summary>
        /// Sets the images size after a propotion
        /// </summary>
        private void SetImagesSize()
		{
			for (int i = 0; i < CardImages.Count; i++)
			{
				CardImages[i].Height = ActualHeight * 0.90;
				CardImages[i].Width = CardImages[i].Height * 0.80;
			}
		}

		/// <summary>
		/// Adds the images to the canvas
		/// </summary>
		private void AddImagesToCanvas(double offset)
		{
			for (int i = 0; i < CardImages.Count; i++)
			{
				Image curImage = CardImages[i];

				double curPosX = i * curImage.Width;
				double curOffsetX = i * offset;

				Canvas.SetLeft(curImage, curPosX - curOffsetX);
				Canvas.SetBottom(curImage, 0);

				Children.Add(curImage);
			}
		}

		/// <summary>
		/// Gets the x offset of the cards
		/// </summary>
		/// <returns></returns>
		private double GetCardsXOffset()
		{
			double totalCardsWidth = CardImages[0].Width * CardImages.Count;

			return (ActualWidth >= totalCardsWidth) ? 0 : ((totalCardsWidth - ActualWidth) / (CardImages.Count - 1));
		}

		/// <summary>
		/// Render to the canvas again
		/// </summary>
		private void RenderUpdate()
		{
			Children.Clear();

			// Don't render if there is nothing to render.
			if (CardImages == null || CardImages.Count == 0)
				return;

			// Set Images size
			SetImagesSize();

			// Get the offset for the cards
			double xOffset = GetCardsXOffset();

			// Add images to the canvas
			AddImagesToCanvas(xOffset);
		}

        #endregion
    }
}
