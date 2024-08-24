using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class stud_movement : MonoBehaviour
{

    [SerializeField] float speed;
    Rigidbody rb;
    
    bool Begin;

    float lane;
    void Start()
    {   
        rb = GetComponent<Rigidbody>();
       
        
        Begin = true;
        lane = 0; // mid = 0, left = -1 , right = 1;
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Begin)
        {
            rb.velocity = Vector3.forward.normalized * speed * 100f * Time.deltaTime;


            if ((lane == 0 || lane == -1) && Input.GetKeyDown(KeyCode.D))
            {
                transform.position += transform.right * 5f;
                lane += 1;
                Debug.Log("Lane:"+lane);
            }


            else if ((lane == 0 || lane == 1) && Input.GetKeyDown(KeyCode.A))
            {
                transform.position += -transform.right * 5f;
                lane -= 1;
                Debug.Log("Lane:"+lane);
            }
        }
        
    }
}
