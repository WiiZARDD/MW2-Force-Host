using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Force_Host_MW2
{
	public class SimpleClass
	{
		private Process[] ProcList;

		private IntPtr pHandel;

		private System.Diagnostics.ProcessModule ProcessModule;

		public int BaseAddress;

		private bool Check_res;

		public SimpleClass()
		{
			this.Check_res = true;
		}

		public int Check_Value(string Value)
		{
			int num;
			string value = Value;
			int num1 = 0;
			while (true)
			{
				if (num1 >= value.Length)
				{
					num = Convert.ToInt32(Value);
					break;
				}
				else if (!char.IsNumber(Conversions.ToString(value[num1]), 0))
				{
					this.Check_res = false;
					num = 0;
					break;
				}
				else
				{
					this.Check_res = true;
					num1 = checked(num1 + 1);
				}
			}
			return num;
		}

		[DllImport("user32.dll", CharSet=CharSet.Auto, ExactSpelling=true)]
		public static extern short GetKeyState(Keys virtualKeyCode);

		public bool HotKey(Keys Key)
		{
			return Convert.ToBoolean(SimpleClass.GetKeyState(Key));
		}

		public bool Process_Handle(string ProcessName)
		{
			bool flag;
			try
			{
				this.ProcList = Process.GetProcessesByName(ProcessName);
				if ((int)this.ProcList.Length != 0)
				{
					this.pHandel = this.ProcList[0].Handle;
					this.ProcessModule = this.ProcList[0].MainModule;
					this.BaseAddress = (int)this.ProcessModule.BaseAddress;
					flag = true;
				}
				else
				{
					flag = false;
				}
			}
			catch (Exception exception)
			{
				ProjectData.SetProjectError(exception);
				Console.WriteLine(string.Concat("Process_Handle - ", exception.Message));
				flag = false;
				ProjectData.ClearProjectError();
			}
			return flag;
		}

		private byte[] Read(int Address, int Length)
		{
			byte[] numArray = new byte[checked(checked(Length - 1) + 1)];
			IntPtr zero = IntPtr.Zero;
			SimpleClass.ReadProcessMemory(this.pHandel, new IntPtr(Address), numArray, uint.Parse(Conversions.ToString((int)numArray.Length)), ref zero);
			return numArray;
		}

		public byte[] ReadBytes(int Address, int Length)
		{
			return this.Read(Address, Length);
		}

		public double ReadFloat(int Address, int Length = 4)
		{
			double single = (double)BitConverter.ToSingle(this.Read(Address, Length), 0);
			return single;
		}

		public int ReadInteger(int Address, int Length = 4)
		{
			int num = BitConverter.ToInt32(this.Read(Address, Length), 0);
			return num;
		}

		[DllImport("kernel32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In][Out] byte[] buffer, uint size, ref IntPtr lpNumberOfBytesWritten);

		public string ReadString(int Address, int Length = 4)
		{
			string str = (new ASCIIEncoding()).GetString(this.Read(Address, Length));
			return str;
		}

		private void Write(int Address, int Value)
		{
			byte[] bytes = BitConverter.GetBytes(Value);
			IntPtr zero = IntPtr.Zero;
			SimpleClass.WriteProcessMemory(this.pHandel, new IntPtr(Address), bytes, uint.Parse(Conversions.ToString((int)bytes.Length)), ref zero);
		}

		public void WriteBytes(int Address, byte[] Bytes)
		{
			IntPtr zero = IntPtr.Zero;
			SimpleClass.WriteProcessMemory(this.pHandel, new IntPtr(Address), Bytes, checked((uint)((int)Bytes.Length)), ref zero);
		}

		public void WriteFloat(int Address, float Float)
		{
			byte[] bytes = BitConverter.GetBytes(Float);
			IntPtr zero = IntPtr.Zero;
			SimpleClass.WriteProcessMemory(this.pHandel, new IntPtr(Address), bytes, 4, ref zero);
		}

		public void WriteInteger(int Address, int Value)
		{
			this.Write(Address, Value);
		}

		public void WriteNOP(int Address)
		{
			byte[] numArray = new byte[] { 144, 144, 144, 144, 144, 144, 144, 144, 144, 144, 144, 144, 144, 144, 144, 144, 144, 144, 144, 144, 144, 144, 144, 144, 144, 144, 144 };
			IntPtr zero = IntPtr.Zero;
			SimpleClass.WriteProcessMemory(this.pHandel, new IntPtr(Address), numArray, uint.Parse(Conversions.ToString((int)numArray.Length)), ref zero);
		}

		[DllImport("kernel32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In][Out] byte[] buffer, uint size, ref IntPtr lpNumberOfBytesWritten);

		public void WriteString(int Address, string Text)
		{
			byte[] bytes = (new ASCIIEncoding()).GetBytes(Text);
			IntPtr zero = IntPtr.Zero;
			IntPtr intPtr = this.pHandel;
			IntPtr intPtr1 = new IntPtr(Address);
			uint num = uint.Parse(Conversions.ToString((int)bytes.Length));
			IntPtr length = (IntPtr)Text.Length;
			SimpleClass.WriteProcessMemory(intPtr, intPtr1, bytes, num, ref length);
		}
	}
}