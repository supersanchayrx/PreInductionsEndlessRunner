using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : MonoBehaviour
{
    [SerializeField] float run_speed;
    [SerializeField] float switch_time;
    [SerializeField] Transform right_lane, left_lane, center_lane;
    [SerializeField] KeyCode moveL, moveR;

    bool lock_controls;

    Rigidbody rb;
    Animator anim;
    int cur_lane;

    float switch_speed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", false);

        /* 
        1 -> Right
        0 -> Center
        -1 -> Left
        */ 
        cur_lane = 0;
        lock_controls = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.anyKeyDown) 
        {
            anim.SetBool("isRunning", true);

        }

        if(anim.GetBool("isRunning"))
        {
            rb.velocity = new Vector3(switch_speed * 100f * Time.deltaTime , 0 , run_speed * 100f * Time.deltaTime);

            
            if(Input.GetKeyDown(moveL) && cur_lane > -1 && !lock_controls)
            {
                lock_controls = true;
                switch_speed = (-1) * 2.5f/(0.8f);
                cur_lane -=1;
                //StartCoroutine("stopSwitch");
                
            }

            if(Input.GetKeyDown(moveR) && cur_lane < 1 && !lock_controls)
            {
                lock_controls = true;
                switch_speed = 2.5f/(0.8f);
                cur_lane +=1;
                //StartCoroutine("stopSwitch");
                
            }

        }


    }

}
