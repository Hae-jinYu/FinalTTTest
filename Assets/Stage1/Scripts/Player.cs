using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject[] item;
    public bool[] hasItem;
    public int health;
    float hAxis;
    float vAxis;
    public GameManager manager;

    bool fDown;
    bool iDown;
    bool sDown;

    bool isDead;
    bool isFireReady;
    bool isDamage;
    Vector3 moveVec;

    Animator anim;
    MeshRenderer[] meshs;
    Rigidbody rigid;

    GameObject nearObject;
    public Weapon equipWeapon;
    int equipWeaponIndex = -1;
    float fireDelay;

    // Start is called before the first frame update
   
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        meshs = GetComponentsInChildren<MeshRenderer>();
        rigid = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        Turn();
        Interation();
        Swap();
        Attack();
        
    }


    void Move()
    {

        if (isDead)
            moveVec = Vector3.zero;
        
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        rigid.velocity = Vector3.zero;
        transform.position += moveVec * speed * Time.deltaTime;

        anim.SetBool("isRun", moveVec != Vector3.zero);

    }
   
   void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }
    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        iDown = Input.GetButtonDown("Interaction");
        sDown = Input.GetButtonDown("Swap");
        fDown = Input.GetButtonDown("Fire1");
    }
    void Swap()
    {
        if (sDown && !hasItem[0])
        { return; }
        int weaponIndex = -1;
        if (sDown) weaponIndex = 0;

        if(sDown)
        {
            if(equipWeapon!= null)
                equipWeapon.gameObject.SetActive(false);

           equipWeaponIndex = weaponIndex;
           equipWeapon = item[weaponIndex].GetComponent<Weapon>();
        
           equipWeapon.gameObject.SetActive(true);
        }

    }

    void Attack()  
    {
        if (equipWeapon == null)
            return;

        fireDelay += Time.deltaTime;
        isFireReady = equipWeapon.rate < fireDelay;

          if(fDown && isFireReady)
        {
            equipWeapon.Use();
            anim.SetTrigger("doSwing");
            Debug.Log("attack");
            fireDelay = 0;
        }
    }
    void Interation()
    {
        if(iDown && nearObject!=null)
        {
            if (nearObject.tag == "Item")
            {
                Item item = nearObject.GetComponent<Item>();
                int itemIndex = item.value;
                hasItem[itemIndex] = true;

                Destroy(nearObject);
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "EnemyBullet")
        {
            if (!isDamage)
            {
                Bullet enemyBullet = other.GetComponent<Bullet>();
                health -= enemyBullet.damage;
                StartCoroutine(OnDamage());
            }
        }
    }
    IEnumerator OnDamage()
    {
        isDamage = true;
        foreach(MeshRenderer mesh in meshs)
        {
            mesh.material.color = Color.red;
        }
        yield return new WaitForSeconds(0.5f);

        isDamage = false;
        foreach (MeshRenderer mesh in meshs)
        {
            mesh.material.color = Color.white;
        }

        if (health <= 0)
            OnDie();
    }

    void OnDie()
    {
        anim.SetTrigger("doDie");
        isDead = true;
        manager.GameOver();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Item")
            nearObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Item")
            nearObject = null;
    }
}
