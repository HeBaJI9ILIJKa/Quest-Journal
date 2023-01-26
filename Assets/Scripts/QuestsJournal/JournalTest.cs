using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JournalTest : MonoBehaviour
{
    [SerializeField] private TMP_InputField _headerInput;
    [SerializeField] private TMP_InputField _contentInput;
    [SerializeField] private TMP_InputField _idInput;
    [SerializeField] private NotebookPanel _notebookPanel;

    public event Action<object, INote> OnQuestActivate;
    public event Action<object, INote> OnQuestComplete;
    public event Action<object, INote> OnAddNoteToDiary;
    public event Action OnSaveJournal;
    public event Action OnLoadJournals;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            ActivateQuest();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            CompleteQuest();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            AddNoteToDiary();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _notebookPanel.TurnOnPanels();
            OnSaveJournal?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            _notebookPanel.TurnOnPanels();
            OnLoadJournals?.Invoke();
        }



    }

    public void ActivateQuest()
    {
        string header = _headerInput.text;
        string id = _idInput.text;
        string content = _contentInput.text;

        if(header == "" || id == "" || content == "")
        {
            Debug.Log("Заполните поля ID, header и content");
            return;
        }

        TestQuest quest = new TestQuest(id, header, content);

        OnQuestActivate?.Invoke(this, quest);
    }
    public void CompleteQuest()
    {
        string header = _headerInput.text;
        string id = _idInput.text;
        string content = _contentInput.text;

        if (header == "" || id == "" || content == "")
        {
            Debug.Log("Заполните поля ID, header и content");
            return;
        }

        TestQuest quest = new TestQuest(id, header, content);

        OnQuestComplete?.Invoke(this, quest);
    }
    public void AddNoteToDiary()
    {
        string header = _headerInput.text;
        string id = _idInput.text;
        string content = _contentInput.text;

        if (header == "" || id == "" || content == "")
        {
            Debug.Log("Заполните поля ID, header и content");
            return;
        }

        TestQuest quest = new TestQuest(id, header, content);

        OnAddNoteToDiary?.Invoke(this, quest);
    }

}

public class TestQuest : INote
{
    public string Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public TestQuest(string id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }


}