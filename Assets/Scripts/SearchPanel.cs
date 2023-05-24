using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPanel : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject searchPanel;
    
    public void OnSearchPanel(){
        searchPanel.SetActive(true);
    }

    public void OffSearchPanel(){
        searchPanel.SetActive(false);
    }

}
