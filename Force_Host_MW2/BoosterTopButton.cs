using System;
using System.Drawing;
using System.Windows.Forms;

namespace Force_Host_MW2
{
	internal class BoosterTopButton : ThemeControl154
	{
		public BoosterTopButton()
		{
			base.Transparent = true;
			this.BackColor = Color.Transparent;
		}

		protected override void ColorHook()
		{
		}

		protected override void PaintHook()
		{
			base.DrawGradient(Color.FromArgb(141, 141, 141), Color.FromArgb(23, 23, 23), 0, 0, base.Width, base.Height, 45f);
			base.DrawBorders(new Pen(Color.FromArgb(41, 41, 41)), 0);
			base.DrawBorders(new Pen(Color.FromArgb(41, 41, 41)), 1);
			base.DrawBorders(Pens.Black, 2);
			this.G.DrawLine(new Pen(Color.FromArgb(100, 100, 100)), 0, checked(base.Height - 1), base.Width, checked(base.Height - 1));
			base.DrawGradient(Color.FromArgb(41, 41, 41), Color.FromArgb(100, 100, 100), 0, 0, 1, base.Height);
			base.DrawGradient(Color.FromArgb(41, 41, 41), Color.FromArgb(100, 100, 100), checked(base.Width - 1), 0, base.Width, base.Height);
			base.DrawCorners(this.BackColor);
			base.DrawCorners(Color.FromArgb(41, 41, 41), 2);
			if (this.State == MouseState.Over)
			{
				base.DrawGradient(Color.FromArgb(255, 255, 255), Color.FromArgb(23, 23, 23), 0, 0, base.Width, base.Height, 45f);
				base.DrawBorders(new Pen(Color.FromArgb(41, 41, 41)), 0);
				base.DrawBorders(new Pen(Color.FromArgb(41, 41, 41)), 1);
				base.DrawBorders(Pens.Black, 2);
				this.G.DrawLine(new Pen(Color.FromArgb(100, 100, 100)), 0, checked(base.Height - 1), base.Width, checked(base.Height - 1));
				base.DrawGradient(Color.FromArgb(41, 41, 41), Color.FromArgb(100, 100, 100), 0, 0, 1, base.Height);
				base.DrawGradient(Color.FromArgb(41, 41, 41), Color.FromArgb(100, 100, 100), checked(base.Width - 1), 0, base.Width, base.Height);
				base.DrawCorners(this.BackColor);
				base.DrawCorners(Color.FromArgb(41, 41, 41), 2);
			}
			else if (this.State == MouseState.Down)
			{
				base.DrawGradient(Color.FromArgb(100, 100, 100), Color.FromArgb(23, 23, 23), 0, 0, base.Width, base.Height, 45f);
				base.DrawBorders(new Pen(Color.FromArgb(41, 41, 41)), 0);
				base.DrawBorders(new Pen(Color.FromArgb(41, 41, 41)), 1);
				base.DrawBorders(Pens.Black, 2);
				this.G.DrawLine(new Pen(Color.FromArgb(100, 100, 100)), 0, checked(base.Height - 1), base.Width, checked(base.Height - 1));
				base.DrawGradient(Color.FromArgb(41, 41, 41), Color.FromArgb(100, 100, 100), 0, 0, 1, base.Height);
				base.DrawGradient(Color.FromArgb(41, 41, 41), Color.FromArgb(100, 100, 100), checked(base.Width - 1), 0, base.Width, base.Height);
				base.DrawCorners(this.BackColor);
				base.DrawCorners(Color.FromArgb(41, 41, 41), 2);
			}
		}
	}
}