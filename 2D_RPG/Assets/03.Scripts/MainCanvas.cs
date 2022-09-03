using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvas : MonoBehaviour
{
    public GameObject hpBar;
    GameObject[] monsterArray;
    List<GameObject> hpBarList = new List<GameObject>();

    public GameObject playerHpBar;
    public GameObject playerMpBar;
    public GameObject playerExpBar;
    public GameObject playerLevelText;

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
        //������ ü�¹� ����
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

        //�÷��̾��� ü�¹� ����
        float playerHpPer = Player.Instance.currentHp / Player.Instance.maxHp;
        playerHpBar.transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(700 * playerHpPer, 50);

        //�÷��̾��� ������ ����
        float playerMpPer = Player.Instance.currentMp / Player.Instance.maxMp;
        playerMpBar.transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(700 * playerMpPer, 50);

        //�÷��̾��� ����ġ�� ����
        float playerLevelPer = Player.Instance.currentExp / Player.Instance.maxExp;
        playerExpBar.transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(700 * playerLevelPer, 20);

        //�÷��̾��� ������ ǥ��
        playerLevelText.GetComponent<Text>().text = "Lv. " + Player.Instance.Level;
    }
}
