using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libAviarySDK.a", LinkTarget = LinkTarget.ArmV6 | LinkTarget.ArmV7 | LinkTarget.Simulator, ForceLoad = true, IsCxx = true, Frameworks="CoreGraphics QuartzCore Accelerate StoreKit CoreData", LinkerFlags="-ObjC -all_load -fobjc-arc -lz -lsqlite3.0")]
