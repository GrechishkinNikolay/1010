using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ViewsConsole
{
  /// <summary>
  /// Отрисовщик символов в консоль
  /// </summary>
  public class KernelGraphics
  {
    public short SCREEN_WIDTH_SYMBOLS = 40;
    public short SCREEN_HEIGHT_SYMBOLS = 43;
    [StructLayout(LayoutKind.Sequential)]
    private struct Coord
    {
      public short X;
      public short Y;

      public Coord(short X, short Y)
      {
        this.X = X;
        this.Y = Y;
      }
    };

    [StructLayout(LayoutKind.Explicit)]
    private struct CharUnion
    {
      [FieldOffset(0)] public char UnicodeChar;
      [FieldOffset(0)] public byte AsciiChar;
    }

    [StructLayout(LayoutKind.Explicit)]
    private struct CharInfo
    {
      [FieldOffset(0)] public CharUnion Char;
      [FieldOffset(2)] public short Attributes;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct SmallRect
    {
      public short Left;
      public short Top;
      public short Right;
      public short Bottom;
    }
    /// <summary>
    /// Пустой символ, которым забивается буфер при очистке
    /// </summary>
    private const char BLANK_SYMBOL = ' ';

    /// <summary>
    /// Дескриптор файла консоли
    /// </summary>
    private readonly SafeFileHandle _consoleHandle;

    /// <summary>
    /// Ширина буфера
    /// </summary>
    private short _width;

    /// <summary>
    /// Высота буфера
    /// </summary>
    private short _height;

    /// <summary>
    /// Размер буфера
    /// </summary>
    private SmallRect _screenRect;

    /// <summary>
    /// Буфер символов для вывода в консоль
    /// </summary>
    private CharInfo[] _buffer;

    /// <summary>
    /// Экземпляр синглтона
    /// </summary>
    private static KernelGraphics _instance = null;

    /// <summary>
    /// Получение экземпляра синглтона
    /// </summary>
    public static KernelGraphics Instance
    {
      get
      {
        if (_instance == null)
        {
          _instance = new KernelGraphics();
        }
        return _instance;
      }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    private KernelGraphics()
    {
      _width = SCREEN_WIDTH_SYMBOLS;
      _height = SCREEN_HEIGHT_SYMBOLS;

      Console.SetBufferSize(_width, _height);
      Console.SetWindowSize(_width, _height);

      Console.CursorVisible = false;

      _consoleHandle = CreateFile("CONOUT$", 0x40000000, 2, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
      _buffer = new CharInfo[_width * _height];
      _screenRect = new SmallRect() { Left = 0, Top = 0, Right = _width, Bottom = _height };

      Clear();
    }

    /// <summary>
    /// Заполнение буфера заданным символом определенного цвета
    /// </summary>
    /// <param name="parSymbol">Символ, которым будет заполнен буфер</param>
    /// <param name="parColor">Цвет символа, которым будет заполнен буфер</param>
    public void Fill(char parSymbol, ConsoleColor parColor = ConsoleColor.White)
    {
      byte symbolByte = Console.OutputEncoding.GetBytes(new char[] { parSymbol })[0];

      for (int i = 0; i < _buffer.Length; i++)
      {
        _buffer[i].Attributes = (short)parColor;
        _buffer[i].Char.AsciiChar = symbolByte;
      }
    }

    /// <summary>
    /// Очистка буфера
    /// </summary>
    public void Clear()
    {
      Fill(BLANK_SYMBOL);
    }

    /// <summary>
    /// Запись строки в буфер
    /// </summary>
    /// <param name="parX">X начальной координаты записи</param>
    /// <param name="parY">Y начальной координаты записи</param>
    /// <param name="parStr">Строка для записи</param>
    /// <param name="parColor">Цвет символов строки</param>
    public void PrintString(short parX, short parY, string parStr, ConsoleColor parColor = ConsoleColor.White)
    {
      byte[] strBytes = Console.OutputEncoding.GetBytes(parStr);

      int strToPrintLength = Math.Min(_width - parX, strBytes.Length);
      int initialPrintPosition = parY * _width + parX;
      for (int i = 0; i < strToPrintLength; i++)
      {
        _buffer[initialPrintPosition + i].Attributes = (short)parColor;
        _buffer[initialPrintPosition + i].Char.AsciiChar = strBytes[i];
      }
    }

    /// <summary>
    /// Вывод буфера в консоль и, если задано, его очистка
    /// </summary>
    /// <param name="parClearBuffer">Будет ли очищен буфер после вывода</param>
    /// <returns>Успех вывода буфера в консоль</returns>
    public bool Flush(bool parClearBuffer = true)
    {
      bool success = WriteConsoleOutput(_consoleHandle, _buffer,
              new Coord() { X = _width, Y = _height },
              new Coord() { X = 0, Y = 0 },
              ref _screenRect);
      if (parClearBuffer)
      {
        Clear();
      }
      return success;
    }

    [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    private static extern SafeFileHandle CreateFile(
        string fileName,
        [MarshalAs(UnmanagedType.U4)] uint fileAccess,
        [MarshalAs(UnmanagedType.U4)] uint fileShare,
        IntPtr securityAttributes,
        [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
        [MarshalAs(UnmanagedType.U4)] int flags,
        IntPtr template);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool WriteConsoleOutput(
      SafeFileHandle hConsoleOutput,
      CharInfo[] lpBuffer,
      Coord dwBufferSize,
      Coord dwBufferCoord,
      ref SmallRect lpWriteRegion);
  }
}
