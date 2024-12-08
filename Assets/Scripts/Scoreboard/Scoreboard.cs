using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScoreboardEntriesTable
{
    public ScoreboardEntriesTable(List<ScoreboardEntry> entries)
    {
        this.entries = entries; 
    }
    public List<ScoreboardEntry> entries = new List<ScoreboardEntry>();
}

public class Scoreboard : MonoBehaviour, ICommandTranslator
{
    [SerializeField] private int maxEntries;
    private List<ScoreboardEntry> entries = new List<ScoreboardEntry>();

    public event Action<ScoreboardEntry> OnEntryAdded;

    [SerializeField] private ScoreboardView scoreboardView;

    private void Start()
    {
        GameSession.Instance?.AddCommandTranslator(this);
        string jsonScoreboardEntries = PlayerPrefs.GetString("ScoreboardEntriesTableTest"); //Binary file
        Debug.Log(jsonScoreboardEntries);
        ScoreboardEntriesTable entriesTable = JsonUtility.FromJson<ScoreboardEntriesTable>(jsonScoreboardEntries);
        if (entriesTable == null)
            return;
        if (entriesTable.entries == null)
            return;
      
        entries = entriesTable.entries;
        SortScoreboardEntriesByHighscore(entries);
        List<PlayerScoreboardCardData> scoreboardCardDatas = new List<PlayerScoreboardCardData>();  
        foreach (var entry in entries)
        {
            PlayerScoreboardCardData cardData = new PlayerScoreboardCardData(entry.Name, entry.Score.ToString());
            scoreboardCardDatas.Add(cardData);
        }
        scoreboardView.Init();
        Debug.Log("DATA LOADED, PASS TO VIEW");
        scoreboardView.AddPlayerCards(scoreboardCardDatas);     
    }

    public void AddScoreboardEntry(string entryName, int entryScore)
    {
        ScoreboardEntry entry = new ScoreboardEntry(entryName, entryScore);
        entries.Add(entry);
        OnEntryAdded?.Invoke(entry);
    }

    public void SortScoreboardEntriesByHighscore(List<ScoreboardEntry> entries)
    {
        entries.Sort((x,y) => y.Score.CompareTo(x.Score));
        Debug.Log("SORTED SCOREBOARD ENTRIES");
        for (int i = 0; i < entries.Count; i++)
        {
            Debug.Log("Player: " + entries[i].Name + " Score: " + entries[i].Score);
        }
    }

    public void SortScoreboardCardsDatasByHighscore(List<PlayerScoreboardCardData> scoreboardCardDatas)
    {
        scoreboardCardDatas.Sort((x, y) => y.playerScore.CompareTo(x.playerScore));
        Debug.Log("Sorted Scoreboard Card Datas");
        for (int i = 0; i < scoreboardCardDatas.Count; i++)
        {
            Debug.Log("Player: " + scoreboardCardDatas[i].playerName + " Score: " + scoreboardCardDatas[i].playerScore);
        }
    }

    public void AddScoreboardEntry(ScoreboardEntry entry)
    {
        entries.Add(entry);
        OnEntryAdded?.Invoke(entry);
        SaveScoreboardEntriesTable();
    }   

    public void SaveScoreboardEntriesTable()
    {
        SortScoreboardEntriesByHighscore(entries);
        ScoreboardEntriesTable scoreboardEntriesTable = new ScoreboardEntriesTable(entries);
        string jsonScoreboardEntries = JsonUtility.ToJson(scoreboardEntriesTable);
        PlayerPrefs.SetString("ScoreboardEntriesTableTest", jsonScoreboardEntries);
        PlayerPrefs.Save();
    }

    public void TranslateCommand(ECommand command, PressedState state)
    {
        switch (command)
        {
            case ECommand.OPEN_SCOREBOARD:
                if (state.IsPressed == true)
                    scoreboardView.Show(true);
                if (state.IsReleased == true)
                    scoreboardView.Show(false);
                break;
            default:
                scoreboardView.Show(false);
                break;
        }
    }
}
