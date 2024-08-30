using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] float flyHeight = 5f;
    [SerializeField] float flyTime = 5f;
    [SerializeField] float flySpeed = 2f;

    [SerializeField] Alcohol alc;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weed"))
        {
            StartCoroutine(GetHigh(this.gameObject));
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Alcohol"))
        {
            Debug.Log("alchohol!!");
            alc.isDrunk = true;
            Destroy(collision.gameObject);
        }
            
    }

    
    private IEnumerator GetHigh(GameObject player)
    {
        Vector3 flyPos = new Vector3(player.transform.position.x, flyHeight, player.transform.position.z);
        transform.position = Vector3.Lerp(player.transform.position, flyPos, flySpeed);
        rb.useGravity = false;
        yield return new WaitForSeconds(flyTime);
        rb.useGravity = true;

    }
}
