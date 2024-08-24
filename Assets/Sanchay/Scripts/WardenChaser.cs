using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardenChaser : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Animator anim;
    [SerializeField] Transform player;
    [SerializeField] float stopDistance;
    Rigidbody rb;
    //[SerializeField] Rigidbody rb;
    void Start()
    {   
        rb = GetComponent<Rigidbody>();
       anim.SetBool("isRunning", false); 
    }

    // Update is called once per frame
    void Update()
    {   

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        Vector3 moveDirn = (player.position - transform.position).normalized;

        if (distanceToPlayer >= stopDistance )
        {
            anim.SetBool("isRunning", true);
            //transform.position += moveDirn * speed * Time.deltaTime;
            rb.velocity = moveDirn.normalized*speed*100f*Time.deltaTime;
        }

        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
