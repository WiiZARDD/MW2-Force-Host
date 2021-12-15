using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;

namespace Force_Host_MW2
{
	internal static class ThemeShare
	{
		private static int Frames;

		private static bool Invalidate;

		public static PrecisionTimer ThemeTimer;

		private const int FPS = 50;

		private const int Rate = 10;

		private static List<ThemeShare.AnimationDelegate> Callbacks;

		static ThemeShare()
		{
			ThemeShare.ThemeTimer = new PrecisionTimer();
			ThemeShare.Callbacks = new List<ThemeShare.AnimationDelegate>();
		}

		public static void AddAnimationCallback(ThemeShare.AnimationDelegate callback)
		{
			lock (ThemeShare.Callbacks)
			{
				if (!ThemeShare.Callbacks.Contains(callback))
				{
					ThemeShare.Callbacks.Add(callback);
					ThemeShare.InvalidateThemeTimer();
				}
				else
				{
					return;
				}
			}
		}

		private static void HandleCallbacks(IntPtr state, bool reserve)
		{
			ThemeShare.Invalidate = ThemeShare.Frames >= 50;
			if (ThemeShare.Invalidate)
			{
				ThemeShare.Frames = 0;
			}
			lock (ThemeShare.Callbacks)
			{
				int count = checked(ThemeShare.Callbacks.Count - 1);
				for (int i = 0; i <= count; i = checked(i + 1))
				{
					ThemeShare.Callbacks[i](ThemeShare.Invalidate);
				}
			}
			ThemeShare.Frames = checked(ThemeShare.Frames + 10);
		}

		private static void InvalidateThemeTimer()
		{
			if (ThemeShare.Callbacks.Count != 0)
			{
				ThemeShare.ThemeTimer.Create(0, 10, new PrecisionTimer.TimerDelegate(ThemeShare.HandleCallbacks));
			}
			else
			{
				ThemeShare.ThemeTimer.Delete();
			}
		}

		public static void RemoveAnimationCallback(ThemeShare.AnimationDelegate callback)
		{
			lock (ThemeShare.Callbacks)
			{
				if (ThemeShare.Callbacks.Contains(callback))
				{
					ThemeShare.Callbacks.Remove(callback);
					ThemeShare.InvalidateThemeTimer();
				}
				else
				{
					return;
				}
			}
		}

		public delegate void AnimationDelegate(bool invalidate);
	}
}