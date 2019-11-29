using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCO_Sword : MonoBehaviour
{
    public int dataCost, damages, maxAngle;
    public float cooldownTime, rotationSpeed, spray, size;

    public float speed, lifeTime = 1.0f;

    public GameObject bullet;

    private void Awake()
    {
        dataCost = Random.Range(1, 2);
        damages = Random.Range(1, 2);
        maxAngle = Random.Range(100, 140);

        cooldownTime = Random.Range(0.6f, 1.25f);
        rotationSpeed = Random.Range(5.0f, 8.0f);

        GetComponent<NCO_BulletManager>().cooldownTime = cooldownTime;
        GetComponent<NCO_BulletManager>().bullet = bullet;
        GetComponent<NCO_BulletManager>().speed = speed;
        GetComponent<NCO_BulletManager>().lifeTime = lifeTime;
    }

}
