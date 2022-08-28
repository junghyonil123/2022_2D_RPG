using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    public GameObject hpBar;

    [SerializeField]
    GameObject[] monsterArray;

    [SerializeField]
    List<GameObject> hpBarList = new List<GameObject>();

    void Start()
    {
        SetMonsterArray();
    }

    public void SetMonsterArray()
    {
        monsterArray = GameObject.FindGameObjectsWithTag("Monster");

        foreach (var monster in monsterArray)
        {
            hpBarList.Add(Instantiate(hpBar, monster.transform.position, Quaternion.identity, transform));
            //Instantiate ���ӿ�����Ʈ�� �������ִ� �Լ� (������ ��, ��ġ, ȸ����) ���� �̷������.
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < monsterArray.Length; i++)
        {
            if(monsterArray[i] != null)
            {
                hpBarList[i].transform.position = Camera.main.WorldToScreenPoint(monsterArray[i].transform.position + new Vector3(0f, 0.65f, 0f));
                //WorldToScreenPoint �Լ��� World�� ��ǥ�� Canvas�� ��ǥ�� ��ȯ�����ִ� �Լ��̴�.

                float hpPer = monsterArray[i].GetComponent<Monster>().currentHp / monsterArray[i].GetComponent<Monster>().maxHp;
                hpBarList[i].transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(50 * hpPer, 0);

                if (monsterArray[i].GetComponent<Monster>().currentHp <= 0)
                {
                    Destroy(monsterArray[i]);
                    Destroy(hpBarList[i]);
                    monsterArray[i] = null;
                    hpBarList[i] = null;
                }
            }
        }
    }
}
