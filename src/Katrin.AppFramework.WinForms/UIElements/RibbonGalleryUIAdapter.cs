using System;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using Katrin.AppFramework.UIElements;
using Katrin.AppFramework.Utils;

namespace Katrin.AppFramework.WinForms.UIElements
{
	/// <summary>
	/// An adapter that wraps a <see cref="RibbonGalleryBarItem"/> for use
	/// as an <see cref="IUIElementAdapter"/>.
	/// </summary>
	public class RibbonGalleryUIAdapter : UIElementAdapter<GalleryItemGroup>
	{
		private readonly RibbonGalleryBarItem ribbonGallery;

		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="RibbonApplicationMenuUIAdapter"/> class.
		/// </summary>
		/// <param name="ribbonGallery">The application menu.</param>
		/// <param name="workItem">The work item which added the command.
		/// We need to access the Commands property of the work item to
		/// fire the Command associated with the GalleryItem.</param>
		public RibbonGalleryUIAdapter(RibbonGalleryBarItem ribbonGallery)
		{
			Guard.ArgumentNotNull(ribbonGallery, "RibbonGalleryBarItem");

			this.ribbonGallery = ribbonGallery;

		}

		/// <summary>
		/// See <see cref="UIElementAdapter{TUIElement}.Add(TUIElement)"/>
		/// for more information.
		/// </summary>
		protected override GalleryItemGroup Add(GalleryItemGroup uiElement)
		{
			Guard.ArgumentNotNull(uiElement, "GalleryItemGroup");
			ribbonGallery.Gallery.Groups.Add(uiElement);
			return uiElement;
		}


		/// <summary>
		/// See <see cref="UIElementAdapter{TUIElement}.Remove(TUIElement)"/>
		/// for more information.
		/// </summary>
		protected override void Remove(GalleryItemGroup uiElement)
		{
			Guard.ArgumentNotNull(uiElement, "GalleryItemGroup");
			ribbonGallery.Gallery.Groups.Remove(uiElement);
		}
	}
}
