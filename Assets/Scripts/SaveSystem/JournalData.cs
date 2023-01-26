using System.Collections.Generic;

[System.Serializable]
public class JournalData
{
    public List<Note> Notes = new List<Note>();

    public JournalData(List<Note> notes = null)
    {
        Notes = notes;
        if (notes == null)
            Notes = new List<Note>();
    }
}