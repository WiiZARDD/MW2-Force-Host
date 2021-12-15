using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace Force_Host_MW2
{
	[DefaultEvent("CheckedChanged")]
	internal class BoosterRadioButton : ThemeControl154
	{
		private bool _Checked
		{
			get;
			set;
		}

		public bool Checked
		{
			get
			{
				return this._Checked;
			}
			set
			{
				this._Checked = value;
			}
		}

		public BoosterRadioButton()
		{
			this._Checked = false;
			base.Transparent = true;
			this.BackColor = Color.Transparent;
			base.LockHeight = 15;
		}

		protected override void ColorHook()
		{
		}

		protected override void OnClick(EventArgs e)
		{
			this._Checked = !this._Checked;
			BoosterRadioButton.CheckedChangedEventHandler checkedChangedEventHandler = this.CheckedChanged;
			if (checkedChangedEventHandler != null)
			{
				checkedChangedEventHandler(this);
			}
			base.OnClick(e);
		}

		protected override void PaintHook()
		{
			this.G.Clear(this.BackColor);
			bool flag = this._Checked;
			if (!flag)
			{
				this.G.FillEllipse(new SolidBrush(Color.FromArgb(129, 129, 129)), 2, 2, checked(base.Height - 3), checked(base.Height - 3));
			}
			else if (flag)
			{
				this.G.FillEllipse(new SolidBrush(Color.FromArgb(51, 51, 51)), 2, 2, checked(base.Height - 3), checked(base.Height - 3));
				this.G.FillEllipse(new SolidBrush(Color.FromArgb(30, Color.White)), 2, 2, checked(base.Height - 3), base.Height / 2);
			}
			this.G.DrawEllipse(new Pen(Color.FromArgb(92, 92, 92)), 2, 2, checked(base.Height - 3), checked(base.Height - 3));
			this.G.DrawEllipse(Pens.Black, 1, 1, checked(base.Height - 1), checked(base.Height - 1));
			base.DrawText(Brushes.White, HorizontalAlignment.Left, 18, 1);
		}

		public event BoosterRadioButton.CheckedChangedEventHandler CheckedChanged;

		public delegate void CheckedChangedEventHandler(object sender);
	}
}