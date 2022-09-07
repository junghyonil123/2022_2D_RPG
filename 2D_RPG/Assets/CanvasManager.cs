using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{

    #region Singleton
    private static CanvasManager instance;
    public static CanvasManager Instance
    {
        get
        {
            if (instance == null) //instance 가 존재하지않는다면
            {
                var obj = FindObjectOfType<CanvasManager>(); //Player 타입이 존재하는지 확인
                if (obj != null)
                {
                    instance = obj; //null이 아니라면 instance에 넣어줌
                }
                else
                {
                    var newCanvas = new GameObject("Canvas").AddComponent<CanvasManager>(); //null이라면 새로만들어줌
                    instance = newCanvas;
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


    public GameObject ExplanationWindow;

    public void OnExplanationWindow()
    {
        ExplanationWindow.SetActive(true);
    }
    public void OffExplanationWindow()
    {
        ExplanationWindow.SetActive(false);
    }
}
