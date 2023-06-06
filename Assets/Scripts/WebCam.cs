using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.WebCam;

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

    // Start is called before the first frame update

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
        camTexture = new WebCamTexture(device.name,728,1024,60);
        display.texture = camTexture;
        camTexture.Play();
    }
    public void WebCamCapture(){
        snap = new Texture2D(camTexture.width, camTexture.height, TextureFormat.RGBA32, false);
        snap.SetPixels(camTexture.GetPixels());
        snap.Apply(); 
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
    }
}
