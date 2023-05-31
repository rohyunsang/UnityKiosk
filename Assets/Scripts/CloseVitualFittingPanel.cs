using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseVitualFittingPanel : MonoBehaviour
{
    [SerializeField]
    public GameObject VitualFittingPanel;
    public void OffVitualFittingPanel(){
        VitualFittingPanel.SetActive(false);
    }
}
