using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal
{
    public event Action<object, Note> OnNoteAddedEvent;
    public event Action<object, Note> OnNoteRemovedEvent;

    private List<Note> _notes;

    public List<Note> Notes => _notes;

    public Journal()
    {
        _notes = new List<Note>();
    }

    public void AddNote(object sender, string questID, string header, string content)
    {
        Note note = new Note(questID, header, content);

        _notes.Add(note);
        OnNoteAddedEvent?.Invoke(sender, note);
    }

    public bool RemoveNoteByQuestID(object sender, string questID)
    {
        foreach (var note in _notes)
        {
            if(note.QuestId == questID)
            {
                RemoveNote(sender, note);
                return true;
            }
        }
        return false;
    }

    private void RemoveNote(object sender, Note note)
    {
        _notes.Remove(note);
        OnNoteRemovedEvent?.Invoke(sender, note);
    }
}
