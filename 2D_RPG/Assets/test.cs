using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
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

    #endregion
    private void Awake()
    {
        gameObject.SetActive(false);   
    }
}
