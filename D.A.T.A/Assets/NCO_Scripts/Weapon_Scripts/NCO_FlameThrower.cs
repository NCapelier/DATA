using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCO_FlameThrower : MonoBehaviour
{
    public int dataCost, damages;
    public float cooldownTime, speed, lifeTime, spray, size;
    public GameObject bullet;

    private void Awake()
    {
        dataCost = Random.Range(1, 2);
        damages = Random.Range(1, 2);

        cooldownTime = Random.Range(0.05f, 0.1f);
        speed = Random.Range(7f, 15f);
        lifeTime = Random.Range(0.15f, 0.7f);
        spray = Random.Range(8f, 16f);
        size = Random.Range(0.8f, 1.8f);

        GetComponent<NCO_BulletManager>().cooldownTime = cooldownTime;
        GetComponent<NCO_BulletManager>().bullet = bullet;
        GetComponent<NCO_BulletManager>().speed = speed;
        GetComponent<NCO_BulletManager>().lifeTime = lifeTime;
    }
}
