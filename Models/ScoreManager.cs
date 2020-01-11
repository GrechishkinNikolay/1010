using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class ScoreManager
  {
    /// <summary>
    /// Словарь рекордов
    /// </summary>
    private Dictionary<string, int> _scoreDictionary;
    private const string ScoreFileName = "records.dat";
    public static int ScoreAfterGameOver { get; set; }
    public bool IsRecordsScreen { get; set; }

    public ScoreManager()
    {
      _scoreDictionary = new Dictionary<string, int>();
      ReadFromFile();
    }
    /// <summary>
    /// Возвращает копию словаря с рекордами
    /// </summary>
    public Dictionary<string, int> GetScores() => new Dictionary<string, int>(_scoreDictionary);

    /// <summary>
    /// Обновить счет игрока, если был поставлен новый рекорд
    /// </summary>
    public void UpdateScore(string nick, int score)
    {
      if (_scoreDictionary.ContainsKey(nick)) // Если ник присутствует в рекордах
      {
        if (_scoreDictionary[nick] < score) // Если старый счет меньше нового
        {
          _scoreDictionary[nick] = score;
        }
      }
      else // Ника нет в рекордах
      {
        _scoreDictionary.Add(nick, score);
      }

      WriteDictToFile();
    }

    /// <summary>
    /// Прочитать словарь с рекордами из файла
    /// </summary>
    private void ReadFromFile()
    {
      _scoreDictionary.Clear();
      if (!File.Exists(ScoreFileName)) return;
      using (BinaryReader reader = new BinaryReader(new FileStream(ScoreFileName, FileMode.Open)))
      {
        var count = reader.ReadInt32();
        for (int i = 0; i < count; i++)
        {
          String nick = reader.ReadString();
          int score = reader.ReadInt32();
          _scoreDictionary.Add(nick, score);
        }
      }
    }

    /// <summary>
    /// Записать словарь с рекордами в файл
    /// </summary>
    private void WriteDictToFile()
    {
      using (BinaryWriter writer = new BinaryWriter(new FileStream(ScoreFileName, FileMode.Create)))
      {
        writer.Write(_scoreDictionary.Count);
        foreach (var entry in _scoreDictionary)
        {
          writer.Write(entry.Key);
          writer.Write(entry.Value);
        }
      }
    }
  }
}
