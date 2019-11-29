using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCO_Pistol : MonoBehaviour
{
    public int dataCost, damages;
    public float cooldownTime, speed, lifeTime, spray, size;
    public GameObject bullet;

    private void Awake()
    {
        dataCost = Random.Range(1, 2);
        damages = Random.Range(1, 2);

        cooldownTime = Random.Range(0.5f, 1.2f);
        speed = Random.Range(15f, 25f);
        lifeTime = Random.Range(2f, 4f);
        spray = Random.Range(0.5f, 1.5f);
        size = Random.Range(0.6f, 1.4f);

        GetComponent<NCO_BulletManager>().cooldownTime = cooldownTime;
        GetComponent<NCO_BulletManager>().bullet = bullet;
        GetComponent<NCO_BulletManager>().speed = speed;
        GetComponent<NCO_BulletManager>().lifeTime = lifeTime;
    }

}
