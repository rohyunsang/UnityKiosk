using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

// 첫번째 방법 : 프리팹 만들어서 해결하기 => button이 연결 끊김
// 두번째 방법 : 이미 만들어진 거기다가 이미지 붙이기 이미지 추가가 어려움.. 

public class UIPrefabManager : MonoBehaviour
{
    public GameObject uiPrefab; //UI prefab
    public Transform contentTransform;  // Parent Ojbect current => Content
    Image leftImage;
    Image rightImage;
    //public Cloth cloth;
    public GameObject clothesManagerObject;
    public ClothesManager clothesManager;
    void Start()
    {
        clothesManagerObject = GameObject.Find("ClothesManager");
        clothesManager = clothesManagerObject.GetComponent<ClothesManager>();
    }

    public void PrefabInstantiate()
    {
        
        float offSet = 0.0f;
        for(int i = 0 ; i < 10; i+=2){
            StartCoroutine(DelayedAPIDownload(i,offSet));
            offSet+=0.5f;
        }
    }
    IEnumerator APIDownload(int idx)
    {   
        
        GameObject uiObject = Instantiate(uiPrefab, contentTransform);

        Transform leftImageTransform = uiObject.transform.Find("LeftImage");
        Transform rightImageTransform = uiObject.transform.Find("RightImage");

        if (leftImageTransform != null)
        {
            // Accessing the Image component of the LeftImage object
            leftImage = leftImageTransform.GetComponent<Image>();
            rightImage = rightImageTransform.GetComponent<Image>();

            if (leftImage != null && rightImage != null)
            {
                for(int i = 0 ; i < 2; i++)
                {
                    string clothImageURL = "http://220.149.231.136:8051/" + clothesManager.clothes[idx].imgUrl;
                    Debug.Log("clothes[idx]+" + idx);
                    UnityWebRequest www = UnityWebRequestTexture.GetTexture(clothImageURL);
                    yield return www.SendWebRequest();

                    if (www.result == UnityWebRequest.Result.Success)
                    {
                        //byte[] imageBytes = www.downloadHandler.data; // 다운로드한 이미지 데이터
                        Texture2D texture = DownloadHandlerTexture.GetContent(www);

                        // Create a sprite from the downloaded texture
                        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
                        if (idx % 2 == 0)
                            leftImage.sprite = sprite;
                        else
                            rightImage.sprite = sprite;

                    }
                    else
                    {
                        Debug.Log("Image download failed: " + www.error);
                    }
                    idx++;
                }
            }
        }
        
    }

    IEnumerator DelayedAPIDownload(int idx, float offSet)
    {
        yield return new WaitForSeconds(offSet);
        StartCoroutine(APIDownload(idx));
    }
}