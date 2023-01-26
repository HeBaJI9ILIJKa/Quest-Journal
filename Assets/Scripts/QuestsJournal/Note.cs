[System.Serializable]
public class Note
{
    private string _header;
    private string _content;
    private string _questId;

    public string Header => _header;
    public string Content => _content;

    public string QuestId => _questId;

    public Note(string questID, string header, string content)
    {
        _questId = questID;
        _header = header;
        _content = content;
    }
}

