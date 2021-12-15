using System;
using System.Runtime.InteropServices;

namespace Force_Host_MW2
{
	internal class PrecisionTimer : IDisposable
	{
		private bool _Enabled;

		private IntPtr Handle;

		private PrecisionTimer.TimerDelegate TimerCallback;

		public bool Enabled
		{
			get
			{
				return this._Enabled;
			}
		}

		public PrecisionTimer()
		{
		}

		public void Create(uint dueTime, uint period, PrecisionTimer.TimerDelegate callback)
		{
			if (!this._Enabled)
			{
				this.TimerCallback = callback;
				bool flag = PrecisionTimer.CreateTimerQueueTimer(ref this.Handle, IntPtr.Zero, this.TimerCallback, IntPtr.Zero, dueTime, period, 0);
				if (!flag)
				{
					this.ThrowNewException("CreateTimerQueueTimer");
				}
				this._Enabled = flag;
			}
		}

		[DllImport("kernel32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern bool CreateTimerQueueTimer(ref IntPtr handle, IntPtr queue, PrecisionTimer.TimerDelegate callback, IntPtr state, uint dueTime, uint period, uint flags);

		public void Delete()
		{
			if (this._Enabled)
			{
				bool flag = PrecisionTimer.DeleteTimerQueueTimer(IntPtr.Zero, this.Handle, IntPtr.Zero);
				if ((flag ? false : Marshal.GetLastWin32Error() != 997))
				{
					this.ThrowNewException("DeleteTimerQueueTimer");
				}
				this._Enabled = !flag;
			}
		}

		[DllImport("kernel32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern bool DeleteTimerQueueTimer(IntPtr queue, IntPtr handle, IntPtr callback);

		public void Dispose()
		{
			this.Delete();
		}

		private void ThrowNewException(string name)
		{
			throw new Exception(string.Format("{0} failed. Win32Error: {1}", name, Marshal.GetLastWin32Error()));
		}

		public delegate void TimerDelegate(IntPtr r1, bool r2);
	}
}