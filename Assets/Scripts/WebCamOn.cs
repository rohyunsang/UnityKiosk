using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.WebCam;

public class WebCamOn : MonoBehaviour
{
    PhotoCapture photoCapture = null;
    public RawImage display;
    WebCamTexture camTexture;
    private int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        //webcam checking codes
        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length; i++)
        {
            Debug.Log(devices.Length);
            Debug.Log(devices[i].name);
        }

        //webcam run 
        if (camTexture != null)
        {
            display.texture = null;
            camTexture.Stop();
            camTexture = null;
        }

        WebCamDevice device = WebCamTexture.devices[currentIndex];
        camTexture = new WebCamTexture(device.name,728,1024,60);
        display.texture = camTexture;
        camTexture.Play();

        
    }

    
}
