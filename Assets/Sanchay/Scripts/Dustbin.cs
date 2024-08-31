using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dustbin : MonoBehaviour
{
    Animator anim;
    PlayerMovem playermovementScript;

    private void Start()
    {
        anim = GetComponent<Animator>();
        playermovementScript = GameObject.Find("player").GetComponent<PlayerMovem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetTrigger("fall");
            playermovementScript.SlowDown();
        }

    }
}
