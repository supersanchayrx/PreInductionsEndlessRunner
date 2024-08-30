using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovem : MonoBehaviour
{

    [SerializeField] float speed;
    private float originalSpeed;
    private bool isSlowed = false;
    [SerializeField] private float slowTime = 10f;
    private bool isDead = false;
    Rigidbody rb;
    Animator anim;
    public KeyCode moveleft;
    public KeyCode moveright;

    bool movingRight = false;
    bool movingLeft = false;
    
    //[SerializeField] Animator anim;
    void Start()
    {   
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", false);
        originalSpeed = speed;
        moveleft = KeyCode.A;
        moveright = KeyCode.D;
    }
    private void Update()
    {
        if (Input.GetKeyDown(moveright))
        {
            movingRight = true;
        }
        if (Input.GetKeyDown(moveleft))
        {
            movingLeft = true;
        }
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        /*float z = Input.GetAxis("Horizontal");
        float x = Input.GetAxis("Vertical");
        Vector3 moveInput = new Vector3 (x, 0, -z);*/

        /* if(moveInput.x > 0.1f ) 
         {
             transform.position += transform.forward * speed * Time.deltaTime;
         }
        */
        if (isDead) return;

        if (Input.GetMouseButtonDown(0)) 
        {
            anim.SetBool("isRunning", true);

        }

        if(anim.GetBool("isRunning"))
        {
            //rb.velocity = Vector3.forward.normalized * speed * 100f * Time.deltaTime;
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed*100f*Time.deltaTime);
            //rb.AddForce(Vector3.forward * speed  * Time.deltaTime, ForceMode.VelocityChange);



            if (transform.position.x < 5f && movingRight)
            {
                transform.position += transform.right * 5f;
                movingRight = false;
            }


            if (transform.position.x > -5f && movingLeft)
            {
                transform.position += -transform.right * 5f;
                movingLeft = false;
            }
        }
        
    }

    public void SlowDown()
    {
        if (!isSlowed)
        {
            isSlowed = true;
            speed *= 0.75f; // Reduce speed by 25%
            Debug.Log("Slowed!");
            StartCoroutine(RemoveSlowdown());
        }
        else
        {
            // Player is already slowed, so they die
            Die();
        }
    }
    private IEnumerator RemoveSlowdown()
    {
        yield return new WaitForSeconds(slowTime);
        if (!isDead) // Only reset speed if the player is not dead
        {
            isSlowed = false;
            speed = originalSpeed; // Reset speed to original
        }
    }

    public void Die()
    {
        isDead = true;
        Destroy(this.gameObject); // Destroy player object
    }
    public bool IsSlowed()
    {
        return isSlowed;
    }
}
