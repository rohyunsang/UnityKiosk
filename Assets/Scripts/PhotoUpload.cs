using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;

public class PhotoUpload : MonoBehaviour
{
    
    public void PhotoCaptureBtn(){
        Debug.Log("PhotoCaptureBtnTest");
        StartCoroutine(PhotoCapture());
    }

     IEnumerator PhotoCapture()
    {
        string imagePath = @"file:///C:/Users/lionh/Desktop/customer_image.jpg";
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imagePath);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(www);
            byte[] imageBytes = texture.EncodeToJPG();

            // Create a new form
            WWWForm form = new WWWForm();

            // Add the image as a field to the form
            form.AddBinaryData("customer_image", imageBytes, "customer_image.jpg", "image/jpeg");
            form.AddField("product","https://docs.google.com/uc?export=download&id=1Xd0rfpg_PE_hClGs7_mbvvPVEraG6sYf");

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
        else
        {
            // Texture loading failed
            Debug.Log("Texture loading failed: " + www.error);
        }
    }
}

