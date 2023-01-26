using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalUI : MonoBehaviour
{ 
    [SerializeField] private NoteUI _noteUIPrefab;
    [SerializeField] private Transform _content;

    public Journal Journal { get; private set; }

    private List<NoteUI> _notesUI;
    
    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _notesUI = new List<NoteUI>();
        Journal = new Journal();
        Journal.OnNoteAddedEvent += OnNoteAdded;
        Journal.OnNoteRemovedEvent += OnNoteRemoved;
    }

    private void OnNoteAdded(object sender, Note note)
    {
        NoteUI noteUI = Instantiate(_noteUIPrefab, _content);

        noteUI.SetNote(note);

        _notesUI.Add(noteUI);
    }

    private void OnNoteRemoved(object sender, Note note)
    {
        foreach (var noteUI in _notesUI)
        {
            if(noteUI.Note == note)
            {
                Destroy(noteUI.gameObject);
                return;
            }
        }
    }

    public void AddNote(object sender, string questID, string header, string content)
    {
        Journal.AddNote(sender, questID, header, content);
    }

    public bool RemoveNoteByQuestID(object sender, string questID)
    {
        return Journal.RemoveNoteByQuestID(sender, questID);
    }
}
