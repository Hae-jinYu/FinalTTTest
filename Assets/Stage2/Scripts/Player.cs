using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject[] hay;//배열
    

    public bool isShield=false;

    public int maxHealth=3;//플레이어 체력
    public GameObject Shield;
    float hAxis;
    float vAxis;
    bool wDown;//걷기 애니메이션
    bool jDown;//점프 애니메이션
    bool isJump;
    bool iDown;//아이템 상호작용'

    public int health = 3;
    
    Vector3 moveVec;

    Rigidbody rigid;
    Animator anim;


    GameObject nearObject;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();

        health = maxHealth;
        Shield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        GetInput();
        Move();
        Turn();
        Jump();

        if(health ==0)
		{
            //if (!isDie)
                Die();

            return;
		}

    }

    void GetInput()
	{
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        //wDown = Input.GetButton("Run");
        jDown = Input.GetButtonDown("Jump");
        iDown = Input.GetButtonDown("Interaction");//아이템상호작용
    }
    void Move()
	{
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * Time.deltaTime;

        anim.SetBool("isRun", moveVec != Vector3.zero);
    }
    void Turn()
	{
        transform.LookAt(transform.position + moveVec);//플레이어 회전
	}

    void Jump()
	{
		if (jDown && !isJump)
		{
            rigid.AddForce(Vector3.up * 10, ForceMode.Impulse);
            isJump = true;
		}
	}
    
    void Die()
	{
        //isDie = true;
        rigid.velocity = Vector3.zero;
	}
    void Interaction()
	{
        if(iDown && nearObject!=null && !isJump)
		{
			if (nearObject.tag == "Hay")
			{
                HayItem item = nearObject.GetComponent<HayItem>();

                Destroy(nearObject);
            }
		}
	}

    void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Floor")
		{
            isJump = false;
        }
	}

    void OnTriggerEnter(Collider other)
	{
        if (other.tag == "Hay")
        {
            {
                HayItem item = other.GetComponent<HayItem>();//아이템 스크립트 가져옴
                //hayShield = true;
                ActivateShield();
                //방어막 생김
            }
            Destroy(other.gameObject);
        }
        /*else (other.tag == "Enemy");
        {
            {
                Enemy enemy = other.GetComponent<Enemy>();//애너미 스크립트 가져옴 //에너미스크립트가 적용 안되어서 생기는 오류?
                if(!isShield)
				{
                    health -= 1;
				}
            }
            Debug.Log(health);
        }*/
	}

    void ActivateShield()
	{
        Shield.SetActive(true);
        isShield = true;
        Invoke("NoShield", 5f);//5초후에 방어막 끄기
    }

    void NoShield()
	{
        Shield.SetActive(false);
        isShield = false;
    }
    /*void OnTriggerStay(Collider other)//아이템에 가까이 다가감
	{
        if (other.tag == "Hay") 
            nearObject = other.gameObject;

        Debug.Log(nearObject.name);
	}
    void OnTriggerExit(Collider other)//아이템에서 멀어짐
	{
        if (other.tag == "Hay")
            nearObject = null ;
    }*/




}
