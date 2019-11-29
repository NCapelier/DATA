using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCO_EnnemyAim : MonoBehaviour
{

    //player gobject
    GameObject player;

    // gestion orientation
    Vector3 angleDiff;
    float orientation;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<EnemyBehavior>().player;
    }

    // Update is called once per frame
    void Update()
    {

        angleDiff = player.transform.position - transform.position;
        angleDiff.Normalize();

        orientation = Mathf.Atan2(angleDiff.y, angleDiff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, orientation /*- 90*/);
    }
}
