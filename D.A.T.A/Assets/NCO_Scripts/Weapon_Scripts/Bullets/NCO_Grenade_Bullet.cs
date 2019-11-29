using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCO_Grenade_Bullet : MonoBehaviour
{

    public float speed = 10.0f;
    public float slowDown = 0.5f;
    Rigidbody2D rb;
    //Vector2 pos = ;

    // Start is called before the first frame update
    void Start()
    {

        //pos = new Vector2(transform.position.x, transform.position.y);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(rb.velocity.x > 0)
        {
            rb.velocity -= new Vector2(slowDown, 0);
        }
        else
        {
            //Instantiate(Resources.Load("Prefabs/Spells/SubSpells/Explosion"), new pos);
            Destroy(gameObject);
        }
    }
}
