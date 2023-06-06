using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;

public class PhotoUpload : MonoBehaviour
{
    public WebCam webCam;

    void Start(){
        // another GameObject's field access 
        webCam = GameObject.Find("WebCamManager").GetComponent<WebCam>();
    }

    public void PhotoCaptureBtn()
    {
        Debug.Log("PhotoCaptureBtnTest");
        StartCoroutine(PhotoCapture());
    }

    IEnumerator PhotoCapture()
    {
        byte[] imageBytes = webCam.snap.EncodeToJPG();

        // Create a new form
        WWWForm form = new WWWForm();

        // Add the image as a field to the form
        form.AddBinaryData("customer_image", imageBytes, "customer_image.jpg", "image/jpeg");
        form.AddField("product", "http://220.149.231.136:8051/images/detail_2471760_16838798338817_500_1685690633834.jpg");

        // Create a UnityWebRequest object to send the form data
        UnityWebRequest uploadRequest = UnityWebRequest.Post("http://220.149.231.136:8032/fit", form);

        // Send the request and wait for a response
        yield return uploadRequest.SendWebRequest();

        if (uploadRequest.result == UnityWebRequest.Result.Success)
        {
            // Request successful
            Debug.Log("Image upload complete!");

            // Print the response text
            Debug.Log(uploadRequest.downloadHandler.text);
        }
        else
        {
            // Request failed
            Debug.Log("Image upload failed: " + uploadRequest.error);
        }

        
    }
}

