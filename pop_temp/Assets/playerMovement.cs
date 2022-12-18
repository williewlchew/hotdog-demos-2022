using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private bool grounded;

    private float jogForce = 9;
    private float jogVelocityCap = 3; 
    private float sprintVelocityModifier = 4;
    private float jumpVelocityValue = 10;
    private Vector2 jumpVelocity;

    private bool m_isAxisInUse = false;
    private float velocityDebug = 0;
    private float stoppingDebug = 0;

    private Vector2 movingVelocity;
    private float horizontalVelocity = 0;


    // Start is called before the first frame update
    void Start()
    {
        jumpVelocity = new Vector2(0, jumpVelocityValue);
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        grounded = true;
    }

    void Update()
    {
        if(grounded)
        {
            if(Input.GetButtonDown("Jump")){
                rb2D.velocity += jumpVelocity;
            }
            Movement();
        }
        rb2D.velocity = new Vector2(horizontalVelocity, rb2D.velocity.y);

        GetStoppingTimes();
    }

    void FixedUpdate()
    {
        if(grounded)
        {
           // rb2D.velocity = Vector2.ClampMagnitude(rb2D.velocity, jogVelocityCap);
        }
        velocityDebug = rb2D.velocity.x;
    }

    void Movement()
    {
        if(Input.GetAxisRaw("Horizontal") == 1)
        {
            // check if moving, coroutine if so
            horizontalVelocity = jogVelocityCap;
        }

        if(Input.GetAxisRaw("Horizontal") == -1)
        {
            horizontalVelocity = -jogVelocityCap;
        }

        if(Input.GetButtonDown("Fire3")){
            SprintActivate();
        }

        if(Input.GetButtonUp("Fire3")){
            SprintDeactivate();
        }
    }
    
    void GetStoppingTimes()
    {
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            m_isAxisInUse = true;
        }
        else
        {
            if(m_isAxisInUse == true)
            {
                StartCoroutine(PrintStoppingTime());
            }
            m_isAxisInUse = false;
        }  
    }

    IEnumerator PrintStoppingTime()
    {
        float stoppingTime = 0;
        while(rb2D.velocity.x > 0.01)
        {
            stoppingTime += Time.deltaTime;
            yield return null;
        }
        stoppingDebug = stoppingTime;
    }

    

    void SprintActivate()
    {
        // change velocity cap
        jogVelocityCap += sprintVelocityModifier;
    }

    void SprintDeactivate()
    {
        // change velocity cap
        jogVelocityCap -= sprintVelocityModifier;
    }

    bool IsOfCollisionTag(Collision2D collision, string tag)
    {
        if(collision.gameObject.tag == tag)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(IsOfCollisionTag(collision, "Ground"))
        {   
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(IsOfCollisionTag(collision, "Ground"))
        {
            grounded = false;
        }
    }
}
