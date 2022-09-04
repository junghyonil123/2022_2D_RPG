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

    public float at;
    public float def;

    public int dropExp;
    public int dropGold;
    public List<Item> dropItem = new List<Item>();
    public List<int> dropPercentage = new List<int>();

    private void Start()
    {
        monsterRigidbody = GetComponent<Rigidbody2D>();
        currentHp = maxHp;
    }

    public void Die()
    {
        if(currentHp <= 0)
        {
            Player.Instance.GetGold(dropGold);
            Player.Instance.GetExp(dropExp);



            Destroy(gameObject);
        }
    }

    private void Update()
    {
        FindPlayer();
        Die();
    }

    public void hit()
    {
        hitEffect.SetActive(true);
        attackEffectAnimator.SetTrigger("IsAttacked");
        StartCoroutine(knockback());

        if(Player.Instance.at - def < 1)
        {
            currentHp -= 1; //�������� 1���� ���ٸ� 1����´�
        }
        else
        {
            currentHp -= (Player.Instance.at - def); //ü���� ��´�
        }
        
    }

    IEnumerator knockback()
    {
        for (int i = 0; i < 30; i++)
        {
            if(Player.Instance.transform.position.x < transform.position.x)
            {
                //�÷��̾ ���ʿ����� ���ʹ� ���������� �и�
                monsterRigidbody.AddForce(new Vector2(5f, 0f));
            }
            else
            {
                //�÷��̾ �����ʿ����� ���ʹ� �������� �и�
                monsterRigidbody.AddForce(new Vector2(-5f, 0f));
            }
            
            yield return null;
        }
    }

    public void FindPlayer()
    {
        transform.position = Vector2.Lerp(transform.position, Player.Instance.transform.position, 0.001f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //�÷��̾ ������
            if (at - Player.Instance.def < 1)
            {
                Player.Instance.currentHp -= 1;
            }
            else
            {
                Player.Instance.currentHp -= (at - Player.Instance.def);
            }

        }
    }
}
