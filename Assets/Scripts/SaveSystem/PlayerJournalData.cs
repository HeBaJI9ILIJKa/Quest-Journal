
[System.Serializable]
public class PlayerJournalsData
{
    public JournalData ActiveQuestsJournalData;
    public JournalData CompletedQuestsJournalData;
    public JournalData DiaryJournalData;

    public PlayerJournalsData(JournalData activeQuestsJournalData, JournalData completedQuestsJournalData, JournalData diaryJournalData)
    {
        ActiveQuestsJournalData = activeQuestsJournalData;
        CompletedQuestsJournalData = completedQuestsJournalData;
        DiaryJournalData = diaryJournalData;
    }
}
