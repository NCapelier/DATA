using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCO_Uzi : MonoBehaviour
{
    public int dataCost, damages;
    public float cooldownTime, speed, lifeTime, spray, size;
    public GameObject bullet;

    private void Awake()
    {
        dataCost = Random.Range(1, 2);
        damages = Random.Range(1, 2);

        cooldownTime = Random.Range(0.1f, 0.45f);
        speed = Random.Range(40f, 55);
        lifeTime = Random.Range(1.2f, 2.5f);
        spray = Random.Range(1.5f, 4.5f);
        size = Random.Range(0.4f, 0.8f);

        GetComponent<NCO_BulletManager>().cooldownTime = cooldownTime;
        GetComponent<NCO_BulletManager>().bullet = bullet;
        GetComponent<NCO_BulletManager>().speed = speed;
        GetComponent<NCO_BulletManager>().lifeTime = lifeTime;
    }

}
