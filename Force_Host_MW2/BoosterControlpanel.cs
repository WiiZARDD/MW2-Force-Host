using System;
using System.Drawing;
using System.Windows.Forms;

namespace Force_Host_MW2
{
	internal class BoosterControlpanel : ThemeContainer154
	{
		public BoosterControlpanel()
		{
			base.ControlMode = true;
			base.Transparent = true;
			this.BackColor = Color.Transparent;
			base.Header = 20;
		}

		protected override void ColorHook()
		{
		}

		protected override void PaintHook()
		{
			this.G.Clear(Color.FromArgb(51, 51, 51));
			base.DrawGradient(Color.FromArgb(0, 0, 0), Color.FromArgb(52, 52, 52), 0, 0, base.Width, 20);
			this.G.DrawLine(new Pen(Color.FromArgb(92, 92, 92)), 0, 21, base.Width, 21);
			this.G.DrawLine(Pens.Black, 0, 20, base.Width, 20);
			base.DrawBorders(Pens.Black);
			base.DrawText(Brushes.White, HorizontalAlignment.Left, 8, 3);
			base.DrawBorders(new Pen(Color.FromArgb(92, 92, 92)), 1);
		}
	}
}