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
            if (instance == null) //instance �� ���������ʴ´ٸ�
            {
                var obj = FindObjectOfType<CanvasManager>(); //Player Ÿ���� �����ϴ��� Ȯ��
                if (obj != null)
                {
                    instance = obj; //null�� �ƴ϶�� instance�� �־���
                }
                else
                {
                    var newCanvas = new GameObject("Canvas").AddComponent<CanvasManager>(); //null�̶�� ���θ������
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
