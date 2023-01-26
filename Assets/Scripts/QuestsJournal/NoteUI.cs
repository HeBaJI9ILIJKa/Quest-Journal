using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoteUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _header;
    [SerializeField] private TextMeshProUGUI _content;
    [SerializeField] private Note _note;

    public Note Note => _note;

    public void SetNote(Note note)
    {
        _note = note;
        UpdateNote();
    }

    public void UpdateNote()
    {
        if (_note == null)
            return;

        _header.text = _note.Header;
        _content.text = _note.Content;
    }
}
