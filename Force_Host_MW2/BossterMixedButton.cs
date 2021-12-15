using System;
using System.Drawing;
using System.Windows.Forms;

namespace Force_Host_MW2
{
	internal class BossterMixedButton : ThemeControl154
	{
		public BossterMixedButton()
		{
			base.Transparent = true;
			this.BackColor = Color.Transparent;
		}

		protected override void ColorHook()
		{
		}

		protected override void PaintHook()
		{
			base.DrawGradient(Color.FromArgb(59, 59, 59), Color.FromArgb(24, 24, 24), 0, 0, base.Width, base.Height);
			base.DrawGradient(Color.FromArgb(204, 204, 204), Color.FromArgb(104, 104, 104), 0, 0, checked(base.Width / 5 + 8), base.Height);
			this.G.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)), 0, 0, base.Width, base.Height / 2);
			base.DrawBorders(new Pen(Color.FromArgb(216, 216, 216)), 1);
			this.G.DrawLine(new Pen(Color.FromArgb(151, 151, 151)), checked(base.Width / 5 + 7), 1, checked(base.Width / 5 + 7), checked(base.Height - 1));
			this.G.DrawLine(new Pen(Color.FromArgb(64, 64, 64)), checked(base.Width / 5 + 8), 1, checked(base.Width / 5 + 8), checked(base.Height - 1));
			this.G.DrawLine(new Pen(Color.FromArgb(87, 87, 87)), checked(base.Width / 5 + 8), 1, base.Width, 1);
			this.G.DrawLine(new Pen(Color.FromArgb(87, 87, 87)), checked(base.Width - 2), 1, checked(base.Width - 2), checked(base.Height - 1));
			this.G.DrawLine(new Pen(Color.FromArgb(87, 87, 87)), checked(base.Width / 5 + 8), checked(base.Height - 2), base.Width, checked(base.Height - 2));
			base.DrawBorders(Pens.Black);
			base.DrawCorners(this.BackColor);
			if (this.State == MouseState.Over)
			{
				this.G.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), checked(base.Width / 5 + 8), 0, base.Width, base.Height);
				base.DrawBorders(new Pen(Color.FromArgb(216, 216, 216)), 1);
				this.G.DrawLine(new Pen(Color.FromArgb(151, 151, 151)), checked(base.Width / 5 + 7), 1, checked(base.Width / 5 + 7), checked(base.Height - 1));
				this.G.DrawLine(new Pen(Color.FromArgb(64, 64, 64)), checked(base.Width / 5 + 8), 1, checked(base.Width / 5 + 8), checked(base.Height - 1));
				this.G.DrawLine(new Pen(Color.FromArgb(87, 87, 87)), checked(base.Width / 5 + 8), 1, base.Width, 1);
				this.G.DrawLine(new Pen(Color.FromArgb(87, 87, 87)), checked(base.Width - 2), 1, checked(base.Width - 2), checked(base.Height - 1));
				this.G.DrawLine(new Pen(Color.FromArgb(87, 87, 87)), checked(base.Width / 5 + 8), checked(base.Height - 2), base.Width, checked(base.Height - 2));
				base.DrawBorders(Pens.Black);
			}
			else if (this.State == MouseState.Down)
			{
				base.DrawGradient(Color.FromArgb(45, 45, 45), Color.FromArgb(0, 0, 0), checked(base.Width / 5 + 8), 0, base.Width, base.Height);
				this.G.FillRectangle(new SolidBrush(Color.FromArgb(15, Color.White)), checked(base.Width / 5 + 8), 0, base.Width, base.Height / 2);
				base.DrawBorders(new Pen(Color.FromArgb(216, 216, 216)), 1);
				this.G.DrawLine(new Pen(Color.FromArgb(151, 151, 151)), checked(base.Width / 5 + 7), 1, checked(base.Width / 5 + 7), checked(base.Height - 1));
				this.G.DrawLine(new Pen(Color.FromArgb(64, 64, 64)), checked(base.Width / 5 + 8), 1, checked(base.Width / 5 + 8), checked(base.Height - 1));
				this.G.DrawLine(new Pen(Color.FromArgb(87, 87, 87)), checked(base.Width / 5 + 8), 1, base.Width, 1);
				this.G.DrawLine(new Pen(Color.FromArgb(87, 87, 87)), checked(base.Width - 2), 1, checked(base.Width - 2), checked(base.Height - 1));
				this.G.DrawLine(new Pen(Color.FromArgb(87, 87, 87)), checked(base.Width / 5 + 8), checked(base.Height - 2), base.Width, checked(base.Height - 2));
				base.DrawBorders(Pens.Black);
			}
			base.DrawText(Brushes.White, HorizontalAlignment.Center, 8, 0);
		}
	}
}