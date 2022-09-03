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

    public Text statPoint;

    public GameObject statusPanel;

    public void OnOffPanel()
    {
        Debug.Log("µå·¯¿Í½á¿è");
        statusPanel.SetActive(true);
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
        statPoint.text = "ÀÜ¿©Æ÷ÀÎÆ® " + Player.Instance.statPoint;
    }
}
