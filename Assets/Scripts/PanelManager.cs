using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//

public class PanelManager : MonoBehaviour
{
    public GameObject LoginPanel;
    public GameObject VirtualFittingPanel;
    public GameObject VirtualFittingResultPanel;
    public GameObject MaxmizeImagePanel;
    //public GameObject IntroAdvertisingPanel;
    public GameObject SettingPanel;
    public GameObject ShoppingBasketPanel;
    public GameObject PhotoResultPanel;

    public void OnVirtualFittingPanel()
    {
        VirtualFittingPanel = GameObject.Find("VirtualFittingPanel");
        VirtualFittingPanel.SetActive(true);
    }
    public void OnMaxmizeImagePanel()
    {
        MaxmizeImagePanel.SetActive(true);
    }

    public void OnSettingPanel()
    {
        SettingPanel.SetActive(true);
    }
    public void OnpShoppingBasketPanel()
    {
        ShoppingBasketPanel.SetActive(true);
    }
    public void OnLoginPanel()
    {
        LoginPanel.SetActive(true);
    }
    public void OnPhotoResultPanel()
    {
        PhotoResultPanel.SetActive(true);
    }
    public void OffPhotoResultPanel()
    {
        PhotoResultPanel.SetActive(true);
    }

    public void OffLoginPanel()
    {
        LoginPanel.SetActive(false);
    }
    public void OffVIrtualFittingPanel()
    {
        VirtualFittingPanel.SetActive(false);
    }
    public void OffMaxmizImagePanel()
    {
        MaxmizeImagePanel.SetActive(false);
    }
    /*
    public void OffIntroAdvertisingPanel(){
        IntroAdvertisingPanel.SetActive(false);
    }
    */
    public void OffVIrtualFittingResultPanel()
    {
        VirtualFittingResultPanel.SetActive(false);
    }

    public void OffSettingPanel()
    {
        SettingPanel.SetActive(false);
    }
    public void OffShoppingBasketPanel()
    {
        ShoppingBasketPanel.SetActive(false);
    }
}
