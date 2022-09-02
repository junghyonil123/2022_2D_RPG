using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    Rigidbody2D monsterRigidbody;
    public Animator attackEffectAnimator;
    public GameObject hitEffect;
    public float maxHp;
    public float currentHp;

    private void Start()
    {
        monsterRigidbody = GetComponent<Rigidbody2D>();
        currentHp = maxHp;
    }

    public void hit()
    {
        hitEffect.SetActive(true);
        attackEffectAnimator.SetTrigger("IsAttacked");
        StartCoroutine(knockback());

        currentHp -= Player.Instance.at;
    }

    IEnumerator knockback()
    {
        for (int i = 0; i < 30; i++)
        {
            if(Player.Instance.transform.position.x < transform.position.x)
            {
                //플레이어가 왼쪽에있음 몬스터는 오른쪽으로 밀림
                monsterRigidbody.AddForce(new Vector2(5f, 0f));
            }
            else
            {
                //플레이어가 오른쪽에있음 몬스터는 왼쪽으로 밀림
                monsterRigidbody.AddForce(new Vector2(-5f, 0f));
            }
            
            yield return null;
        }
    }

}
