using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warden : MonoBehaviour
{
    public float speed;
    [SerializeField] Animator anim;
    [SerializeField] float stopDistance;
    Rigidbody rb;
    Transform player;

    
    //[SerializeField] Rigidbody rb;
    void Start()
    {   
        rb = GetComponent<Rigidbody>();
       anim.SetBool("isRunning", false); 
       player = GameObject.Find("player").GetComponent<Transform>();
        

    }

    // Update is called once per frame
    void Update()
    {   

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        Vector3 moveDirn = (player.position - transform.position).normalized;

        if (distanceToPlayer >= stopDistance )
        {
            anim.SetBool("isRunning", true);
            transform.position =  new Vector3(player.position.x, transform.position.y, transform.position.z);
            //Debug.Log(player.position);
            
            //rb.velocity = moveDirn.normalized*speedx*100f*Time.deltaTime;
            //rb.velocity = new Vector3(moveDirn.x*speedx*100f*Time.deltaTime, moveDirn.y*speedy*100f*Time.deltaTime);
        }

        else
        {
            anim.SetBool("isRunning", false);
           
        }

    }


    private void FixedUpdate()
    {

        if(anim.GetBool("isRunning"))
        {
            wardenRun();
        }
    }

    void wardenRun()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed * 100f * Time.deltaTime);
    }
}