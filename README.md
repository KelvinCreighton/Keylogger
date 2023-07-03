# Keylogger

This C# program monitors and logs keyboard input on a Windows system. It runs in the background and captures keystrokes, storing them in a log file.

## Features

- Logs keyboard input to a file (`logs.txt`).
- Supports logging of various keys, including letters, numbers, punctuation, and special keys like Tab and Space.
- Implements a key sequence (`EXITPROGRAM`) that, when typed, allows the user to exit the program.

## How to Use

1. Clone or download the program to your local machine.
2. Run the compile.bat file to generate the executable (not required)
3. Run the executable file "Program.exe"
4. The program will start logging keyboard input to a file named `logs.txt`.
5. If you are given an virus warning you may have to allow it in windows defender or other antimalware
6. To exit the program, type the key sequence `EXITPROGRAM`.

## Dependencies

The program relies on the following namespaces from the .NET Framework:

- `System`
- `System.Runtime.InteropServices`
- `System.Diagnostics`
- `System.Windows.Forms`
- `System.IO`

## Disclaimer

Please note that the use of keyloggers or any software for unauthorized monitoring of computer activities is illegal and unethical. This program is intended for educational purposes only or for use with proper authorization. The developer assumes no responsibility for any misuse of this program.
