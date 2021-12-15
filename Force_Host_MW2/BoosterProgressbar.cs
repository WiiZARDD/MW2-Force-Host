using System;
using System.Drawing;
using System.Windows.Forms;

namespace Force_Host_MW2
{
	internal class BoosterProgressbar : ThemeControl154
	{
		private int _Value;

		private int _Maximum;

		public int Maximum
		{
			get
			{
				return this._Maximum;
			}
			set
			{
				if (value < 1)
				{
					value = 1;
				}
				if (this._Value > value)
				{
					this._Value = value;
				}
				this._Maximum = value;
				base.Invalidate();
			}
		}

		public int Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if (value > this._Maximum)
				{
					value = this._Maximum;
				}
				if (value < 0)
				{
					value = 0;
				}
				this._Value = value;
				base.Invalidate();
			}
		}

		public BoosterProgressbar()
		{
			this._Maximum = 100;
			base.Transparent = true;
			this.BackColor = Color.Transparent;
		}

		protected override void ColorHook()
		{
		}

		protected override void PaintHook()
		{
			this.G.Clear(this.BackColor);
			base.DrawGradient(Color.FromArgb(226, 226, 226), Color.FromArgb(168, 168, 168), 0, 0, checked((int)Math.Round((double)this._Value / (double)this._Maximum * (double)base.Width - 1)), base.Height);
			this.G.DrawLine(Pens.White, 0, 2, checked((int)Math.Round((double)this._Value / (double)this._Maximum * (double)base.Width - 2)), 2);
			base.CreateRound(0, 0, base.Width, base.Height, 5);
			base.DrawBorders(Pens.Black);
			base.DrawBorders(new Pen(Color.FromArgb(92, 92, 92)), 1);
			base.DrawCorners(this.BackColor);
		}
	}
}