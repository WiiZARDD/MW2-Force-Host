using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Force_Host_MW2
{
	internal abstract class ThemeControl154 : Control
	{
		protected Graphics G;

		protected Bitmap B;

		private bool DoneCreation;

		private bool InPosition;

		protected MouseState State;

		private bool _BackColor;

		private bool _NoRounding;

		private System.Drawing.Image _Image;

		private bool _Transparent;

		private Dictionary<string, Color> Items;

		private string _Customization;

		private System.Drawing.Size _ImageSize;

		private int _LockWidth;

		private int _LockHeight;

		private bool _IsAnimated;

		private Rectangle OffsetReturnRectangle;

		private System.Drawing.Size OffsetReturnSize;

		private Point OffsetReturnPoint;

		private Point CenterReturn;

		private Bitmap MeasureBitmap;

		private Graphics MeasureGraphics;

		private SolidBrush DrawPixelBrush;

		private SolidBrush DrawCornersBrush;

		private Point DrawTextPoint;

		private System.Drawing.Size DrawTextSize;

		private Point DrawImagePoint;

		private LinearGradientBrush DrawGradientBrush;

		private Rectangle DrawGradientRectangle;

		private GraphicsPath DrawRadialPath;

		private PathGradientBrush DrawRadialBrush1;

		private LinearGradientBrush DrawRadialBrush2;

		private Rectangle DrawRadialRectangle;

		private GraphicsPath CreateRoundPath;

		private Rectangle CreateRoundRectangle;

		[Category("Misc")]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				if ((base.IsHandleCreated ? true : value != Color.Transparent))
				{
					base.BackColor = value;
					if (base.Parent != null)
					{
						this.ColorHook();
					}
				}
				else
				{
					this._BackColor = true;
				}
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override System.Drawing.Image BackgroundImage
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override ImageLayout BackgroundImageLayout
		{
			get
			{
				return ImageLayout.None;
			}
			set
			{
			}
		}

		public Bloom[] Colors
		{
			get
			{
				List<Bloom> blooms = new List<Bloom>();
				Dictionary<string, Color>.Enumerator enumerator = this.Items.GetEnumerator();
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, Color> current = enumerator.Current;
					string key = current.Key;
					current = enumerator.Current;
					blooms.Add(new Bloom(key, current.Value));
				}
				return blooms.ToArray();
			}
			set
			{
				Bloom[] bloomArray = value;
				for (int i = 0; i < (int)bloomArray.Length; i = checked(i + 1))
				{
					Bloom bloom = bloomArray[i];
					if (this.Items.ContainsKey(bloom.Name))
					{
						this.Items[bloom.Name] = bloom.Value;
					}
				}
				this.InvalidateCustimization();
				this.ColorHook();
				base.Invalidate();
			}
		}

		public string Customization
		{
			get
			{
				return this._Customization;
			}
			set
			{
				if (Operators.CompareString(value, this._Customization, false) != 0)
				{
					Bloom[] colors = this.Colors;
					try
					{
						byte[] numArray = Convert.FromBase64String(value);
						int length = checked((int)colors.Length - 1);
						for (int i = 0; i <= length; i = checked(i + 1))
						{
							colors[i].Value = Color.FromArgb(BitConverter.ToInt32(numArray, checked(i * 4)));
						}
					}
					catch (Exception exception)
					{
						ProjectData.SetProjectError(exception);
						ProjectData.ClearProjectError();
						return;
					}
					this._Customization = value;
					this.Colors = colors;
					this.ColorHook();
					base.Invalidate();
				}
			}
		}

		public override System.Drawing.Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
				base.Invalidate();
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Color ForeColor
		{
			get
			{
				return Color.Empty;
			}
			set
			{
			}
		}

		public System.Drawing.Image Image
		{
			get
			{
				return this._Image;
			}
			set
			{
				if (value != null)
				{
					this._ImageSize = value.Size;
				}
				else
				{
					this._ImageSize = System.Drawing.Size.Empty;
				}
				this._Image = value;
				base.Invalidate();
			}
		}

		protected System.Drawing.Size ImageSize
		{
			get
			{
				return this._ImageSize;
			}
		}

		protected bool IsAnimated
		{
			get
			{
				return this._IsAnimated;
			}
			set
			{
				this._IsAnimated = value;
				this.InvalidateTimer();
			}
		}

		protected int LockHeight
		{
			get
			{
				return this._LockHeight;
			}
			set
			{
				this._LockHeight = value;
				if ((this.LockHeight == 0 ? false : base.IsHandleCreated))
				{
					base.Height = this.LockHeight;
				}
			}
		}

		protected int LockWidth
		{
			get
			{
				return this._LockWidth;
			}
			set
			{
				this._LockWidth = value;
				if ((this.LockWidth == 0 ? false : base.IsHandleCreated))
				{
					base.Width = this.LockWidth;
				}
			}
		}

		public bool NoRounding
		{
			get
			{
				return this._NoRounding;
			}
			set
			{
				this._NoRounding = value;
				base.Invalidate();
			}
		}

		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				base.Invalidate();
			}
		}

		public bool Transparent
		{
			get
			{
				return this._Transparent;
			}
			set
			{
				this._Transparent = value;
				if (base.IsHandleCreated)
				{
					if ((value ? false : this.BackColor.A != 255))
					{
						throw new Exception("Unable to change value to false while a transparent BackColor is in use.");
					}
					base.SetStyle(ControlStyles.Opaque, !value);
					base.SetStyle(ControlStyles.SupportsTransparentBackColor, value);
					if (!value)
					{
						this.B = null;
					}
					else
					{
						this.InvalidateBitmap();
					}
					base.Invalidate();
				}
			}
		}

		public ThemeControl154()
		{
			this.Items = new Dictionary<string, Color>();
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this._ImageSize = System.Drawing.Size.Empty;
			this.Font = new System.Drawing.Font("Verdana", 8f);
			this.MeasureBitmap = new Bitmap(1, 1);
			this.MeasureGraphics = Graphics.FromImage(this.MeasureBitmap);
			this.DrawRadialPath = new GraphicsPath();
			this.InvalidateCustimization();
		}

		protected Point Center(Rectangle p, Rectangle c)
		{
			this.CenterReturn = new Point(checked(checked(checked(p.Width / 2 - c.Width / 2) + p.X) + c.X), checked(checked(checked(p.Height / 2 - c.Height / 2) + p.Y) + c.Y));
			return this.CenterReturn;
		}

		protected Point Center(Rectangle p, System.Drawing.Size c)
		{
			this.CenterReturn = new Point(checked(checked(p.Width / 2 - c.Width / 2) + p.X), checked(checked(p.Height / 2 - c.Height / 2) + p.Y));
			return this.CenterReturn;
		}

		protected Point Center(Rectangle child)
		{
			Point point = this.Center(base.Width, base.Height, child.Width, child.Height);
			return point;
		}

		protected Point Center(System.Drawing.Size child)
		{
			Point point = this.Center(base.Width, base.Height, child.Width, child.Height);
			return point;
		}

		protected Point Center(int childWidth, int childHeight)
		{
			Point point = this.Center(base.Width, base.Height, childWidth, childHeight);
			return point;
		}

		protected Point Center(System.Drawing.Size p, System.Drawing.Size c)
		{
			Point point = this.Center(p.Width, p.Height, c.Width, c.Height);
			return point;
		}

		protected Point Center(int pWidth, int pHeight, int cWidth, int cHeight)
		{
			this.CenterReturn = new Point(checked(pWidth / 2 - cWidth / 2), checked(pHeight / 2 - cHeight / 2));
			return this.CenterReturn;
		}

		protected abstract void ColorHook();

		public GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
		{
			this.CreateRoundRectangle = new Rectangle(x, y, width, height);
			return this.CreateRound(this.CreateRoundRectangle, slope);
		}

		public GraphicsPath CreateRound(Rectangle r, int slope)
		{
			this.CreateRoundPath = new GraphicsPath(FillMode.Winding);
			this.CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180f, 90f);
			this.CreateRoundPath.AddArc(checked(r.Right - slope), r.Y, slope, slope, 270f, 90f);
			this.CreateRoundPath.AddArc(checked(r.Right - slope), checked(r.Bottom - slope), slope, slope, 0f, 90f);
			this.CreateRoundPath.AddArc(r.X, checked(r.Bottom - slope), slope, slope, 90f, 90f);
			this.CreateRoundPath.CloseFigure();
			return this.CreateRoundPath;
		}

		private void DoAnimation(bool i)
		{
			this.OnAnimation();
			if (i)
			{
				base.Invalidate();
			}
		}

		protected void DrawBorders(Pen p1, int offset)
		{
			this.DrawBorders(p1, 0, 0, base.Width, base.Height, offset);
		}

		protected void DrawBorders(Pen p1, Rectangle r, int offset)
		{
			this.DrawBorders(p1, r.X, r.Y, r.Width, r.Height, offset);
		}

		protected void DrawBorders(Pen p1, int x, int y, int width, int height, int offset)
		{
			this.DrawBorders(p1, checked(x + offset), checked(y + offset), checked(width - checked(offset * 2)), checked(height - checked(offset * 2)));
		}

		protected void DrawBorders(Pen p1)
		{
			this.DrawBorders(p1, 0, 0, base.Width, base.Height);
		}

		protected void DrawBorders(Pen p1, Rectangle r)
		{
			this.DrawBorders(p1, r.X, r.Y, r.Width, r.Height);
		}

		protected void DrawBorders(Pen p1, int x, int y, int width, int height)
		{
			this.G.DrawRectangle(p1, x, y, checked(width - 1), checked(height - 1));
		}

		protected void DrawCorners(Color c1, int offset)
		{
			this.DrawCorners(c1, 0, 0, base.Width, base.Height, offset);
		}

		protected void DrawCorners(Color c1, Rectangle r1, int offset)
		{
			this.DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height, offset);
		}

		protected void DrawCorners(Color c1, int x, int y, int width, int height, int offset)
		{
			this.DrawCorners(c1, checked(x + offset), checked(y + offset), checked(width - checked(offset * 2)), checked(height - checked(offset * 2)));
		}

		protected void DrawCorners(Color c1)
		{
			this.DrawCorners(c1, 0, 0, base.Width, base.Height);
		}

		protected void DrawCorners(Color c1, Rectangle r1)
		{
			this.DrawCorners(c1, r1.X, r1.Y, r1.Width, r1.Height);
		}

		protected void DrawCorners(Color c1, int x, int y, int width, int height)
		{
			if (!this._NoRounding)
			{
				if (!this._Transparent)
				{
					this.DrawCornersBrush = new SolidBrush(c1);
					this.G.FillRectangle(this.DrawCornersBrush, x, y, 1, 1);
					this.G.FillRectangle(this.DrawCornersBrush, checked(x + (checked(width - 1))), y, 1, 1);
					this.G.FillRectangle(this.DrawCornersBrush, x, checked(y + (checked(height - 1))), 1, 1);
					this.G.FillRectangle(this.DrawCornersBrush, checked(x + (checked(width - 1))), checked(y + (checked(height - 1))), 1, 1);
				}
				else
				{
					this.B.SetPixel(x, y, c1);
					this.B.SetPixel(checked(x + (checked(width - 1))), y, c1);
					this.B.SetPixel(x, checked(y + (checked(height - 1))), c1);
					this.B.SetPixel(checked(x + (checked(width - 1))), checked(y + (checked(height - 1))), c1);
				}
			}
		}

		protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height)
		{
			this.DrawGradientRectangle = new Rectangle(x, y, width, height);
			this.DrawGradient(blend, this.DrawGradientRectangle);
		}

		protected void DrawGradient(ColorBlend blend, int x, int y, int width, int height, float angle)
		{
			this.DrawGradientRectangle = new Rectangle(x, y, width, height);
			this.DrawGradient(blend, this.DrawGradientRectangle, angle);
		}

		protected void DrawGradient(ColorBlend blend, Rectangle r)
		{
			this.DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, 90f)
			{
				InterpolationColors = blend
			};
			this.G.FillRectangle(this.DrawGradientBrush, r);
		}

		protected void DrawGradient(ColorBlend blend, Rectangle r, float angle)
		{
			this.DrawGradientBrush = new LinearGradientBrush(r, Color.Empty, Color.Empty, angle)
			{
				InterpolationColors = blend
			};
			this.G.FillRectangle(this.DrawGradientBrush, r);
		}

		protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height)
		{
			this.DrawGradientRectangle = new Rectangle(x, y, width, height);
			this.DrawGradient(c1, c2, this.DrawGradientRectangle);
		}

		protected void DrawGradient(Color c1, Color c2, int x, int y, int width, int height, float angle)
		{
			this.DrawGradientRectangle = new Rectangle(x, y, width, height);
			this.DrawGradient(c1, c2, this.DrawGradientRectangle, angle);
		}

		protected void DrawGradient(Color c1, Color c2, Rectangle r)
		{
			this.DrawGradientBrush = new LinearGradientBrush(r, c1, c2, 90f);
			this.G.FillRectangle(this.DrawGradientBrush, r);
		}

		protected void DrawGradient(Color c1, Color c2, Rectangle r, float angle)
		{
			this.DrawGradientBrush = new LinearGradientBrush(r, c1, c2, angle);
			this.G.FillRectangle(this.DrawGradientBrush, r);
		}

		protected void DrawImage(HorizontalAlignment a, int x, int y)
		{
			this.DrawImage(this._Image, a, x, y);
		}

		protected void DrawImage(System.Drawing.Image image, HorizontalAlignment a, int x, int y)
		{
			if (image != null)
			{
				this.DrawImagePoint = this.Center(image.Size);
				switch (a)
				{
					case HorizontalAlignment.Left:
					{
						this.G.DrawImage(image, x, checked(this.DrawImagePoint.Y + y), image.Width, image.Height);
						break;
					}
					case HorizontalAlignment.Right:
					{
						this.G.DrawImage(image, checked(checked(base.Width - image.Width) - x), checked(this.DrawImagePoint.Y + y), image.Width, image.Height);
						break;
					}
					case HorizontalAlignment.Center:
					{
						this.G.DrawImage(image, checked(this.DrawImagePoint.X + x), checked(this.DrawImagePoint.Y + y), image.Width, image.Height);
						break;
					}
				}
			}
		}

		protected void DrawImage(Point p1)
		{
			this.DrawImage(this._Image, p1.X, p1.Y);
		}

		protected void DrawImage(int x, int y)
		{
			this.DrawImage(this._Image, x, y);
		}

		protected void DrawImage(System.Drawing.Image image, Point p1)
		{
			this.DrawImage(image, p1.X, p1.Y);
		}

		protected void DrawImage(System.Drawing.Image image, int x, int y)
		{
			if (image != null)
			{
				this.G.DrawImage(image, x, y, image.Width, image.Height);
			}
		}

		protected void DrawPixel(Color c1, int x, int y)
		{
			if (!this._Transparent)
			{
				this.DrawPixelBrush = new SolidBrush(c1);
				this.G.FillRectangle(this.DrawPixelBrush, x, y, 1, 1);
			}
			else
			{
				this.B.SetPixel(x, y, c1);
			}
		}

		public void DrawRadial(ColorBlend blend, int x, int y, int width, int height)
		{
			this.DrawRadialRectangle = new Rectangle(x, y, width, height);
			this.DrawRadial(blend, this.DrawRadialRectangle, width / 2, height / 2);
		}

		public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, Point center)
		{
			this.DrawRadialRectangle = new Rectangle(x, y, width, height);
			this.DrawRadial(blend, this.DrawRadialRectangle, center.X, center.Y);
		}

		public void DrawRadial(ColorBlend blend, int x, int y, int width, int height, int cx, int cy)
		{
			this.DrawRadialRectangle = new Rectangle(x, y, width, height);
			this.DrawRadial(blend, this.DrawRadialRectangle, cx, cy);
		}

		public void DrawRadial(ColorBlend blend, Rectangle r)
		{
			this.DrawRadial(blend, r, r.Width / 2, r.Height / 2);
		}

		public void DrawRadial(ColorBlend blend, Rectangle r, Point center)
		{
			this.DrawRadial(blend, r, center.X, center.Y);
		}

		public void DrawRadial(ColorBlend blend, Rectangle r, int cx, int cy)
		{
			this.DrawRadialPath.Reset();
			this.DrawRadialPath.AddEllipse(r.X, r.Y, checked(r.Width - 1), checked(r.Height - 1));
			this.DrawRadialBrush1 = new PathGradientBrush(this.DrawRadialPath)
			{
				CenterPoint = new Point(checked(r.X + cx), checked(r.Y + cy)),
				InterpolationColors = blend
			};
			if (this.G.SmoothingMode != SmoothingMode.AntiAlias)
			{
				this.G.FillEllipse(this.DrawRadialBrush1, r);
			}
			else
			{
				this.G.FillEllipse(this.DrawRadialBrush1, checked(r.X + 1), checked(r.Y + 1), checked(r.Width - 3), checked(r.Height - 3));
			}
		}

		protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height)
		{
			this.DrawRadialRectangle = new Rectangle(x, y, width, height);
			this.DrawRadial(c1, c2, this.DrawRadialRectangle);
		}

		protected void DrawRadial(Color c1, Color c2, int x, int y, int width, int height, float angle)
		{
			this.DrawRadialRectangle = new Rectangle(x, y, width, height);
			this.DrawRadial(c1, c2, this.DrawRadialRectangle, angle);
		}

		protected void DrawRadial(Color c1, Color c2, Rectangle r)
		{
			this.DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, 90f);
			this.G.FillEllipse(this.DrawRadialBrush2, r);
		}

		protected void DrawRadial(Color c1, Color c2, Rectangle r, float angle)
		{
			this.DrawRadialBrush2 = new LinearGradientBrush(r, c1, c2, angle);
			this.G.FillEllipse(this.DrawRadialBrush2, r);
		}

		protected void DrawText(Brush b1, HorizontalAlignment a, int x, int y)
		{
			this.DrawText(b1, this.Text, a, x, y);
		}

		protected void DrawText(Brush b1, string text, HorizontalAlignment a, int x, int y)
		{
			if (text.Length != 0)
			{
				this.DrawTextSize = this.Measure(text);
				this.DrawTextPoint = this.Center(this.DrawTextSize);
				switch (a)
				{
					case HorizontalAlignment.Left:
					{
						this.G.DrawString(text, this.Font, b1, (float)x, (float)(checked(this.DrawTextPoint.Y + y)));
						break;
					}
					case HorizontalAlignment.Right:
					{
						this.G.DrawString(text, this.Font, b1, (float)(checked(checked(base.Width - this.DrawTextSize.Width) - x)), (float)(checked(this.DrawTextPoint.Y + y)));
						break;
					}
					case HorizontalAlignment.Center:
					{
						this.G.DrawString(text, this.Font, b1, (float)(checked(this.DrawTextPoint.X + x)), (float)(checked(this.DrawTextPoint.Y + y)));
						break;
					}
				}
			}
		}

		protected void DrawText(Brush b1, Point p1)
		{
			if (this.Text.Length != 0)
			{
				this.G.DrawString(this.Text, this.Font, b1, p1);
			}
		}

		protected void DrawText(Brush b1, int x, int y)
		{
			if (this.Text.Length != 0)
			{
				this.G.DrawString(this.Text, this.Font, b1, (float)x, (float)y);
			}
		}

		protected SolidBrush GetBrush(string name)
		{
			return new SolidBrush(this.Items[name]);
		}

		protected Color GetColor(string name)
		{
			return this.Items[name];
		}

		protected Pen GetPen(string name)
		{
			return new Pen(this.Items[name]);
		}

		protected Pen GetPen(string name, float width)
		{
			return new Pen(this.Items[name], width);
		}

		private void InvalidateBitmap()
		{
			if ((base.Width == 0 ? false : base.Height != 0))
			{
				this.B = new Bitmap(base.Width, base.Height, PixelFormat.Format32bppPArgb);
				this.G = Graphics.FromImage(this.B);
			}
		}

		private void InvalidateCustimization()
		{
			MemoryStream memoryStream = new MemoryStream(checked(this.Items.Count * 4));
			Bloom[] colors = this.Colors;
			for (int i = 0; i < (int)colors.Length; i = checked(i + 1))
			{
				Color value = colors[i].Value;
				memoryStream.Write(BitConverter.GetBytes(value.ToArgb()), 0, 4);
			}
			memoryStream.Close();
			this._Customization = Convert.ToBase64String(memoryStream.ToArray());
		}

		private void InvalidateTimer()
		{
			if ((base.DesignMode ? false : this.DoneCreation))
			{
				if (!this._IsAnimated)
				{
					ThemeShare.RemoveAnimationCallback(new ThemeShare.AnimationDelegate(this.DoAnimation));
				}
				else
				{
					ThemeShare.AddAnimationCallback(new ThemeShare.AnimationDelegate(this.DoAnimation));
				}
			}
		}

		protected System.Drawing.Size Measure()
		{
			SizeF sizeF = this.MeasureGraphics.MeasureString(this.Text, this.Font, base.Width);
			return sizeF.ToSize();
		}

		protected System.Drawing.Size Measure(string text)
		{
			SizeF sizeF = this.MeasureGraphics.MeasureString(text, this.Font, base.Width);
			return sizeF.ToSize();
		}

		protected Rectangle Offset(Rectangle r, int amount)
		{
			this.OffsetReturnRectangle = new Rectangle(checked(r.X + amount), checked(r.Y + amount), checked(r.Width - checked(amount * 2)), checked(r.Height - checked(amount * 2)));
			return this.OffsetReturnRectangle;
		}

		protected System.Drawing.Size Offset(System.Drawing.Size s, int amount)
		{
			this.OffsetReturnSize = new System.Drawing.Size(checked(s.Width + amount), checked(s.Height + amount));
			return this.OffsetReturnSize;
		}

		protected Point Offset(Point p, int amount)
		{
			this.OffsetReturnPoint = new Point(checked(p.X + amount), checked(p.Y + amount));
			return this.OffsetReturnPoint;
		}

		protected virtual void OnAnimation()
		{
		}

		protected virtual void OnCreation()
		{
		}

		protected override void OnEnabledChanged(EventArgs e)
		{
			if (!base.Enabled)
			{
				this.SetState(MouseState.Block);
			}
			else
			{
				this.SetState(MouseState.None);
			}
			base.OnEnabledChanged(e);
		}

		protected sealed override void OnHandleCreated(EventArgs e)
		{
			this.InvalidateCustimization();
			this.ColorHook();
			if (this._LockWidth != 0)
			{
				base.Width = this._LockWidth;
			}
			if (this._LockHeight != 0)
			{
				base.Height = this._LockHeight;
			}
			this.Transparent = this._Transparent;
			if ((!this._Transparent ? false : this._BackColor))
			{
				this.BackColor = Color.Transparent;
			}
			base.OnHandleCreated(e);
		}

		protected override void OnHandleDestroyed(EventArgs e)
		{
			ThemeShare.RemoveAnimationCallback(new ThemeShare.AnimationDelegate(this.DoAnimation));
			base.OnHandleDestroyed(e);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				this.SetState(MouseState.Down);
			}
			base.OnMouseDown(e);
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			this.InPosition = true;
			this.SetState(MouseState.Over);
			base.OnMouseEnter(e);
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			this.InPosition = false;
			this.SetState(MouseState.None);
			base.OnMouseLeave(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (this.InPosition)
			{
				this.SetState(MouseState.Over);
			}
			base.OnMouseUp(e);
		}

		protected sealed override void OnPaint(PaintEventArgs e)
		{
			if ((base.Width == 0 ? false : base.Height != 0))
			{
				if (!this._Transparent)
				{
					this.G = e.Graphics;
					this.PaintHook();
				}
				else
				{
					this.PaintHook();
					e.Graphics.DrawImage(this.B, 0, 0);
				}
			}
		}

		protected sealed override void OnParentChanged(EventArgs e)
		{
			if (base.Parent != null)
			{
				this.OnCreation();
				this.DoneCreation = true;
				this.InvalidateTimer();
			}
			base.OnParentChanged(e);
		}

		protected sealed override void OnSizeChanged(EventArgs e)
		{
			if (this._Transparent)
			{
				this.InvalidateBitmap();
			}
			base.Invalidate();
			base.OnSizeChanged(e);
		}

		protected abstract void PaintHook();

		protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
		{
			if (this._LockWidth != 0)
			{
				width = this._LockWidth;
			}
			if (this._LockHeight != 0)
			{
				height = this._LockHeight;
			}
			base.SetBoundsCore(x, y, width, height, specified);
		}

		protected void SetColor(string name, Color value)
		{
			if (!this.Items.ContainsKey(name))
			{
				this.Items.Add(name, value);
			}
			else
			{
				this.Items[name] = value;
			}
		}

		protected void SetColor(string name, byte r, byte g, byte b)
		{
			this.SetColor(name, Color.FromArgb((int)r, (int)g, (int)b));
		}

		protected void SetColor(string name, byte a, byte r, byte g, byte b)
		{
			this.SetColor(name, Color.FromArgb((int)a, (int)r, (int)g, (int)b));
		}

		protected void SetColor(string name, byte a, Color value)
		{
			this.SetColor(name, Color.FromArgb((int)a, value));
		}

		private void SetState(MouseState current)
		{
			this.State = current;
			base.Invalidate();
		}
	}
}