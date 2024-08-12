using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovem : MonoBehaviour
{

    [SerializeField] float speed;
    Rigidbody rb;
    Animator anim;
    //[SerializeField] Animator anim;
    void Start()
    {   
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", false);
    }

    // Update is called once per frame
    void Update()
    {
        /*float z = Input.GetAxis("Horizontal");
        float x = Input.GetAxis("Vertical");
        Vector3 moveInput = new Vector3 (x, 0, -z);*/

        /* if(moveInput.x > 0.1f ) 
         {
             transform.position += transform.forward * speed * Time.deltaTime;
         }
        */
        if(Input.GetMouseButtonDown(0)) 
        {
            anim.SetBool("isRunning", true);

        }

        if(anim.GetBool("isRunning"))
        {
            rb.velocity = Vector3.forward.normalized * speed * 100f * Time.deltaTime;


            if (transform.position.x < 5f && Input.GetKeyDown(KeyCode.D))
            {
                transform.position += transform.right * 5f;
            }


            else if (transform.position.x > -5f && Input.GetKeyDown(KeyCode.A))
            {
                transform.position += -transform.right * 5f;
            }
        }
        
    }
}
