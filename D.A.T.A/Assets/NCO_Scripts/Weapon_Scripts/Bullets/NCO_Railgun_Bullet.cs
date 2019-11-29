using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCO_Railgun_Bullet : MonoBehaviour
{

    int dataCost, damages;
    public float cooldownTime, speed, lifeTime, spray;
    NCO_Railgun parameters;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {

        parameters = GetComponentInParent<NCO_Railgun>();

        dataCost = parameters.dataCost;
        damages = parameters.damages;
        cooldownTime = parameters.cooldownTime;
        speed = parameters.speed;
        lifeTime = parameters.lifeTime;
        spray = parameters.spray;
        transform.localScale = new Vector3(parameters.size, parameters.size, parameters.size);

        transform.Rotate(0, 0, Random.Range(spray, -spray));
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        StartCoroutine("LifeTime");
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

    IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

}
