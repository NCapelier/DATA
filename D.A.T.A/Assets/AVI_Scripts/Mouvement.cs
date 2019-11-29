using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{

    private Rigidbody2D rb2D;


    private Animator myAnim;
    private bool playerMoving;

    [SerializeField]
    private float speed = 2;


    [System.NonSerialized]
    public float horizontalInput, verticalInput;
    int playerOrientation;


    // Use this for initialization
    void Start()
    {

        rb2D = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        Movement();


        if (verticalInput > 0)
        {
            playerOrientation = 0;
        }

        else if (verticalInput < 0)
        {
            playerOrientation = 1;
        }

        else if (horizontalInput > 0)
        {
            playerOrientation = 2;
        }

        else if (horizontalInput < 0)
        {
            playerOrientation = 3;
        }

        myAnim.SetFloat("MoveX", horizontalInput);
        myAnim.SetFloat("MoveY", verticalInput);
        myAnim.SetBool("PlayerMoving", playerMoving);
        myAnim.SetInteger("Orientation", playerOrientation);
    }

    void Movement()
    {

        Vector2 input = new Vector2(horizontalInput, verticalInput);

        if (input != Vector2.zero)
        {
            playerMoving = true;
        }
        else
        {
            playerMoving = false;
        }
        Vector2 direction = input.normalized;
        Vector2 velocity = direction * speed;

        rb2D.MovePosition(rb2D.position + velocity * Time.deltaTime);
    }
}
