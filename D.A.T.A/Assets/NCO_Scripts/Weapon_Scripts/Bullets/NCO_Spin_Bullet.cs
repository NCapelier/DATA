using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCO_Spin_Bullet : MonoBehaviour
{

    public float rotationSpeed = 2.0f;
    public float maxAngle = 120;
    GameObject player;
    //BoxCollider2D collider;

    private float angleRotated = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }


    private void Update()
    {
        player = GameObject.Find("Player");
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        transform.position = player.transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * -rotationSpeed);
        angleRotated += rotationSpeed;

        //transform.eulerAngles = new Vector3(0, 0, 90);


        //if (transform.rotation.z > originOrientation.z)
        //{
        //    Destroy(gameObject);
        //}

        if (angleRotated >= maxAngle)
        {
            //Debug.Break();
            Destroy(gameObject);
        }
    }

}
