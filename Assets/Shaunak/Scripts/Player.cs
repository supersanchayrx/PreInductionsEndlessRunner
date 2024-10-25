using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float run_speed;
    [SerializeField] float switch_speed;
    [SerializeField] Transform right_lane, left_lane, center_lane;

    public KeyCode moveleft;
    public KeyCode moveright;
    Rigidbody rb;
    Animator anim;
    int cur_lane;


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
        moveleft = KeyCode.A;
        moveright = KeyCode.D;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(cur_lane);

        
        if(Input.anyKeyDown) 
        {
            anim.SetBool("isRunning", true);

        }

        
        if(cur_lane == 0)
        {
           
            

            
            Vector3 new_pos = new Vector3(center_lane.position.x,transform.position.y,transform.position.z);
            transform.position = Vector3.Lerp(transform.position, new_pos, switch_speed * Time.deltaTime);

            
               
        }
        if(cur_lane == 1)
        {

            
            Vector3 new_pos = new Vector3(right_lane.position.x,transform.position.y,transform.position.z);
            transform.position = Vector3.Lerp(transform.position, new_pos, switch_speed * Time.deltaTime);

        }
        if(cur_lane == -1)
        {
            
            Vector3 new_pos = new Vector3(left_lane.position.x,transform.position.y,transform.position.z);
            transform.position = Vector3.Lerp(transform.position, new_pos, switch_speed * Time.deltaTime);

        }

        //update the cur_lane variable according to the key pressed
        if(anim.GetBool("isRunning"))
        {
            rb.AddForce(Vector3.forward * run_speed * Time.deltaTime, ForceMode.VelocityChange);

            if (Input.GetKeyDown(moveright))
            {
                if(cur_lane == 0)
                {
                    cur_lane = 1;
                }
                if(cur_lane == -1)
                {
                    cur_lane = 0;
                }
            }
            if(Input.GetKeyDown(moveleft))
            {
                if(cur_lane == 0)
                {
                    cur_lane = -1;
                }
                if(cur_lane == 1)
                {
                    cur_lane = 0;
                }
            }
        }



        
    }
}
