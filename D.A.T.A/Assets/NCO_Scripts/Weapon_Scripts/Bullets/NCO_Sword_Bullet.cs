using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCO_Sword_Bullet : MonoBehaviour
{

    int dataCost, damages;
    public int maxAngle;
    public float cooldownTime, rotationSpeed;
    float angleRotated = 0.0f;
    NCO_Sword parameters;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {

        parameters = GetComponentInParent<NCO_Sword>();

        dataCost = parameters.dataCost;
        damages = parameters.damages;
        maxAngle = parameters.maxAngle;
        cooldownTime = parameters.cooldownTime;
        rotationSpeed = parameters.rotationSpeed;

        //transform.localScale = new Vector3(parameters.size, parameters.size, parameters.size);

    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * -rotationSpeed);
        angleRotated += rotationSpeed;

        if (angleRotated >= maxAngle)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (transform.parent.parent.tag == "Player")
        {
            if (collision.gameObject.tag == "Ennemi")
            {
                // deal damages to the ennemi
                collision.gameObject.GetComponent<EnemyBehavior>().hp -= damages;
            }

            if (collision.tag == "Ennemi" || collision.tag == "Wall")
            {
                Destroy(gameObject);
            }
        }

        if (transform.parent.parent.tag == "Ennemi")
        {
            if (collision.gameObject.tag == "Player")
            {
                // deal damages to the player                                               // please fix !!!
                collision.gameObject.GetComponent<EnemyBehavior>().hp -= damages;
            }

            if (collision.tag == "Player" || collision.tag == "Wall")
            {
                Destroy(gameObject);
            }
        }


    }

}
