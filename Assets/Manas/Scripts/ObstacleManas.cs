using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManas : MonoBehaviour
{
    public float lifeTime = 5f;
    private float timeAlive = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;

        if (timeAlive > lifeTime)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.name == "hardy")
        {
            PlayerMovem player = other.GetComponent<PlayerMovem>();
            if (player != null)
            {
                player.SlowDown();
                Destroy(this.gameObject); // Destroy the obstacle after affecting the player
            }
        }
    }
}
