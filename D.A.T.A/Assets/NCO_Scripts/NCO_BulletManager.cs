using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCO_BulletManager : MonoBehaviour
{
    /*
            /!\ The NCO_WeaponManager script must be placed on every wepaon prefab /!\
    */

    // is set by owner object
    public float cooldownTime = 3.0f;

    //is set in editor by weapon
    public GameObject bullet = null;

    //used for enemy dectection range
    public float speed;
    public float lifeTime;

    // as to be set as "true" to shoot
    public bool shoot = false;
    public bool enemyShoot = false;

    // name of the last instantiated bullet
    GameObject newBullet;


    private void Update()
    {
        if(shoot == true)
        {
            shoot = false;
            Shoot();
        }

        if(enemyShoot == true)
        {
            enemyShoot = false;
            EnemyShoot();
        }
    }

    public void Shoot()
    {
        newBullet = (GameObject)Instantiate(bullet, transform.position, GetComponentInParent<NCO_Weapons>().orientation);
        newBullet.transform.parent = gameObject.transform;
    }

    public void EnemyShoot()
    {
        newBullet = (GameObject)Instantiate(bullet, transform.position, GetComponentInParent<EnemyBehavior>().orientation);
        newBullet.transform.parent = gameObject.transform;
    }

}
