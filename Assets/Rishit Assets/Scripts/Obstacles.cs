using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    PlayerMovem playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "player") 
        // To kill the player
        playerMovement.Die();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
