// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace MonoTouch.Aviary.Demo
{
	[Register ("TestViewController")]
	partial class TestViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton LaunchButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (LaunchButton != null) {
				LaunchButton.Dispose ();
				LaunchButton = null;
			}
		}
	}
}
