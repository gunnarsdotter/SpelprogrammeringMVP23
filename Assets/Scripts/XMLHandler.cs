using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
using System;

public class XMLHandler: MonoBehaviour
{
    public List<HighScoreEntry> leaderboard;
    void Awake()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/HighScores/"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/HighScores/");
        }
    }
    public void SaveScores(List<HighScoreEntry> scoresToSave)
    {
        leaderboard = scoresToSave;
        XmlSerializer serializer = new XmlSerializer(typeof(List<HighScoreEntry>));
        FileStream stream = new FileStream(Application.persistentDataPath + "/HighScores/highscores.xml", FileMode.Create);
        serializer.Serialize(stream, leaderboard);
        stream.Close();
    }
    public List<HighScoreEntry> LoadScores()
    {
        if (File.Exists(Application.persistentDataPath + "/HighScores/highscores.xml"))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<HighScoreEntry>));
            FileStream stream = new FileStream(Application.persistentDataPath + "/HighScores/highscores.xml", FileMode.Open);
            leaderboard = serializer.Deserialize(stream) as List<HighScoreEntry>;
        }
        return leaderboard;
    }
}
public class HighScoreEntry : IComparable<HighScoreEntry>
{
    public string name;
    public int highscore;
    public HighScoreEntry()
    {
        name = "Undefine";
        highscore = 0;
    }
    public HighScoreEntry(string newName, int scoore)
    {
        name = newName;
        highscore = scoore;
    }
    public int CompareTo(HighScoreEntry other)
    {
        if (other == null)
        {
            return 1;

        }
        return highscore - other.highscore;
    }

}