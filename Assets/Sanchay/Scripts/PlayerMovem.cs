using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovem : MonoBehaviour
{

    [SerializeField] public float speed;
    private float originalSpeed;
    private bool isSlowed = false;
    [SerializeField] private float slowTime = 10f, jumpForce, Ground_distcheck, jump_buffer , jump_timer;
    private bool isDead = false;
    Rigidbody rb;
    Animator anim;
    public KeyCode moveleft;
    public KeyCode moveright;

    public LeaderBoardManger leaderboard;

    public bool isGrounded, isJumping;

    public LayerMask groundlayer;

    //bool movingRight = false;
    //bool movingLeft = false;
    int cur_lane;
    [SerializeField] float switch_speed;
    [SerializeField] Transform right_lane, left_lane, center_lane;
    spawner_despawner spawner_Despawner;

    scoreManager scoreManagerScript;

    public GameObject menuPanel;

    //[SerializeField] Animator anim;
    void Start()
    {   
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", true);
        originalSpeed = speed;
        moveleft = KeyCode.A;
        moveright = KeyCode.D;
         isJumping = false;
        spawner_Despawner = gameObject.transform.Find("box_check").GetComponent<spawner_despawner>();
        scoreManagerScript = GameObject.Find("score").GetComponent<scoreManager>();
        menuPanel.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isRunning", true);

        }

        Debug.DrawRay(transform.position, Vector3.down * Ground_distcheck,Color.red);

        jump_check();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
            anim.SetBool("isRunning", false);
            anim.SetBool("jumping",true);
            



            jump();
        }

        else
        {
            
            isJumping = false;
            anim.SetBool("jumping", false);
            anim.SetBool("isRunning", true);

        }

        if (rb.velocity.y < 0 && !isGrounded)
        {
            anim.SetBool("isFalling", true);
        }
        else if (rb.velocity.y !< 0 && isGrounded)
        {
            anim.SetBool("isFalling", false);
            
        }


        //jump_timer -= Time.deltaTime;
        /*if (Input.GetKeyDown(moveright))
        {
            movingRight = true;
        }
        if (Input.GetKeyDown(moveleft))
        {
            movingLeft = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump_check();
            jump();
        }
        */
        /*jump_check();
        jump();*/
        if (Input.GetKeyDown(moveright))
        {
            if (cur_lane == 0)
            {
                cur_lane = 1;
            }
            if (cur_lane == -1)
            {
                cur_lane = 0;
            }
        }
        if (Input.GetKeyDown(moveleft))
        {
            if (cur_lane == 0)
            {
                cur_lane = -1;
            }
            if (cur_lane == 1)
            {
                cur_lane = 0;
            }
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

        

        if(anim.GetBool("isRunning"))
        {
            //rb.velocity = Vector3.forward.normalized * speed * 100f * Time.deltaTime;
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 100f*speed*Time.deltaTime);
            //rb.AddForce(Vector3.forward * speed  * Time.deltaTime, ForceMode.VelocityChange);



            /*if (transform.position.x < 5f && movingRight)
            {
                transform.position += transform.right * 5f;
                movingRight = false;
            }


            if (transform.position.x > -5f && movingLeft)
            {
                transform.position += -transform.right * 5f;
                movingLeft = false;
            }*/
            if (cur_lane == 0)
            {
                Vector3 new_pos = new Vector3(center_lane.position.x, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, new_pos, switch_speed * Time.deltaTime);
            }
            if (cur_lane == 1)
            {


                Vector3 new_pos = new Vector3(right_lane.position.x, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, new_pos, switch_speed * Time.deltaTime);

            }
            if (cur_lane == -1)
            {

                Vector3 new_pos = new Vector3(left_lane.position.x, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, new_pos, switch_speed * Time.deltaTime);

            }
            
        }
        

    }

    public void SlowDown()
    {
        if (!isSlowed)
        {
            scoreManagerScript.ReduceScore();
            isSlowed = true;
            speed *= 0.75f; // Reduce speed by 25%
            Debug.Log("Slowed!");
            spawner_Despawner.Spawn();
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
    /*private IEnumerator jumpanim()
    {
        anim.SetBool("isRunning", false);
        anim.SetBool("jump", true);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("isRunning", true);
        anim.SetBool("jump", false);
    }*/

    public void Die()
    {

        leaderboard.UploadEntry();
        isDead = true;
        //Destroy(this.gameObject); // Destroy player object
        anim.SetBool("ded", true); // Playing sad animation instead of destroying player. :)

        menuPanel.gameObject.SetActive(true);

    }
    public bool IsSlowed()
    {
        return isSlowed;
    }

    private void jump_check()
    {
        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, Ground_distcheck, groundlayer);
    }
    private void jump()
    {
        Debug.Log("Jump Called");
        /*if (isJumping)*/
        {
            Debug.Log("jumping");

            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);

            
            //StartCoroutine(jumpanim());
            
            //rb.velocity = new Vector3(rb.velocity.x, 10, 0);
        }
    }
    
}
