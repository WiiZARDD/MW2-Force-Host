using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Force_Host_MW2
{
	[DesignerGenerated]
	public class Form1 : Form
	{
		private string Game;

		private SimpleClass w;

		private Point nStartPos;

		private Point nDragPos;

		private int host;

		private const int Key_NONE = 0;

		private const int WM_HOTKEY = 786;

		private IContainer components;
        private object _BoosterTheme1;
        private object _BoosterTopButton1;
        private object stackVariable1;
        private object _Button2;
        private object _Button3;
        private object _Label2;
        private object _Label3;
        private object _Timer1;

        internal virtual BoosterTheme BoosterTheme1
		{
			get
			{
                object stackVariable1 = this._BoosterTheme1;
                return (BoosterTheme)stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				MouseEventHandler mouseEventHandler = new MouseEventHandler(this.MouseMove);
				MouseEventHandler mouseEventHandler1 = new MouseEventHandler(this.MouseDown);
				BoosterTheme boosterTheme = (BoosterTheme)this._BoosterTheme1;
				if (boosterTheme != null)
				{
					boosterTheme.MouseMove -= mouseEventHandler;
					boosterTheme.MouseDown -= mouseEventHandler1;
				}
				this._BoosterTheme1 = value;
				boosterTheme = (BoosterTheme)this._BoosterTheme1;
				if (boosterTheme != null)
				{
					boosterTheme.MouseMove += mouseEventHandler;
					boosterTheme.MouseDown += mouseEventHandler1;
				}
			}
		}

		internal virtual BoosterTopButton BoosterTopButton1
		{
			get
			{
                object stackVariable1 = this._BoosterTopButton1;
                return (BoosterTopButton)stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.BoosterTopButton1_Click);
				BoosterTopButton boosterTopButton = (BoosterTopButton)this._BoosterTopButton1;
				if (boosterTopButton != null)
				{
					boosterTopButton.Click -= eventHandler;
				}
				this._BoosterTopButton1 = value;
				boosterTopButton = (BoosterTopButton)this._BoosterTopButton1;
				if (boosterTopButton != null)
				{
					boosterTopButton.Click += eventHandler;
				}
			}
		}

		internal virtual Button Button1
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Button Button2
		{
			get
			{
				stackVariable1 = this._Button2;
				return (Button)stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Button2_Click);
				Button button = (Button)this._Button2;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._Button2 = value;
				button = (Button)this._Button2;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		internal virtual Button Button3
		{
			get
			{
				stackVariable1 = this._Button3;
				return (Button)stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Button3_Click);
				Button button = (Button)this._Button3;
				if (button != null)
				{
					button.Click -= eventHandler;
				}
				this._Button3 = value;
				button = (Button)this._Button3;
				if (button != null)
				{
					button.Click += eventHandler;
				}
			}
		}

		internal virtual Label Label1
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label Label2
		{
			get
			{
				stackVariable1 = this._Label2;
				return (Label)stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Label2_Click);
				Label label = (Label)this._Label2;
				if (label != null)
				{
					label.Click -= eventHandler;
				}
				this._Label2 = value;
				label = (Label)this._Label2;
				if (label != null)
				{
					label.Click += eventHandler;
				}
			}
		}

		internal virtual Label Label3
		{
			get
			{
				stackVariable1 = this._Label3;
				return (Label)stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Label3_Click);
				Label label = (Label)this._Label3;
				if (label != null)
				{
					label.Click -= eventHandler;
				}
				this._Label3 = value;
				label = (Label)this._Label3;
				if (label != null)
				{
					label.Click += eventHandler;
				}
			}
		}

		internal virtual Label Label4
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Label Label5
		{
			get;
			[MethodImpl(MethodImplOptions.Synchronized)]
			set;
		}

		internal virtual Timer Timer1
		{
			get
			{
				stackVariable1 = this._Timer1;
				return (Timer)stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = new EventHandler(this.Timer1_Tick);
				Timer timer = (Timer)this._Timer1;
				if (timer != null)
				{
					timer.Tick -= eventHandler;
				}
				this._Timer1 = value;
				timer = (Timer)this._Timer1;
				if (timer != null)
				{
					timer.Tick += eventHandler;
				}
			}
		}

		public Form1()
		{
			base.Load += new EventHandler(this.Form1_Load);
			this.Game = "iw4mp";
			this.w = new SimpleClass();
			this.host = 20135204;
			this.InitializeComponent();
		}

		private void BoosterTopButton1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			if ((int)Process.GetProcessesByName(this.Game).Length <= 0)
			{
				Interaction.MsgBox("MW2 was not found... Please start the Game first!", MsgBoxStyle.Exclamation, "ERROR");
			}
			else
			{
				this.Timer1.Start();
				this.Label4.Text = "FORCE HOST: Enabled";
			}
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			this.Timer1.Stop();
			this.w.Process_Handle(this.Game);
			this.w.WriteInteger(checked(this.w.ReadInteger(this.host, 4) + 12), 4);
			this.Label4.Text = "FORCE HOST: Disabled";
		}

		[DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if ((!disposing ? false : this.components != null))
				{
					this.components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Form1.RegisterHotKey(base.Handle, 1, 0, 106);
			Form1.RegisterHotKey(base.Handle, 2, 0, 109);
		}

		[DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(Form1));
			this.Button1 = new Button();
			this.Timer1 = new Timer(this.components);
			this.BoosterTheme1 = new BoosterTheme();
			this.Label5 = new Label();
			this.Label4 = new Label();
			this.Label3 = new Label();
			this.Label2 = new Label();
			this.Label1 = new Label();
			this.Button3 = new Button();
			this.Button2 = new Button();
			this.BoosterTopButton1 = new BoosterTopButton();
			this.BoosterTheme1.SuspendLayout();
			base.SuspendLayout();
			this.Button1.Location = new Point(21, 26);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(75, 23);
			this.Button1.TabIndex = 0;
			this.Button1.Text = "Button1";
			this.Button1.UseVisualStyleBackColor = true;
			this.Timer1.Interval = 500;
			this.BoosterTheme1.BackColor = Color.FromArgb(51, 51, 51);
			this.BoosterTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.BoosterTheme1.Colors = new Bloom[0];
			this.BoosterTheme1.Controls.Add(this.BoosterTopButton1);
			this.BoosterTheme1.Controls.Add(this.Label5);
			this.BoosterTheme1.Controls.Add(this.Label4);
			this.BoosterTheme1.Controls.Add(this.Label3);
			this.BoosterTheme1.Controls.Add(this.Label2);
			this.BoosterTheme1.Controls.Add(this.Label1);
			this.BoosterTheme1.Controls.Add(this.Button3);
			this.BoosterTheme1.Controls.Add(this.Button2);
			this.BoosterTheme1.Customization = "";
			this.BoosterTheme1.Dock = DockStyle.Fill;
			this.BoosterTheme1.Font = new System.Drawing.Font("Verdana", 8f);
			this.BoosterTheme1.Image = null;
			this.BoosterTheme1.Location = new Point(0, 0);
			this.BoosterTheme1.Movable = false;
			this.BoosterTheme1.Name = "BoosterTheme1";
			this.BoosterTheme1.NoRounding = false;
			this.BoosterTheme1.Sizable = false;
			this.BoosterTheme1.Size = new System.Drawing.Size(237, 181);
			this.BoosterTheme1.SmartBounds = true;
			this.BoosterTheme1.StartPosition = FormStartPosition.WindowsDefaultLocation;
			this.BoosterTheme1.TabIndex = 1;
			this.BoosterTheme1.Text = "MW2 FORCE HOST TOOL";
			this.BoosterTheme1.TransparencyKey = Color.Fuchsia;
			this.BoosterTheme1.Transparent = false;
			this.Label5.AutoSize = true;
			this.Label5.ForeColor = Color.White;
			this.Label5.Location = new Point(6, 125);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(228, 26);
			this.Label5.TabIndex = 6;
			this.Label5.Text = "This is a fixed version for MW2\r\n By: github.com/WiiZARDD";
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.Label4.ForeColor = Color.White;
			this.Label4.Location = new Point(5, 112);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(189, 13);
			this.Label4.TabIndex = 5;
			this.Label4.Text = "FORCE HOST: Disabled";
			this.Label3.AutoSize = true;
			this.Label3.Cursor = Cursors.Hand;
			this.Label3.Font = new System.Drawing.Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.Label3.ForeColor = Color.FromArgb(20, 20, 20);
			this.Label3.Location = new Point(137, 163);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(63, 13);
			this.Label3.TabIndex = 4;
			this.Label3.Text = "Github";
			this.Label2.AutoSize = true;
			this.Label2.Cursor = Cursors.Hand;
			this.Label2.Font = new System.Drawing.Font("Verdana", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.Label2.ForeColor = Color.Silver;
			this.Label2.Location = new Point(206, 163);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(24, 13);
			this.Label2.TabIndex = 3;
			this.Label2.Text = "IG";
			this.Label1.AutoSize = true;
			this.Label1.ForeColor = Color.White;
			this.Label1.Location = new Point(5, 163);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(64, 13);
			this.Label1.TabIndex = 2;
			this.Label1.Text = "@WiiZARDD <3";
			this.Button3.BackColor = Color.Transparent;
			this.Button3.FlatStyle = FlatStyle.Flat;
			this.Button3.Font = new System.Drawing.Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.Button3.ForeColor = Color.FromArgb(20, 20, 20);
			this.Button3.Location = new Point(121, 66);
			this.Button3.Name = "Button3";
			this.Button3.Size = new System.Drawing.Size(103, 32);
			this.Button3.TabIndex = 1;
			this.Button3.Text = "- (OFF)";
			this.Button3.UseVisualStyleBackColor = false;
			this.Button2.BackColor = Color.Transparent;
			this.Button2.FlatStyle = FlatStyle.Flat;
			this.Button2.Font = new System.Drawing.Font("Verdana", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.Button2.ForeColor = Color.FromArgb(20, 20, 20);
			this.Button2.Location = new Point(12, 66);
			this.Button2.Name = "Button2";
			this.Button2.Size = new System.Drawing.Size(103, 32);
			this.Button2.TabIndex = 0;
			this.Button2.Text = "* (ON)";
			this.Button2.UseVisualStyleBackColor = false;
			this.BoosterTopButton1.BackColor = Color.Transparent;
			this.BoosterTopButton1.Colors = new Bloom[0];
			this.BoosterTopButton1.Cursor = Cursors.Hand;
			this.BoosterTopButton1.Customization = "";
			this.BoosterTopButton1.Font = new System.Drawing.Font("Verdana", 8f);
			this.BoosterTopButton1.Image = null;
			this.BoosterTopButton1.Location = new Point(209, 2);
			this.BoosterTopButton1.Name = "BoosterTopButton1";
			this.BoosterTopButton1.NoRounding = false;
			this.BoosterTopButton1.Size = new System.Drawing.Size(24, 21);
			this.BoosterTopButton1.TabIndex = 7;
			this.BoosterTopButton1.Text = "X";
			this.BoosterTopButton1.Transparent = true;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(237, 181);
			base.Controls.Add(this.BoosterTheme1);
			base.Controls.Add(this.Button1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Form1";
			this.Text = "MW2 FORCE HOST TOOL";
			base.TransparencyKey = Color.Fuchsia;
			this.BoosterTheme1.ResumeLayout(false);
			this.BoosterTheme1.PerformLayout();
			base.ResumeLayout(false);
		}

		private void Label2_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.instagram.com/WiiZARDD_");
		}

		private void Label3_Click(object sender, EventArgs e)
		{
			Process.Start("https://www.github.com/WiiZARDD");
		}

		private void MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				this.nStartPos = base.Location;
				this.nDragPos = base.PointToScreen(new Point(e.X, e.Y));
			}
		}

		private void MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				Point screen = base.PointToScreen(new Point(e.X, e.Y));
				base.Location = new Point(checked(checked(this.nStartPos.X + screen.X) - this.nDragPos.X), checked(checked(this.nStartPos.Y + screen.Y) - this.nDragPos.Y));
			}
		}

		[DllImport("user32", CharSet=CharSet.Ansi, ExactSpelling=true, SetLastError=true)]
		private static extern int RegisterHotKey(IntPtr hWnd, int id, int fsModifier, int vk);

		private void Timer1_Tick(object sender, EventArgs e)
		{
			this.w.Process_Handle(this.Game);
			this.w.WriteInteger(checked(this.w.ReadInteger(this.host, 4) + 12), 1);
		}

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 786)
			{
				IntPtr wParam = m.WParam;
				if (wParam == (IntPtr)1)
				{
					this.Button2.PerformClick();
				}
				else if (wParam == (IntPtr)2)
				{
					this.Button3.PerformClick();
				}
			}
			base.WndProc(ref m);
		}
	}
}