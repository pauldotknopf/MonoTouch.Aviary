using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MonoTouch.Aviary
{
	// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
	// to the project by right-clicking (or Control-clicking) the folder containing this source
	// file and clicking "Add files..." and then simply select the native library (or libraries)
	// that you want to bind.
	//
	// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
	// native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
	// architectures that the native library supports and fills in that information for you,
	// however, it cannot auto-detect any Frameworks or other system libraries that the
	// native library may depend on, so you'll need to fill in that information yourself.
	//
	// Once you've done that, you're ready to move on to binding the API...
	//
	//
	// Here is where you'd define your API definition for the native Objective-C library.
	//
	// For example, to bind the following Objective-C class:
	//
	//     @interface Widget : NSObject {
	//     }
	//
	// The C# binding would look like this:
	//
	//     [BaseType (typeof (NSObject))]
	//     interface Widget {
	//     }
	//
	// To bind Objective-C properties, such as:
	//
	//     @property (nonatomic, readwrite, assign) CGPoint center;
	//
	// You would add a property definition in the C# interface like so:
	//
	//     [Export ("center")]
	//     PointF Center { get; set; }
	//
	// To bind an Objective-C method, such as:
	//
	//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
	//
	// You would add a method definition to the C# interface like so:
	//
	//     [Export ("doSomething:atIndex:")]
	//     void DoSomething (NSObject object, int index);
	//
	// Objective-C "constructors" such as:
	//
	//     -(id)initWithElmo:(ElmoMuppet *)elmo;
	//
	// Can be bound as:
	//
	//     [Export ("initWithElmo:")]
	//     IntPtr Constructor (ElmoMuppet elmo);
	//
	// For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_types
	//
	
	//	
	
	//	@interface AFPhotoEditorStyle : NSObject
	[BaseType(typeof(NSObject))]
	interface AFPhotoEditorStyle
	{
		[ExportAttribute("backgroundColor")]
		UIColor backgroundColor {get; set;}
		//@property (nonatomic, strong) UIColor *backgroundColor;
		
		[ExportAttribute("accentColor")]
		UIColor accentColor {get; set;}
		
		//@property (nonatomic, strong) UIColor *accentColor;
		//
		
		[ExportAttribute("topBarBackgroundColor")]
		UIColor topBarBackgroundColor {get; set;}
		//@property (nonatomic, strong) UIColor *topBarBackgroundColor;
		
		[ExportAttribute("topBarTextColor")]
		UIColor topBarTextColor{get; set;}
		//@property (nonatomic, strong) UIColor *topBarTextColor;
		
		[ExportAttribute("topBarLeftButtonTextColor")]
		UIColor topBarLeftButtonTextColor {get; set;}
		//@property (nonatomic, strong) UIColor *topBarLeftButtonTextColor;
		
		[ExportAttribute("topBarLeftButtonBackgroundColor")]
		UIColor topBarLeftButtonBackgroundColor {get; set;}
		//@property (nonatomic, strong) UIColor *topBarLeftButtonBackgroundColor;
		//
		[ExportAttribute("buttonIconColor")]
		UIColor buttonIconColor {get; set;}
		//@property (nonatomic, strong) UIColor *buttonIconColor;
		
		[ExportAttribute("buttonTextColor")]
		UIColor buttonTextColor {get; set;}
		//@property (nonatomic, strong) UIColor *buttonTextColor;
		//
		[ExportAttribute("pageControlUnselectedColor")]
		UIColor pageControlUnselectedColor {get; set;}
		//@property (nonatomic, strong) UIColor *pageControlUnselectedColor;
		//
		//@end
	}
	
	
	
	
	//	@interface AFPhotoEditorContext : NSObject
	//
	public delegate void CompletionDelegate(UIImage image);
	
	[BaseType(typeof(NSObject))]
	interface AFPhotoEditorContext
	{
		//@property (nonatomic, assign, readonly) AFPhotoEditorSession *session;
		[Export("session")]
		AFPhotoEditorSession session {get; }
		//@property (nonatomic, assign, readonly) CGSize size;
		[Export("size")]
		SizeF size {get; }
		//@property (nonatomic, assign, readonly, getter=isCanceled) BOOL canceled;
		[Export("canceled")]
		bool canceled {[Bind("isCanceled")] get;}
		//@property (nonatomic, assign, readonly, getter=isModified) BOOL modified;
		[Export("modified")]
		bool modified {[Bind("isModified")] get;}
		//
		
		//- (void)renderInputImage:(UIImage *)image completion:(void (^)(UIImage *result))completion;
		
		[Export("renderInputImage:completion:")]
		void renderInputImage(UIImage image, CompletionDelegate completion);
		//- (void)cancelRendering;
		
		[Export("cancelRendering")]
		void cancelRendering();
		//@end
	}
	
	//	@interface AFPhotoEditorSession : NSObject
	[BaseType(typeof(NSObject))]
	interface AFPhotoEditorSession
	{
		[Export("open")]
		bool open {[Bind ("isOpen")] get; set;}
		
		[Export("createContext")]
		AFPhotoEditorContext createContext();
		
		[Export("createContextWithSize:")]
		AFPhotoEditorContext createContextWithSize(SizeF size);
	}
	//
	//@property (nonatomic, assign, readonly, getter=isOpen) BOOL open;
	//
	//- (AFPhotoEditorContext *)createContext;
	//- (AFPhotoEditorContext *)createContextWithSize:(CGSize)size;
	//
	//@end
	
	//	
	//	//
	////  AFPhotoEditorController.h
	////  AviarySDK
	////
	////  Copyright (c) 2012 Aviary, Inc. All rights reserved.
	////
	//
	//#import "AFPhotoEditorControllerOptions.h"
	//#import "AFPhotoEditorSession.h"
	//#import "AFPhotoEditorContext.h"
	//#import "AFPhotoEditorStyle.h"
	//
	//@class AFPhotoEditorController;
	//
	
	[BaseType(typeof(NSObject))]
	[Model]
	interface AFPhotoEditorControllerDelegate
	{
		///**
		//    Implement this protocol to be notified when the user is done using the editor.
		//    You are responsible for dismissing the editor when you (and/or your user) are
		//    finished with it.
		// */
		//@protocol AFPhotoEditorControllerDelegate <NSObject>
		//@optional
		//
		///**
		//    Implement this method to be notified when the user presses the "Done" button.
		//    The edited image is passed via the `image` parameter.
		//
		//    @param editor The photo editor controller.
		//    @param image The edited image.
		//
		//    @note The size of this image may not be equivalent to the size of the input
		//    image, if the input image is larger than the maximum image size supported by the
		//    SDK. Currently (as of 1/17/12), the maximum size is {960.0, 960.0} pixels on all
		//    devices.
		// */
		[Export("photoEditor:finishedWithImage:"), EventArgs("AFPhotoEditor")]
		void PhotoEditor( AFPhotoEditorController editor, UIImage image);       
		//- (void)photoEditor:(AFPhotoEditorController *)editor finishedWithImage:(UIImage *)image;
		//
		///**
		//    Implement this method to be notified when the user presses the "Cancel" button.
		//
		//    @param editor The photo editor controller.
		// */
		[Export("photoEditorCanceled:"), EventArgs("AFPhotoEditor")]
		void PhotoEditorCanceled(AFPhotoEditorController editor);
		//- (void)photoEditorCanceled:(AFPhotoEditorController *)editor;
		//
		//@end
		
	}
	
	//@interface AFPhotoEditorController : UIViewController
	
	[BaseType (typeof(UIViewController), Delegates = new string [] {"WeakDelegate"}, Events = new Type[] { (typeof(AFPhotoEditorControllerDelegate)) })]
	interface AFPhotoEditorController
	{
		
		
		//@property (nonatomic, assign) id<AFPhotoEditorControllerDelegate> delegate;
		//
		[Export("delegate", ArgumentSemantic.Assign)]
		[NullAllowed]
		NSObject WeakDelegate { get; set; }
		
		[Wrap("WeakDelegate")]
		[NullAllowed]
		AFPhotoEditorControllerDelegate Delegate { get; set; }
		
		///**
		//    Returns a session object that can be used for later processing.
		// 
		//    @see AFPhotoEditorSession.h
		// */
		//@property (nonatomic, strong, readonly) AFPhotoEditorSession *session;
		[Export("session")]
		AFPhotoEditorSession session {get;}
		//
		///**
		//    Returns an object that can be used to control various visual aspects of the
		//    photo editor, including colors.
		// 
		//    @see AFPhotoEditorStyle.h
		// */
		//@property (strong, nonatomic, readonly) AFPhotoEditorStyle *style;
		//
		[Export("style")]
		AFPhotoEditorStyle style {get;}
		
		///**
		//    Initialize the photo editor controller with an image and configuration options.
		//    This is the designated initializer for this class.
		//
		//    @param image The image to edit.
		//    @param options (optional) Additional configuration options. See
		//    AFPhotoEditorControllerOptions.h for more information.
		//
		//    @note As mentioned above, the dimensions of the edited image may be smaller than
		//    the input image.
		//    @see AFPhotoEditorControllerOptions.h
		//    @see photoEditor:finishedWithImage:
		// */
		//- (id)initWithImage:(UIImage *)image options:(NSDictionary *)options;
		//
		[Export("initWithImage:options:")]
		IntPtr Constructor(UIImage image, NSDictionary options);
		///**
		//    Initialize the photo editor controller with an image and the default options.
		//
		//    @param image The image to edit.
		// 
		//    @see initWithImage:options:
		// */
		//- (id)initWithImage:(UIImage *)image;
		[Export("initWithImage:")]
		IntPtr Constructor(UIImage image);
		//
		//@end
	}

	// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
	// to the project by right-clicking (or Control-clicking) the folder containing this source
	// file and clicking "Add files..." and then simply select the native library (or libraries)
	// that you want to bind.
	//
	// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
	// native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
	// architectures that the native library supports and fills in that information for you,
	// however, it cannot auto-detect any Frameworks or other system libraries that the
	// native library may depend on, so you'll need to fill in that information yourself.
	//
	// Once you've done that, you're ready to move on to binding the API...
	//
	//
	// Here is where you'd define your API definition for the native Objective-C library.
	//
	// For example, to bind the following Objective-C class:
	//
	//     @interface Widget : NSObject {
	//     }
	//
	// The C# binding would look like this:
	//
	//     [BaseType (typeof (NSObject))]
	//     interface Widget {
	//     }
	//
	// To bind Objective-C properties, such as:
	//
	//     @property (nonatomic, readwrite, assign) CGPoint center;
	//
	// You would add a property definition in the C# interface like so:
	//
	//     [Export ("center")]
	//     PointF Center { get; set; }
	//
	// To bind an Objective-C method, such as:
	//
	//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
	//
	// You would add a method definition to the C# interface like so:
	//
	//     [Export ("doSomething:atIndex:")]
	//     void DoSomething (NSObject object, int index);
	//
	// Objective-C "constructors" such as:
	//
	//     -(id)initWithElmo:(ElmoMuppet *)elmo;
	//
	// Can be bound as:
	//
	//     [Export ("initWithElmo:")]
	//     IntPtr Constructor (ElmoMuppet elmo);
	//
	// For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_types
	//
}

