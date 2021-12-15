using System;
using System.Drawing;
using System.Windows.Forms;

namespace Force_Host_MW2
{
	internal class BoosterTheme : ThemeContainer154
	{
		public BoosterTheme()
		{
			base.TransparencyKey = Color.Fuchsia;
			this.BackColor = Color.FromArgb(51, 51, 51);
			base.Header = 25;
		}

		protected override void ColorHook()
		{
		}

		protected override void PaintHook()
		{
			this.G.Clear(Color.FromArgb(51, 51, 51));
			base.DrawGradient(Color.FromArgb(29, 29, 29), Color.FromArgb(65, 65, 65), 0, 28, base.Width, checked(base.Height / 2 - 10));
			base.DrawGradient(Color.FromArgb(87, 87, 87), Color.FromArgb(49, 49, 49), 0, 0, base.Width, 25);
			this.G.DrawLine(Pens.Black, 0, 25, base.Width, 25);
			this.G.DrawLine(new Pen(Color.FromArgb(22, 22, 22)), 0, 26, base.Width, 26);
			this.G.FillRectangle(new SolidBrush(Color.FromArgb(169, 169, 169)), 0, 27, base.Width, 27);
			this.G.FillRectangle(new SolidBrush(Color.FromArgb(45, Color.White)), 0, 27, base.Width, 13);
			this.G.DrawLine(new Pen(Color.FromArgb(38, 38, 38)), 0, checked(base.Height - 25), base.Width, checked(base.Height - 25));
			this.G.DrawLine(new Pen(Color.FromArgb(64, 64, 64)), 0, checked(base.Height - 24), base.Width, checked(base.Height - 24));
			base.DrawBorders(Pens.Black);
			base.DrawBorders(new Pen(Color.FromArgb(92, 92, 92)), 1);
			base.DrawCorners(Color.Fuchsia);
			base.DrawText(Brushes.Black, HorizontalAlignment.Center, 0, 0);
			base.DrawText(Brushes.White, HorizontalAlignment.Center, 0, 1);
		}
	}
}