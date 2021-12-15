using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Drawing;

namespace Force_Host_MW2
{
	internal struct Bloom
	{
		public string _Name;

		private Color _Value;

		public string Name
		{
			get
			{
				return this._Name;
			}
		}

		public Color Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				this._Value = value;
			}
		}

		public string ValueHex
		{
			get
			{
				byte r = this._Value.R;
				string str = r.ToString("X2", null);
				r = this._Value.G;
				string str1 = r.ToString("X2", null);
				r = this._Value.B;
				string str2 = string.Concat("#", str, str1, r.ToString("X2", null));
				return str2;
			}
			set
			{
				try
				{
					this._Value = ColorTranslator.FromHtml(value);
				}
				catch (Exception exception)
				{
					ProjectData.SetProjectError(exception);
					ProjectData.ClearProjectError();
					return;
				}
			}
		}

		public Bloom(string name, Color value)
		{
			this = new Bloom()
			{
				_Name = name,
				_Value = value
			};
		}
	}
}