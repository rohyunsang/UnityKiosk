using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingBasketManager : MonoBehaviour
{
    
    public GameObject clothCopy; //UI prefab
    public Transform contentTransform;  // Parent Ojbect current => Content

    public Image clothImage;
    // Start is called before the first frame update
    void Start()
    {
        // content serach 
        GameObject shoppingBasketPanel = GameObject.Find("ShoppingBasketPanel");
        Debug.Log(shoppingBasketPanel.name);

        // 계층 구조 내에서 Content 오브젝트를 찾고 해당 Transform을 contentTransform에 할당합니다.
        Transform content = shoppingBasketPanel.transform.Find("Scroll View/Viewport/Content");
        if (content != null)
        {
            contentTransform = content.transform;
        }
    }

    

    public void AddToShoppingBasketButton(){
        string objectName = clothImage.name;
        InstantiateToShoppingBasket(objectName);
        //string parentObjcetName = clothImage.transform.parent.name;
        //Debug.Log(parentObjcetName+ "," + objectName);
    }
    void InstantiateToShoppingBasket(string objectName){
        clothCopy = GameObject.Find(objectName);
        GameObject uiObject = Instantiate(clothCopy, contentTransform);
    }

    // void CopyCloth(){
    //     //public GameObject = 
    // }


}
