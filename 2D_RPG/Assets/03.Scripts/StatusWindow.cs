using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusWindow : MonoBehaviour
{
    public Text strText;
    public Text intText;
    public Text aglText;
    public Text conText;
    public Text statPointText;

    public Text atText;
    public Text defText;
    public Text hpText;

    
    public Text levelText;




    public GameObject statusPanel;

    private bool isInvnetoryOpen = false;
    public void OnOffPanel()
    {
        isInvnetoryOpen = !isInvnetoryOpen;
        statusPanel.SetActive(isInvnetoryOpen);
        SetStatusWindow();
    }

    public void StrUp()
    {
        if(Player.Instance.statPoint != 0)
        {
            Player.Instance.statPoint -= 1;
            Player.Instance.playerStr += 1;
            SetStatusWindow();
        }
    }

    public void IntUp()
    {
        if (Player.Instance.statPoint != 0)
        {
            Player.Instance.statPoint -= 1;
            Player.Instance.playerInt += 1;
            SetStatusWindow();
        }
    }
    public void AglUp()
    {
        if (Player.Instance.statPoint != 0)
        {
            Player.Instance.statPoint -= 1;
            Player.Instance.playerAgl += 1;
            SetStatusWindow();
        }
    }

    public void ConUp()
    {
        if (Player.Instance.statPoint != 0)
        {
            Player.Instance.statPoint -= 1;
            Player.Instance.playerCon += 1;
            SetStatusWindow();
        }
    }

    public void SetStatusWindow()
    {

        strText.text = "Str  " + Player.Instance.playerStr;
        intText.text = "Int  " + Player.Instance.playerInt;
        aglText.text = "Agl  " + Player.Instance.playerAgl;
        conText.text = "Con  " + Player.Instance.playerCon;
        statPointText.text = "잔여포인트 " + Player.Instance.statPoint;
        levelText.text = "Lv. " + Player.Instance.Level;


        atText.text = "공격력  " + Player.Instance.at;
        defText.text = "방어력  " + Player.Instance.def;
        hpText.text = "체력  " + Player.Instance.maxHp;
    }
}
