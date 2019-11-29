using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCO_EnnemyWeapon : MonoBehaviour
{

    GameObject player;

    // aim management
    public Quaternion orientation;
    Transform rotate;

    // weapons cooldowns
    bool canCastWeapon = true;

    float cdWeapon = 1.0f;


    // active weaponss array
    public GameObject weapon;


    // Start is called before the first frame update


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        weapon = GetComponent<EnemyBehavior>().weapon;


        //rotate = new Vector3(0, 0, Mathf.Atan2(verticalInput, horizontalInput) * 180 / Mathf.PI);
    }

    void Update()
    {


        // ennemy shoot conditions
        if (canCastWeapon == true && weapon != null)
        {
            StartCoroutine("WeaponCooldown");
            Weapon();
        }

    }


    IEnumerator WeaponCooldown()
    {
        canCastWeapon = false;
        cdWeapon = weapon.GetComponent<NCO_BulletManager>().cooldownTime;
        yield return new WaitForSeconds(cdWeapon);
        canCastWeapon = true;
    }


    private void Weapon()
    {
        //
        weapon.GetComponent<NCO_BulletManager>().enemyShoot = true;


    }

}
