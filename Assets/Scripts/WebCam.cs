using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.WebCam;

public class WebCam : MonoBehaviour
{
    public RawImage display;

    [SerializeField]
    public WebCamTexture camTexture;
    private int currentIndex = 0;
    private int captureCounter = 0;

    // Start is called before the first frame update

    void Start(){
        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log(devices.Length + " " + devices[i].name);
        }

        //webcam run 
        if (camTexture != null)
        {
            display.texture = null;
            camTexture.Stop();
            camTexture = null;
        }
    }

    public void WebCamPlayButton()
    {
        Debug.Log("WebCamPlayButtonClicked");
        WebCamDevice device = WebCamTexture.devices[currentIndex];
        camTexture = new WebCamTexture(device.name,728,1024,60);
        display.texture = camTexture;
        camTexture.Play();
    }

    public void WebCamCaptureButton() // using button  
    {
        Texture2D snap = new Texture2D(camTexture.width, camTexture.height, TextureFormat.RGB24, false);
        snap.SetPixels(camTexture.GetPixels());
        snap.Apply();

        Debug.Log(Application.dataPath+"/WebCamCapture/");

        System.IO.File.WriteAllBytes(Application.dataPath + "/WebCamCapture/" + "WebCamCapture" + captureCounter + ".jpg", snap.EncodeToJPG());
        Debug.Log("WebCamCapture" + captureCounter + ".jpg 프로젝트 루트 폴더에 저장되었습니다.");
        captureCounter++;
    }

    public void WebCamStopButton(){
        camTexture.Stop();
    }
}
