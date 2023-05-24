using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public GameObject LoginPanel;
    public GameObject VirtualFittingPanel;
    public GameObject MaxmizeImagePanel;
    public GameObject IntroAdvertisingPanel;
    public void OffLoginPanel()
    {
        LoginPanel.SetActive(false);
    }
    public void OnVirtualFittingPanel(){
        VirtualFittingPanel.SetActive(true);
    }
    public void OffVIrtualFittingPanel(){
        VirtualFittingPanel.SetActive(false);
    }

    public void OnMaxmizeImagePanel(){
        MaxmizeImagePanel.SetActive(true);

    }
    public void OffMaxmizImagePanel(){
        MaxmizeImagePanel.SetActive(false);
    }
    public void OffIntroAdvertisingPanel(){
        IntroAdvertisingPanel.SetActive(false);
    }
}
