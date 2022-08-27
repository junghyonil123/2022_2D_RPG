using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    Rigidbody2D monsterRigidbody;
    public Animator attackEffectAnimator;
    public GameObject hitEffect;

    private void Start()
    {
        monsterRigidbody = GetComponent<Rigidbody2D>();
    }

    public void hit()
    {
        hitEffect.SetActive(true);
        attackEffectAnimator.SetTrigger("IsAttacked");
        StartCoroutine(knockback());
    }

    IEnumerator knockback()
    {
        for (int i = 0; i < 30; i++)
        {
            monsterRigidbody.AddForce(new Vector2(5f, 0f));
            yield return null;
        }
    }

}
