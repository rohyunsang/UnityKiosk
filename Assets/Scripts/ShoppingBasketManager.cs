using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingBasketManager : MonoBehaviour
{
    public GameObject clothCopy; //UI prefab
    public Transform contentTransform;  // Parent Ojbect current => Content
    public Image clothImage;
    public GameObject basketCounterTextObject;

    // Start is called before the first frame update
    void Start()
    {
        basketCounterTextObject = GameObject.Find("BasketCounterText");
        GameObject shoppingBasketPanel = GameObject.Find("ShoppingBasketPanel");

        // Hierachy에서 Content 오브젝트를 찾고 해당 Transform을 contentTransform에 할당
        Transform content = shoppingBasketPanel.transform.Find("Scroll View/Viewport/Content");
        if (content != null)
        {
            contentTransform = content.transform;
        }
    }
    public void AddToShoppingBasketButton()
    {
        string objectName = clothImage.name;
        InstantiateToShoppingBasket(objectName);
        basketCounterTextObject.GetComponent<BasketCounter>().basketCount++; // basketCounter
        basketCounterTextObject.GetComponent<Text>().text = basketCounterTextObject.GetComponent<BasketCounter>().basketCount.ToString();

        // check button
    }
    void InstantiateToShoppingBasket(string objectName)
    {
        clothCopy = GameObject.Find(objectName); // image 이름으로 gameObject 찾아서 복사.
        GameObject uiObject = Instantiate(clothCopy, contentTransform);
        uiObject.transform.Find("TryOnBtn").gameObject.SetActive(false);  // Try On btn, 담기 btn 비활성화
        uiObject.transform.Find("AddCartBtn").gameObject.SetActive(false);

        // 새로운 닫기 버튼 생성

        GameObject closeButton = new GameObject("CloseButton");
        closeButton.transform.SetParent(uiObject.transform); // 새 버튼의 부모를 contentTransform으로 설정
        RectTransform closeButtonRectTransform = closeButton.AddComponent<RectTransform>();
        closeButtonRectTransform.anchorMin = new Vector2(1f, 1f); // 우측 상단에 위치
        closeButtonRectTransform.anchorMax = new Vector2(1f, 1f);
        closeButtonRectTransform.pivot = new Vector2(1f, 1f);
        closeButtonRectTransform.anchoredPosition = Vector2.zero; // 이미지 우측 상단에 위치하도록 설정
        closeButtonRectTransform.sizeDelta = new Vector2(30f, 30f); // 적절한 크기로 설정

        // 새로운 닫기 버튼에 이미지 컴포넌트 추가
        Image closeButtonImage = closeButton.AddComponent<Image>();
        closeButtonImage.color = Color.white;

        GameObject textObject = new GameObject("Text");
        textObject.transform.SetParent(closeButton.transform); // 텍스트의 부모를 closeButton으로 설정
        RectTransform textRectTransform = textObject.AddComponent<RectTransform>();
        textRectTransform.anchorMin = new Vector2(0.5f, 0.5f); // 중앙에 위치
        textRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
        textRectTransform.pivot = new Vector2(0.5f, 0.5f);
        textRectTransform.anchoredPosition = Vector2.zero; // 중앙에 위치하도록 설정

        // 텍스트 컴포넌트 추가 및 설정
        Text textComponent = textObject.AddComponent<Text>();
        textComponent.text = "X"; // 텍스트 내용 설정
        textComponent.font = Font.CreateDynamicFontFromOSFont("Arial", 14); // 원하는 폰트 및 크기 설정
        textComponent.alignment = TextAnchor.MiddleCenter; // 중앙 정렬
        textComponent.color = Color.black; // 텍스트 컬러 설정

        // 닫기 버튼을 클릭했을 때 부모 오브젝트를 삭제하는 기능 추가
        Button closeButtonButton = closeButton.AddComponent<Button>();
        closeButtonButton.onClick.AddListener(() =>
        {
            Destroy(closeButton.transform.parent.gameObject);
            basketCounterTextObject.GetComponent<BasketCounter>().basketCount--;
            basketCounterTextObject.GetComponent<Text>().text = basketCounterTextObject.GetComponent<BasketCounter>().basketCount.ToString();
        });

        uiObject.transform.SetAsFirstSibling(); // 이미지 위로 닫기 버튼이 표시되도록 설정
        uiObject.transform.localPosition = Vector3.zero;
    }
    void ButtonInstant(){

    }
    void ButtonFuctionImplement(){
        
    }


}
