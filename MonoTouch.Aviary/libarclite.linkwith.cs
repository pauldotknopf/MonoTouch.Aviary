using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libarclite.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7, ForceLoad = true)]
