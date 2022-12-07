using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;// 보정값

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset; //카메라 위치
    }
}
