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

    private void Awake()
    {
        //������ ���ÿ� ����Ǵ� Awake�� �̹� �����Ǿ��ִ� �̱��� ������Ʈ�� �ִ��� �˻��ϰ� �ִٸ� ���� ������ ������Ʈ�� �ı�

        //var objs = FindObjectsOfType<Explanation>();
        //if (objs.Length != 1)
        //{
        //    Destroy(gameObject);
        //    return;
        //}

        //DontDestroyOnLoad(gameObject); //���� ��ȯ�Ҷ� �ı��Ǵ°��� ����
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
