using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trip_die : MonoBehaviour
{
    Rigidbody rb;
    public spawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            spawner.Spawn();

        }
       


    }
    

}
