using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libAviarySDK.a", 
                     LinkTarget = LinkTarget.ArmV7 | LinkTarget.Simulator, 
                     ForceLoad = true, 
                     IsCxx = true,
                     Frameworks="Accelerate CoreData CoreText Foundation MessageUI OpenGLES QuartzCore StoreKit SystemConfiguration UIKit", 
                     WeakFrameworks="AdSupport",
                     LinkerFlags="-ObjC -all_load -fobjc-arc -lz -lsqlite3.0")]
//CoreGraphics QuartzCore Accelerate StoreKit CoreData
// Accelerate AdSupport CoreData CoreText Foundation MessageUI OpenGLES QuartzCore StoreKit SystemConfiguration UIKit