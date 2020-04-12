using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static Rigidbody2D playerRB;
    public float thrust;
    public static bool hasStarted = false;
    private bool spin = false;

    private bool isDead = false;
    

    private bool jump = true;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerRB.gravityScale = 0f;
        playerRB.constraints = RigidbodyConstraints2D.FreezeRotation;

    }
   
    private void Update()
    {
        if (spin)
        {
            transform.Rotate(0, 0, -360 * Time.deltaTime);
        }
        if (Input.GetMouseButtonDown(0) && jump && hasStarted )
        {
            Time.timeScale = 0.5f;
            playerRB.constraints = RigidbodyConstraints2D.None;
            spin = true;

            playerRB.AddForce((transform.up/Time.deltaTime) * thrust );
            jump = false;
        }
        if(gameObject.transform.position.y <= -8f )
        {
            isDead = true;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -7f, gameObject.transform.position.z);
            //playerRB.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if (isDead)
        {
            isDead = false;
            hasDied();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "wall")
        {
            transform.rotation = Quaternion.identity ;
            Time.timeScale = 1f;
            playerRB.constraints = RigidbodyConstraints2D.FreezeRotation;
            jump = true;
            spin = false;
        }
    }

    private void hasDied()
    {
        //Debug.Log("Dead");
        onjects.objSpeed = 0f;
    }
}
