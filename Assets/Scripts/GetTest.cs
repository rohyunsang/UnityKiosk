using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetTest : MonoBehaviour
{
    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://220.149.231.136:8051/api/hello");
        
        // Send the request and wait for a response
        yield return www.SendWebRequest();
        
        // Check for errors
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Request successful
            Debug.Log("Get request complete!");
            
            // Print the response text
            Debug.Log(www.downloadHandler.text);
            Debug.Log(www.downloadHandler.GetType());
            byte[] imageSample = www.downloadHandler.data;
        }
    }
    // Download image Sample Codes
    /*
     public RawImage imageContainer;
    public string imageURL = "http://example.com/image.jpg";

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageURL);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

            // Assign the downloaded texture to the RawImage component
            imageContainer.texture = texture;
        }
        else
        {
            Debug.Log("Image download failed: " + www.error);
        }
    }
    */
   
}
