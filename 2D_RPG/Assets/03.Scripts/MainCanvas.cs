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
            //Instantiate 게임오브젝트를 복제해주는 함수 (복제할 값, 위치, 회전값) 으로 이루어진다.
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
                //WorldToScreenPoint 함수는 World의 좌표를 Canvas의 좌표로 변환시켜주는 함수이다.

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
