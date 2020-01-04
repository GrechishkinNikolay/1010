using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewConsole
{
  using Microsoft.Win32.SafeHandles;
  using System;
  using System.IO;
  using System.Runtime.InteropServices;

  namespace CLIViews
  {
    //public class KernelGraphics
    //{
    //  [StructLayout(LayoutKind.Sequential)]
    //  private struct Coord
    //  {
    //    public short X;
    //    public short Y;

    //    public Coord(short X, short Y)
    //    {
    //      this.X = X;
    //      this.Y = Y;
    //    }
    //  };

    //  [StructLayout(LayoutKind.Explicit)]
    //  private struct CharUnion
    //  {
    //    [FieldOffset(0)] public char UnicodeChar;
    //    [FieldOffset(0)] public byte AsciiChar;
    //  }

    //  [StructLayout(LayoutKind.Explicit)]
    //  private struct CharInfo
    //  {
    //    [FieldOffset(0)] public CharUnion Char;
    //    [FieldOffset(2)] public short Attributes;
    //  }

    //  [StructLayout(LayoutKind.Sequential)]
    //  private struct SmallRect
    //  {
    //    public short Left;
    //    public short Top;
    //    public short Right;
    //    public short Bottom;
    //  }

    //  const Char BLANK_SYMBOL = ' ';

    //  private short _width;
    //  private short _height;

    //  private readonly SafeFileHandle _consoleHandle;
    //  private SmallRect _screenRect;

    //  private CharInfo[] _buffer;

    //  public KernelGraphics(short parWidth, short parHeight)
    //  {
    //    Console.CursorVisible = false;

    //    _consoleHandle = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
    //    _buffer = new CharInfo[_width * _height];
    //    _screenRect = new SmallRect() { Left = 0, Top = 0, Right = _width, Bottom = _height };

    //    Clear();
    //  }

    //  public void Fill(char parSymbol, EColor parColor = EColor.White)
    //  {
    //    for (int i = 0; i < _buffer.Length; i++)
    //    {
    //      _buffer[i].Attributes = (short)parColor;
    //      _buffer[i].Char.UnicodeChar = parSymbol;
    //    }
    //  }

    //  public void Clear()
    //  {
    //    Fill(BLANK_SYMBOL);
    //  }

    //  public void PrintString(short parX, short parY, string parStr, EColor parColor = EColor.White)
    //  {
    //    int strToPrintLength = Math.Min(_width - parX, parStr.Length);
    //    int initialPrintPosition = parY * _width + parX;
    //    for (int i = 0; i < strToPrintLength; i++)
    //    {
    //      _buffer[initialPrintPosition + i].Attributes = (short)parColor;
    //      _buffer[initialPrintPosition + i].Char.UnicodeChar = parStr[i];
    //    }
    //  }

    //  public void DrawRect(short parX, short parY, short parWidth, short parHeight, char parSymbol, EColor parColor, bool parFill = false)
    //  {
    //    for (int i = 0; i < parHeight; i++)
    //    {
    //      for (int j = 0; j < parWidth; j++)
    //      {
    //        bool insideFillByRow = i > 0 && i < _height - 1;
    //        bool insideFillByColumn = j > 0 && j < _width - 1;
    //        bool insideFill = insideFillByRow && insideFillByColumn;
    //        if (!parFill && insideFill)
    //        {
    //          break;
    //        }
    //        int absoluteX = parX + j;
    //        int absoluteY = parY + i;
    //        int bufferPosition = absoluteY * _width + absoluteX;
    //        _buffer[bufferPosition].Attributes = (short)parColor;
    //        _buffer[bufferPosition].Char.UnicodeChar = parSymbol;
    //      }
    //    }
    //  }

    //  public bool Flush()
    //  {
    //    bool success = WriteConsoleOutput(_consoleHandle, _buffer,
    //            new Coord() { X = _width, Y = _height },
    //            new Coord() { X = 0, Y = 0 },
    //            ref _screenRect);
    //    Clear();
    //    return success;
    //  }

    //  [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    //  private static extern SafeFileHandle CreateFile(
    //      string fileName,
    //      [MarshalAs(UnmanagedType.U4)] uint fileAccess,
    //      [MarshalAs(UnmanagedType.U4)] uint fileShare,
    //      IntPtr securityAttributes,
    //      [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
    //      [MarshalAs(UnmanagedType.U4)] int flags,
    //      IntPtr template);

    //  [DllImport("kernel32.dll", SetLastError = true)]
    //  private static extern bool WriteConsoleOutput(
    //    SafeFileHandle hConsoleOutput,
    //    CharInfo[] lpBuffer,
    //    Coord dwBufferSize,
    //    Coord dwBufferCoord,
    //    ref SmallRect lpWriteRegion);
    //}
  }
}
