using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    
    [SerializeField] GameObject roads;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(roads, new Vector3(roads.transform.position.x, roads.transform.position.y,roads.transform.position.z+150f), Quaternion.Euler(0,-90,0));
        }
    }
}
