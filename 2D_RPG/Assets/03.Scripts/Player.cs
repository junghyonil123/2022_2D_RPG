using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator playerAnimator;
    Rigidbody2D playerRigidbody;
    public Transform attackCollider;
    AudioSource playerAudioSource;
    public GameObject walkSound;

    public float speed;
    public float JumpPower;
    public Vector2 hitBoxSize;

    public float maxHp;
    public float currentHp;
    public float maxMp;
    public float currentMp;
    public float at;
    public float def;

    public int playerStr = 5;
    public int playerInt = 5;
    public int playerAgl = 5;
    public int playerCon = 5;

    public int statPoint = 0;

    public int Level = 1;
    public float maxExp;
    public float currentExp;

    bool isDeath = false;

    #region Singleton
    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null) //instance �� ���������ʴ´ٸ�
            {
                var obj = FindObjectOfType<Player>(); //Player Ÿ���� �����ϴ��� Ȯ��
                if (obj != null)
                {
                    instance = obj; //null�� �ƴ϶�� instance�� �־���
                }
                else
                {
                    var newPlayer = new GameObject("Player").AddComponent<Player>(); //null�̶�� ���θ������
                    instance = newPlayer;
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

        var objs = FindObjectsOfType<Player>(); 
        if (objs.Length != 1)
        {
            Destroy(gameObject); 
            return;
        }
        
        DontDestroyOnLoad(gameObject); //���� ��ȯ�Ҷ� �ı��Ǵ°��� ����
    }
    #endregion

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAudioSource = GetComponent<AudioSource>();

        currentExp = 0;
        currentHp = maxHp;
        currentMp = maxMp;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDeath)
        {
            Move();
            CheckDirection();
            Jump();
            Attack();
            Die();
        }
    }

    public void Die()
    {
        if(currentHp <= 0)
        {
            playerAnimator.SetTrigger("IsDead");
            GameObject.Find("WalkSound").GetComponent<AudioSource>().Stop();
            isDeath = true;
        }
    }

    Vector2 jumpVector;
    public bool isCanJump = true;

    void Jump()
    {
        //ĳ���� ����

        if (Input.GetKey(KeyCode.Space) && isCanJump) //��� ������ �����Ѱ��� ����
        {
            Debug.Log("���Ӿ��");

            isCanJump = false;

            playerAnimator.SetBool("IsGround", false);

            jumpVector = Vector2.up * JumpPower;

            //jumpVector *= Time.deltaTime;

            playerRigidbody.AddForce(jumpVector);

            playerAnimator.SetTrigger("IsJump");

        }

        //if(playerRigidbody.velocity.y < 0)
        //{
        //    //ĳ���Ͱ� �������� ������ fall�ִϸ��̼��� ����

        //    playerAnimator.SetBool("IsFallDown", true);
        //}
     

    }


    Vector2 moveVector;

    void Move()
    {
        //ĳ���� ������

        moveVector = new Vector2(Input.GetAxisRaw("Horizontal"), 0).normalized;

        moveVector = moveVector * speed * Time.deltaTime;

        transform.Translate(moveVector);

        playerAnimator.SetBool("IsMove" , moveVector != Vector2.zero);

        if(moveVector == Vector2.zero)
        {
            walkSound.GetComponent<AudioSource>().Stop();
        }
        else if(walkSound.GetComponent<AudioSource>().isPlaying == false)
        {
            walkSound.GetComponent<AudioSource>().Play();
        }
           
    }

    void CheckDirection()
    {
        //ĳ������ ������ üũ�ϰ� ���⿡�°� �����ݴϴ�.

        if (moveVector.x < 0)
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        else if (moveVector.x > 0)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
    }

    public float coolTime = 1f;
    public float curTime;

    void Attack()
    {
        if(curTime < 0 && Input.GetKey(KeyCode.Z))
        {
            curTime = coolTime;
          
            playerAudioSource.Play();
            playerAnimator.SetTrigger("IsAttack");

            Collider2D[] Monsters = Physics2D.OverlapBoxAll(attackCollider.position, hitBoxSize, 0);

            foreach (Collider2D Collider in Monsters)
            {
                if (Collider.gameObject.tag == "Monster")
                {
                    Collider.GetComponent<Monster>().hit();
                }
                
            }

        }
        else
        {
            curTime -= Time.deltaTime;
        }
        
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawWireCube(attackCollider.position, hitBoxSize);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isCanJump = true;
            playerAnimator.SetBool("IsGround", true);
        
        }

        if (collision.gameObject.tag == "Item")
        {
            Inventory.Instance.GetItem(collision.gameObject.GetComponent<Item>());
            Destroy(collision.gameObject);
        }
    }


}
