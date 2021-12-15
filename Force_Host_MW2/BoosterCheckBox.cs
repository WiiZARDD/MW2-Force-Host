using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace Force_Host_MW2
{
	[DefaultEvent("CheckedChanged")]
	internal class BoosterCheckBox : ThemeControl154
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

		public BoosterCheckBox()
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
			BoosterCheckBox.CheckedChangedEventHandler checkedChangedEventHandler = this.CheckedChanged;
			if (checkedChangedEventHandler != null)
			{
				checkedChangedEventHandler(this);
			}
			base.OnClick(e);
		}

		protected override void PaintHook()
		{
			Rectangle rectangle = new Rectangle(1, 1, checked(base.Height - 2), checked(base.Height - 2));
			this.G.Clear(this.BackColor);
			bool flag = this._Checked;
			if (!flag)
			{
				this.G.FillRectangle(new SolidBrush(Color.FromArgb(129, 129, 129)), rectangle);
			}
			else if (flag)
			{
				this.G.FillRectangle(new SolidBrush(Color.FromArgb(51, 51, 51)), rectangle);
				this.G.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), 1, 1, checked(base.Height - 2), base.Height / 2);
			}
			this.G.DrawRectangle(new Pen(Color.FromArgb(92, 92, 92)), 2, 2, checked(base.Height - 4), checked(base.Height - 4));
			this.G.DrawRectangle(Pens.Black, rectangle);
			base.DrawText(Brushes.White, HorizontalAlignment.Left, 18, 1);
		}

		public event BoosterCheckBox.CheckedChangedEventHandler CheckedChanged;

		public delegate void CheckedChangedEventHandler(object sender);
	}
}