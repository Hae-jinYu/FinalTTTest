using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth;
    public int curHealth;
    public BoxCollider meleeArea;
    public bool isAttack;
    public GameManager manager;

    Rigidbody rigid;
    BoxCollider boxCollider;
    Material mat;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        mat = GetComponentInChildren<MeshRenderer>().material;

    }

    IEnumerator Attack()
    {
        isAttack = true;
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Melee")
        {
            Weapon weapon = other.GetComponent<Weapon>();
            curHealth -= weapon.damage;
            StartCoroutine(OnDamage());
            Debug.Log("Melee : " + curHealth);
        }
    }

    IEnumerator OnDamage()
    {
        
        yield return new WaitForSeconds(0.1f);

        if(curHealth>0)
        {
            mat.color = Color.red;
        }
        else
        {
            mat.color = Color.gray;
            Destroy(gameObject, 0.2f);
            manager.enemywlof--;
        }

    }
}
