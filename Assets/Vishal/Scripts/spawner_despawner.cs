using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner_despawner : MonoBehaviour
{

    [SerializeField] GameObject chaser;

    [SerializeField] Transform spawnpoint;

    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //press key to spawn enemy
        if (Input.GetKeyDown(KeyCode.LeftControl))
            Spawn();
    }


    //despawning logic
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chaser"))
        {
            GameObject chaser = other.gameObject;
            Destroy(chaser);
        }
    }

    //spawning logic
    public void Spawn()
    {
        player = GameObject.Find("hardy").GetComponent<Transform>();
        Instantiate(chaser,spawnpoint.position, Quaternion.identity);
    }

}
