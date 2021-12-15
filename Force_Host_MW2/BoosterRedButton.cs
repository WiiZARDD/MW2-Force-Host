using System;
using System.Drawing;
using System.Windows.Forms;

namespace Force_Host_MW2
{
	internal class BoosterRedButton : ThemeControl154
	{
		public BoosterRedButton()
		{
			base.Transparent = true;
			this.BackColor = Color.Transparent;
		}

		protected override void ColorHook()
		{
		}

		protected override void PaintHook()
		{
			base.DrawGradient(Color.FromArgb(75, 75, 75), Color.FromArgb(124, 124, 124), 0, 0, base.Width, base.Height);
			base.DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
			this.G.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), 0, 0, base.Width, base.Height / 2);
			base.DrawBorders(new Pen(Color.FromArgb(25, 25, 25)), 0);
			base.DrawBorders(new Pen(Color.FromArgb(199, 199, 199)), 1);
			if (this.State == MouseState.Over)
			{
				this.G.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), 0, 0, base.Width, base.Height);
			}
			else if (this.State == MouseState.Down)
			{
				base.DrawGradient(Color.FromArgb(45, 45, 45), Color.FromArgb(0, 0, 0), 0, 0, base.Width, base.Height);
				base.DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
				this.G.FillRectangle(new SolidBrush(Color.FromArgb(15, Color.White)), 0, 0, base.Width, base.Height / 2);
				base.DrawBorders(Pens.Black);
				base.DrawBorders(new Pen(Color.FromArgb(73, 73, 73)), 1);
			}
			base.DrawCorners(this.BackColor);
		}
	}
}