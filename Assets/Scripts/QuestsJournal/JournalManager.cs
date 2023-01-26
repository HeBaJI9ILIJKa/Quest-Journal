using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalManager : MonoBehaviour
{ 
    [SerializeField] private JournalUI _activeQuestsJournal;
    [SerializeField] private JournalUI _completeQuestsJournal;
    [SerializeField] private JournalUI _diaryJournal;

    [SerializeField] private JournalTest JournalTest;

    private void OnEnable()
    {
        JournalTest.OnQuestActivate += QuestActivated;
        JournalTest.OnQuestComplete += QuestCompleted;
        JournalTest.OnAddNoteToDiary += AddNoteToDiary;
        JournalTest.OnSaveJournal += SaveJournals;
        JournalTest.OnLoadJournals += LoadJournals;
        //quests.OnQuestActivate.AddListener(QuestActivated);
        //quests.OnQuestComplete.AddListener(QuestCompleted);
        //OnAddNoteToDiary(AddNoteToDiary)
    }

    public void QuestActivated(object sender, INote quest)
    {
        _activeQuestsJournal.AddNote(sender, quest.Id, quest.Title, quest.Description);
    }

    public void QuestCompleted(object sender, INote quest)
    {
        bool removed = _activeQuestsJournal.RemoveNoteByQuestID(sender, quest.Id);

        if(!removed)
        {
            Debug.Log($"Ќе удалось удалить из журнала квест с ID {quest.Id}");
            return;
        }

        _completeQuestsJournal.AddNote(sender, quest.Id, quest.Title, quest.Description);
    }

    public void AddNoteToDiary(object sender, INote note)
    {
        _diaryJournal.AddNote(sender, note.Id, note.Title, note.Description);
    }

    public void SaveJournals()
    {
        JournalData activeQuestsJournalData = new JournalData(_activeQuestsJournal.Journal.Notes);
        JournalData completeQuestsJournalData = new JournalData(_completeQuestsJournal.Journal.Notes);
        JournalData diaryJournalData = new JournalData(_diaryJournal.Journal.Notes);

        PlayerJournalsData playerJournalsData = new PlayerJournalsData(activeQuestsJournalData, completeQuestsJournalData, diaryJournalData);

        GameData gameData = new GameData(playerJournalsData);

        Storage storage = new Storage();
        storage.Save(gameData);
    }

    public void LoadJournals()
    {
        Storage storage = new Storage();

        JournalData activeQuestsJournalData = new JournalData();
        JournalData completeQuestsJournalData = new JournalData();
        JournalData diaryJournalData = new JournalData();

        PlayerJournalsData playerJournalsData = new PlayerJournalsData(activeQuestsJournalData, completeQuestsJournalData, diaryJournalData);

        GameData gameData = new GameData(playerJournalsData);

        gameData = (GameData)storage.Load(gameData);

        foreach(var note in gameData.JournalsData.ActiveQuestsJournalData.Notes)
        {
            _activeQuestsJournal.AddNote(this, note.QuestId, note.Header, note.Content);
        }
        foreach (var note in gameData.JournalsData.CompletedQuestsJournalData.Notes)
        {
            _completeQuestsJournal.AddNote(this, note.QuestId, note.Header, note.Content);
        }
        foreach (var note in gameData.JournalsData.DiaryJournalData.Notes)
        {
            _diaryJournal.AddNote(this, note.QuestId, note.Header, note.Content);
        }
    }

}


