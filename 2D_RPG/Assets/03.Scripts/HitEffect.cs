using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public void OnHitEffect()
    {
        gameObject.SetActive(true);
    }

    public void OffHitEffect()
    {
        gameObject.SetActive(false);
    }
}
