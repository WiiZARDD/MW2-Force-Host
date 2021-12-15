using System;
using System.Drawing;
using System.Windows.Forms;

namespace Force_Host_MW2
{
	internal class BoosterButton : ThemeControl154
	{
		public BoosterButton()
		{
			base.Transparent = true;
			this.BackColor = Color.Transparent;
		}

		protected override void ColorHook()
		{
		}

		protected override void PaintHook()
		{
			base.DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(95, 95, 95), 0, 2, base.Width / 2, base.Height / 2, 45f);
			base.DrawGradient(Color.FromArgb(95, 95, 95), Color.FromArgb(0, 0, 0), base.Width / 2, 2, checked(base.Width - 15), base.Height / 2, -45f);
			base.DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(95, 95, 95), 0, base.Height / 2, base.Width / 2, base.Height, 45f);
			base.DrawGradient(Color.FromArgb(95, 95, 95), Color.FromArgb(0, 0, 0), base.Width / 2, base.Height / 2, base.Width, base.Height / 2, 315f);
			base.DrawBorders(Pens.Black, 0);
			base.DrawBorders(Pens.Black, 1);
			base.DrawBorders(new Pen(Color.FromArgb(95, 95, 95)), 3);
			this.G.DrawLine(new Pen(Color.FromArgb(93, 93, 93)), 3, 3, checked(base.Width - 5), 3);
			this.G.DrawLine(new Pen(Color.FromArgb(73, 73, 73)), 0, checked(base.Height - 1), base.Width, checked(base.Height - 1));
			base.DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(73, 73, 73), 0, 0, 1, base.Height);
			base.DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(73, 73, 73), checked(base.Width - 1), 0, 1, base.Height);
			if (this.State == MouseState.Over)
			{
				base.DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(95, 95, 95), 0, 2, base.Width / 2, base.Height / 2, 45f);
				base.DrawGradient(Color.FromArgb(95, 95, 95), Color.FromArgb(0, 0, 0), base.Width / 2, 2, checked(base.Width - 15), base.Height / 2, -45f);
				base.DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(95, 95, 95), 0, base.Height / 2, base.Width / 2, base.Height, 45f);
				base.DrawGradient(Color.FromArgb(95, 95, 95), Color.FromArgb(0, 0, 0), base.Width / 2, base.Height / 2, base.Width, base.Height / 2, 315f);
				this.G.FillRectangle(new SolidBrush(Color.FromArgb(13, Color.White)), 0, 0, base.Width, checked(base.Height / 2 - 7));
				base.DrawBorders(Pens.Black, 0);
				base.DrawBorders(Pens.Black, 1);
				base.DrawBorders(new Pen(Color.FromArgb(95, 95, 95)), 3);
				this.G.DrawLine(new Pen(Color.FromArgb(93, 93, 93)), 3, 3, checked(base.Width - 5), 3);
				this.G.DrawLine(new Pen(Color.FromArgb(73, 73, 73)), 0, checked(base.Height - 1), base.Width, checked(base.Height - 1));
				base.DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(73, 73, 73), 0, 0, 1, base.Height);
				base.DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(73, 73, 73), checked(base.Width - 1), 0, 1, base.Height);
			}
			else if (this.State == MouseState.Down)
			{
				base.DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(95, 95, 95), 0, 2, base.Width / 2, base.Height / 2, 45f);
				base.DrawGradient(Color.FromArgb(95, 95, 95), Color.FromArgb(0, 0, 0), base.Width / 2, 2, checked(base.Width - 15), base.Height / 2, -45f);
				base.DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(95, 95, 95), 0, base.Height / 2, base.Width / 2, base.Height, 45f);
				base.DrawGradient(Color.FromArgb(95, 95, 95), Color.FromArgb(0, 0, 0), base.Width / 2, base.Height / 2, base.Width, base.Height / 2, 315f);
				this.G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.Black)), 0, 0, base.Width, checked(base.Height / 2 - 7));
				base.DrawBorders(Pens.Black, 0);
				base.DrawBorders(Pens.Black, 1);
				base.DrawBorders(new Pen(Color.FromArgb(95, 95, 95)), 3);
				this.G.DrawLine(new Pen(Color.FromArgb(93, 93, 93)), 3, 3, checked(base.Width - 5), 3);
				this.G.DrawLine(new Pen(Color.FromArgb(73, 73, 73)), 0, checked(base.Height - 1), base.Width, checked(base.Height - 1));
				base.DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(73, 73, 73), 0, 0, 1, base.Height);
				base.DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(73, 73, 73), checked(base.Width - 1), 0, 1, base.Height);
			}
			base.DrawCorners(this.BackColor);
			base.DrawText(Brushes.White, HorizontalAlignment.Center, 0, 0);
		}
	}
}