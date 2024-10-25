using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runningfunc : MonoBehaviour
{
    Warden warden;


    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Chaser"))
        {
            Debug.Log("cHASE STARTDED");

            warden = (other.gameObject).GetComponent<Warden>();
            StartCoroutine("SpeedChase");
            
        }
    }

    IEnumerator  SpeedChase()
    {
        warden.speed = 5f;
        yield return new WaitForSeconds(1);
        warden.speed = 3f;
    }
}
