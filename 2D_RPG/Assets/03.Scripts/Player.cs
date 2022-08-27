using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator playerAnimator;
    Rigidbody2D playerRigidbody;
    public GameObject attackCollider;
    AudioSource playerAudioSource;
    public GameObject walkSound;

    public float speed;
    public float JumpPower;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckDirection();
        Jump();
        Attack();
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

        }

        if(playerRigidbody.velocity.y > 0)
        {
            //���� �ִϸ��̼� ����

            playerAnimator.SetTrigger("IsJump");
        }

        if(playerRigidbody.velocity.y < 0)
        {
            //ĳ���Ͱ� �������� ������ fall�ִϸ��̼��� ����

            playerAnimator.SetBool("IsFallDown", true);
        }
     

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
            Debug.Log("z ���Ǿ��");
            playerAnimator.SetTrigger("IsAttack");
            
        }
        else
        {
            curTime -= Time.deltaTime;
        }
        
    }

 
    public void OnAttackCollder() 
    {
        attackCollider.SetActive(true);
    }

    public void OffAttackCollder()
    {
        attackCollider.SetActive(false);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isCanJump = true;
            playerAnimator.SetBool("IsGround", true);
        
        }
    }

}
