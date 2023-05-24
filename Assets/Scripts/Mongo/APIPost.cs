using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class APIPost : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(UnityWebRequestPOSTTEST());
    }

    IEnumerator UnityWebRequestPOSTTEST()
    {
        string url = "POST 통신을 사용할 서버 주소를 입력";
        WWWForm form = new WWWForm();
        string id = "아이디";
        string pw = "비밀번호";
        byte[] image ={};
        form.AddField("Username", id);
        form.AddField("Password", pw);
        form.AddBinaryData("SampleImage",image);
        UnityWebRequest www = UnityWebRequest.Post(url, form);  // 보낼 주소와 데이터 입력

        yield return www.SendWebRequest();  // 응답 대기

        if (www.error == null)
        {
            Debug.Log(www.downloadHandler.text);    // 데이터 출력
        }
        else
        {
            Debug.Log("error");
        }
    }
}
