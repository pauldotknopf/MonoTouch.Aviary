
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MonoTouch.Aviary.Demo
{
	public partial class TestViewController : UIViewController
	{
		AFPhotoEditorController photoEditor;

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public TestViewController ()
			: base (UserInterfaceIdiomIsPhone ? "TestViewController_iPhone" : "TestViewController_iPad", null)
		{
		}

		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.LaunchButton.TouchUpInside += HandleTouchUpInside;
		}

		void HandleTouchUpInside (object sender, EventArgs e)
		{
			var testImage = UIImage.FromFile("colorbars.gif");
			photoEditor = new AFPhotoEditorController(testImage);
			var afDelegate = new AFDelegate(this);
			//photoEditor.Delegate = afDelegate;
			PresentViewController(photoEditor, true, new NSAction(() => {}));
		}
	}

	public class AFDelegate : AFPhotoEditorControllerDelegate
	{
		public AFDelegate(UIViewController parent)
		{
			_parentController = parent;
		}
		
		protected UIViewController _parentController;
		
		public override void PhotoEditor( AFPhotoEditorController editor, UIImage image)
		{
			_parentController.DismissModalViewControllerAnimated(true);
		}
		
		public override void PhotoEditorCanceled(AFPhotoEditorController editor)
		{
			_parentController.DismissModalViewControllerAnimated(true);
		}
	}
}

