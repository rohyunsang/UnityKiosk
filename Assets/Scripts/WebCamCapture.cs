using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.WebCam;

public class WebCamCapture : MonoBehaviour
{
    public WebCamOn webCamOn;
    public WebCamTexture webcamTexture;

    int captureCounter = 1;

    public void WebCamCaptureButton() // using button  
    {
        Debug.Log("웹캠캡쳐버튼 로그");
        if(webCamOn != null){
            webcamTexture = webCamOn.camTexture;
        }
        
        Texture2D snap = new Texture2D(webcamTexture.width, webcamTexture.height, TextureFormat.RGB24, false);
        snap.SetPixels(webcamTexture.GetPixels());
        snap.Apply();

        System.IO.File.WriteAllBytes(Application.dataPath + "/../WebcamCapture" + captureCounter + ".jpg", snap.EncodeToJPG());
        Debug.Log("WebcamCapture" + captureCounter + ".jpg 프로젝트 루트 폴더에 저장되었습니다.");
        captureCounter++;
    }
}