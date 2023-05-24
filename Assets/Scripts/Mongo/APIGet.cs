using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class APIGet : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(UnityWebRequestGETTest());
    }

    IEnumerator UnityWebRequestGETTest()
    {
        // GET 방식
        string apikey = "발급받은 API키를 넣는다.";
        string url = "https://api.neople.co.kr/df/servers?apikey=" + apikey;

		// UnityWebRequest에 내장되있는 GET 메소드를 사용한다.
        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.SendWebRequest();  // 응답이 올때까지 대기한다.

        if (www.error == null)  // 에러가 나지 않으면 동작.
        {
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            Debug.Log("error");
        }
    }
}
