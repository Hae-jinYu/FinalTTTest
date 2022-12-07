using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayItem : MonoBehaviour
{
	//public enum Type { }//¿­°ÅÇü
	//public int hay=1;//¹ÐÂ¤

	//[SerializeField] float speed = 7f;
	float moveX, moveY;
	Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}


	void Update()
	{
		moveX = Input.GetAxis("Horizontal");
		moveY = Input.GetAxis("Vertical");
		//rb.velocity = new Vector2(moveX * speed, moveY * speed);
	}


}
