using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExplanationWindow : MonoBehaviour
{
    #region Singleton
    private static ExplanationWindow instance;
    public static ExplanationWindow Instance
    {
        get
        {
            if (instance == null) //instance 가 존재하지않는다면
            {
                var obj = FindObjectOfType<ExplanationWindow>(); //Player 타입이 존재하는지 확인
                if (obj != null)
                {
                    instance = obj; //null이 아니라면 instance에 넣어줌
                }
                else
                {
                    var newPlayer = new GameObject("ExplanationUi").AddComponent<ExplanationWindow>(); //null이라면 새로만들어줌
                    instance = newPlayer;
                }
            }
            return instance;
        }
        private set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        //생성과 동시에 실행되는 Awake는 이미 생성되어있는 싱글톤 오브젝트가 있는지 검사하고 있다면 지금 생성된 오브젝트를 파괴

        //var objs = FindObjectsOfType<Explanation>();
        //if (objs.Length != 1)
        //{
        //    Destroy(gameObject);
        //    return;
        //}

        //DontDestroyOnLoad(gameObject); //씬을 전환할때 파괴되는것을 막음
    }
    #endregion

    public Image itemImage;
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemTypeText;
    public TextMeshProUGUI itemExplanationText;

    public void SetExplanation(Item _item)
    {
        itemImage.gameObject.SetActive(true);
        itemImage.sprite = _item.ItemSprite;
        itemNameText.text = _item.ItmeName;
        itemTypeText.text = "[" + _item.itmeType + "]";
        itemExplanationText.text = _item.itmeExplanation;
    }
}
