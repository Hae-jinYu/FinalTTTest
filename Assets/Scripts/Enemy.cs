using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public Transform target;//플레이어
    Rigidbody rigid;
    BoxCollider boxCollider;
    Material mat;
    NavMeshAgent nav;
    Animator anim;
    public bool isChase;
    public bool isAttack;

    public int damage=1;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
		boxCollider = GetComponent<BoxCollider>();
		mat = GetComponentInChildren<MeshRenderer>().material;
        nav = GetComponent<NavMeshAgent>();
        anim=GetComponentInChildren<Animator>();

        Invoke("ChaseStart", 2);//2초 뒤에 추적 시작
    }

    void OnTriggerEnter(Collider other) //플레이어 만나면
	{
        if(other.tag=="Player")
		{
            Player player = other.GetComponent<Player>();//플레이어 스크립트 가져옴
            player.health -= damage;

            Debug.Log(player.health);
        }
	}
    // Update is called once per frame

    void ChaseStart()
	{
        isChase = true;
        anim.SetBool("isMove", true);
	}
    void AttackStart()
	{
        isAttack = true;
        anim.SetBool("isAttack", true);

    }
    void Update()
    {
        if (isChase)
        {
            nav.SetDestination(target.position);
        }
    }
}
