using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Chomper is on duty!");

        // Access Rigidbody2D component.
        rb2d = GetComponent<Rigidbody2D>();

        // Prevent player from spinning around upon collision.
        rb2d.freezeRotation = true;
    }

    void FixedUpdate()
    {
        movementControl();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Movement Control
    private void movementControl()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);

        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);

        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);

        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}