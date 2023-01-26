using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] _panels;
  
    public void SwitchActivePanel(string name)
    {
        foreach (var panel in _panels)
        {
            if(panel.name == name)
                panel.SetActive(true);
            else
                panel.SetActive(false);
        }
    }

    public void TurnOnPanels()
    {
        foreach (var panel in _panels)
        {
                panel.SetActive(true);
        }
    }
}
