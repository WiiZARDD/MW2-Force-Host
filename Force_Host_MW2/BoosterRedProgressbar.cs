using System;
using System.Drawing;
using System.Windows.Forms;

namespace Force_Host_MW2
{
	internal class BoosterRedProgressbar : ThemeControl154
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

		public BoosterRedProgressbar()
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
			this.G.Clear(Color.FromArgb(66, 66, 66));
			this.G.FillRectangle(new SolidBrush(Color.FromArgb(204, 204, 204)), 0, 0, checked((int)Math.Round((double)this._Value / (double)this._Maximum * (double)base.Width - 1)), base.Height);
			base.CreateRound(0, 0, base.Width, base.Height, 5);
			this.G.DrawLine(new Pen(Color.FromArgb(32, 32, 32)), 0, 1, base.Width, 1);
			base.DrawBorders(new Pen(Color.FromArgb(70, 70, 70)), 0);
			this.G.DrawLine(new Pen(Color.FromArgb(138, 139, 138)), 0, checked(base.Height - 1), base.Width, checked(base.Height - 1));
			base.DrawGradient(Color.FromArgb(70, 70, 70), Color.FromArgb(138, 139, 138), 0, 0, 1, base.Height);
			base.DrawGradient(Color.FromArgb(70, 70, 70), Color.FromArgb(138, 139, 138), checked(base.Width - 1), 0, base.Width, base.Height);
		}
	}
}