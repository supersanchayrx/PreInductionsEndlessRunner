using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject chaser;
    Vector3 position;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        position = transform.position;
    }

    public void Spawn()
    {
        Instantiate(chaser,position, Quaternion.identity);
    }
}