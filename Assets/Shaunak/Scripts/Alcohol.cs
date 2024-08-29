using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

/*
Alcohol (Power Down):
Effects:
->Swap controls
->Blurry Screen 
*/
public class Alcohol : MonoBehaviour
{
    [SerializeField] VisualEffect visualEffect;
    [SerializeField] bool isDrunk;
    [SerializeField] Player player;
  private void Start()
  {
    visualEffect.enabled = false;
    isDrunk = false;
  }

  private void Update()
  {
    //if Drunk then start visual effect and swap controls using couroutine
    if(isDrunk == true)
    {
        StartCoroutine("Drunk");

    }

    //Dummy key to enable drunk
    if(Input.GetKeyDown(KeyCode.K))
    {
        isDrunk = true;
    }
  }


  IEnumerator Drunk()
  {
    visualEffect.enabled = true;
    player.moveleft = KeyCode.D;
    player.moveright = KeyCode.A;

    yield return new WaitForSeconds(10);

    visualEffect.enabled = false;
    player.moveleft = KeyCode.A;
    player.moveright = KeyCode.D;
    isDrunk = false;
  }
}
