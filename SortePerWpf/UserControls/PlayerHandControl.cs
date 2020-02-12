using SortePerWpf.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SortePerWpf.UserControls
{
    public class PlayerHandControl : Canvas
    {

        #region Dependency Properties

        /// <summary>
        /// The on hover on an image
        /// can be bound
        /// </summary>
        public ICommand HoverImageCommand
		{
			get { return (ICommand)GetValue(HoverImageCommandProperty); }
			set { SetValue(HoverImageCommandProperty, value); }
		}

		// Using a DependencyProperty as the backing store for HoverImageCommand.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty HoverImageCommandProperty =
			DependencyProperty.Register("HoverImageCommand", typeof(ICommand), typeof(PlayerHandControl), 
				new PropertyMetadata(null));

		/// <summary>
		/// Command for when clicking an image
		/// </summary>
		public ICommand ClickImageCommand
		{
			get { return (ICommand)GetValue(ClickImageCommandProperty); }
			set { SetValue(ClickImageCommandProperty, value); }
		}

		// Using a DependencyProperty as the backing store for ClickImageCommand.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ClickImageCommandProperty =
			DependencyProperty.Register("ClickImageCommand", typeof(ICommand), typeof(PlayerHandControl), new PropertyMetadata(null));



		/// <summary>
		/// The un hover command can be bound
		/// </summary>
		public ICommand UnHoverImageCommand
		{
			get { return (ICommand)GetValue(UnHoverImageCommandProperty); }
			set { SetValue(UnHoverImageCommandProperty, value); }
		}

		// Using a DependencyProperty as the backing store for UnHoverImageCommand.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty UnHoverImageCommandProperty =
			DependencyProperty.Register("UnHoverImageCommand", typeof(ICommand), typeof(PlayerHandControl), new PropertyMetadata(null));



		/// <summary>
		/// The images used to render
		/// </summary>
		public List<Image> ImageCollection
		{
			get { return (List<Image>)GetValue(ImageCollectionProperty); }
			set { SetValue(ImageCollectionProperty, value); }
		}

		// Using a DependencyProperty as the backing store for ImageCollection.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ImageCollectionProperty =
			DependencyProperty.Register("ImageCollection", typeof(List<Image>), typeof(PlayerHandControl), new PropertyMetadata(null, new PropertyChangedCallback(ImageCollectionChanged)));

       
        /// <summary>
        /// Event handler for when imagecollection is changed
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private static void ImageCollectionChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			var c = o as PlayerHandControl;

			if (c != null)
			{
				c.UpdateEventsForImages();
				c.RenderUpdate();
			}			
		}

		#endregion

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
			for (int i = 0; i < ImageCollection.Count; i++)
			{
				ImageCollection[i].MouseEnter += OnImageMouseEnter;
				ImageCollection[i].MouseLeave += OnImageMouseExit;
				ImageCollection[i].MouseLeftButtonDown += OnImageMouseClicked;
			}
		}

		/// <summary>
		/// Called when the mouse is clicked on an image
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnImageMouseClicked(object sender, System.Windows.Input.MouseEventArgs e)
		{	
			if (ClickImageCommand != null)
				if (ClickImageCommand.CanExecute(sender))
					ClickImageCommand.Execute(sender);
		}

		/// <summary>
		/// Called when the mouse enter a image
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnImageMouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
		{
			if (HoverImageCommand != null)
				if (HoverImageCommand.CanExecute(sender))
					HoverImageCommand.Execute(sender);
		}

		/// <summary>
		/// Called when the mouse leaves the image
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnImageMouseExit(object sender, System.Windows.Input.MouseEventArgs e)
		{
			if (UnHoverImageCommand != null)
				if (UnHoverImageCommand.CanExecute(sender))
					UnHoverImageCommand.Execute(sender);
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
			for (int i = 0; i < ImageCollection.Count; i++)
			{
				ImageCollection[i].Height = ActualHeight * 0.90;
				ImageCollection[i].Width = ImageCollection[i].Height * 0.80;
			}
		}

		/// <summary>
		/// Adds the images to the canvas
		/// </summary>
		private void AddImagesToCanvas(double offset)
		{
			for (int i = 0; i < ImageCollection.Count; i++)
			{
				Image curImage = ImageCollection[i];

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
			double totalCardsWidth = ImageCollection[0].Width * ImageCollection.Count;

			return (ActualWidth >= totalCardsWidth) ? 0 : ((totalCardsWidth - ActualWidth) / (ImageCollection.Count - 1));
		}

		/// <summary>
		/// Render to the canvas again
		/// </summary>
		private void RenderUpdate()
		{
			Children.Clear();

			// Don't render if there is nothing to render.
			if (ImageCollection == null || ImageCollection.Count == 0)
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
