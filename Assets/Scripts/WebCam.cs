using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.WebCam;
//using System.IO; // used only debug

public class WebCam : MonoBehaviour
{
    // webcam variables 
    public RawImage display;

    [SerializeField]
    public WebCamTexture camTexture;
    private int currentIndex = 0;
    public Texture2D snap;

    // timer variables
    public Text timerText;
    int threeSecond = 3;
    public GameObject countingImage;

    // photo capture checking Image varable
    public RawImage photoResult;
    public GameObject PhotoResultPanel;
    public GameObject PhotoUpload;

    // use debug
    // private int captureCounter = 0;

    void Start(){
        //webCam = GameObject.Find("WebCamManager").GetComponent<WebCam>();

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
        camTexture = new WebCamTexture(device.name,1920,1080,30);
        display.texture = camTexture;
        camTexture.Play();
    }
    public void WebCamCapture(){
        snap = new Texture2D(camTexture.width, camTexture.height, TextureFormat.RGBA64, false);
        Debug.Log(camTexture.width);
        Debug.Log(camTexture.height);
        snap.SetPixels(camTexture.GetPixels());
        snap.Apply(); 
        /*
        // used only debug
        byte[] bytes = snap.EncodeToPNG();   
        string savePath = Application.dataPath + "/WebCamCapture/snap" + captureCounter.ToString() +".png"; 
        File.WriteAllBytes(savePath, bytes);
        captureCounter++;
        */
        
    }
    public void WebCamCaptureButton() // using button  
    {
        countingImage.SetActive(true);
        StartCoroutine(CountingThreeSecond());
        Invoke("WebCamCapture",3f);
        
    }

    IEnumerator CountingThreeSecond(){  // 3 second waiting fuc
        for(int i = 0 ; i < 3; i++){
            timerText.text = threeSecond.ToString();
            yield return new WaitForSeconds(1f);
            threeSecond--;
        }
        timerText.fontSize = 20;
        timerText.text = "Capture!";
    }

    public void WebCamStopButton(){   // panel close fuc 
        camTexture.Stop();
        threeSecond = 3;
        countingImage.SetActive(false);
    }
}
