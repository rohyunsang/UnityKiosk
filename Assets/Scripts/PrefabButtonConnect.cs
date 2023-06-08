using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabButtonConnect : MonoBehaviour
{
    public WebCam webCam;
    public PanelManager panelManager;
    public GameObject virtualPanel;
    public GameObject webCamObject;

    // Start is called before the first frame update
    void Start()
    {
        webCam = GameObject.Find("WebCamManager").GetComponent<WebCam>();
        virtualPanel = GameObject.Find("PanelManager").GetComponent<PanelManager>().VirtualFittingPanel;
    }

    public void OnPrefabButton(){
        virtualPanel.SetActive(true);
        webCam.WebCamPlayButton();
    } 
}
