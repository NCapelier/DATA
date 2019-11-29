using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCO_Weapons : MonoBehaviour
{

    // right joystick management
    float horizontalInput, verticalInput;
    Vector2 input;
    Vector3 rotate;
    public Quaternion orientation;

    // weapons cooldowns
    bool canCastWeapon01 = true;
    bool canCastWeapon02 = true;

    float cdWeapon01 = 1.0f;
    float cdWeapon02 = 1.0f;

    // active weaponss array
    public GameObject[] activeWeapons = new GameObject[2];

    // visual feedback
    GameObject vCooldown;
    VisualCooldown cool1;
    VisualCooldown cool2;

    // Start is called before the first frame update
    void Start()
    {
        vCooldown = GameObject.Find("PlayerWeapons");
        //cool1 = vCooldown.transform.GetChild(0).GetChild(0).gameObject.GetComponent<VisualCooldown>();
        //cool2 = vCooldown.transform.GetChild(1).GetChild(0).gameObject.GetComponent<VisualCooldown>();
    }

    // Update is called once per frame
    void Update()
    {

        // input : check if right joystick is on default position
        // rotate : trigonometric current right joystick orientation
        // orientation : converted current right joystick orientation in quaternion (used for instancing)

        verticalInput = Input.GetAxis("Vertical_R");
        horizontalInput = Input.GetAxis("Horizontal_R");

        input = new Vector2(horizontalInput, verticalInput);
        rotate = new Vector3(0, 0 , Mathf.Atan2(verticalInput, horizontalInput) * 180 / Mathf.PI);
        orientation = Quaternion.Euler(rotate);


        /*
        all joystick orientation iterations here :

        Debug.Log("INPUT : " + input);
        orientation.Set(horizontalInput, verticalInput, 0, 0);
        orientation = Quaternion.Euler(rotate.x, rotate.y, rotate.z);
        Debug.Log("ORIENTATION : " + orientation);

       */

        // all weapons inputs
        if ((input != Vector2.zero && Input.GetButton("Weapon_01")) && canCastWeapon01 == true && activeWeapons[0] != null)
        {
            StartCoroutine("Weapon01Cooldown");
            Weapon01();
        }

        if ((input != Vector2.zero && Input.GetButton("Weapon_02")) && canCastWeapon02 == true && activeWeapons[1] != null)
        {
            StartCoroutine("Weapon02Cooldown");
            Weapon02();
        }

    }


    // all weapons cooldowns methods
    IEnumerator Weapon01Cooldown()
    {
        canCastWeapon01 = false;
        cdWeapon01 = activeWeapons[0].GetComponent<NCO_BulletManager>().cooldownTime;
        //cool1.StartCoolDown(cdWeapon01);
        yield return new WaitForSeconds(cdWeapon01);
        canCastWeapon01 = true;
    }
    IEnumerator Weapon02Cooldown()
    {
        canCastWeapon02 = false;
        cdWeapon02 = activeWeapons[1].GetComponent<NCO_BulletManager>().cooldownTime;
        yield return new WaitForSeconds(cdWeapon02);
        canCastWeapon02 = true;
    }


    // all weapons

    private void Weapon01()
    {
        //
        activeWeapons[0].GetComponent<NCO_BulletManager>().shoot = true;

    }

    private void Weapon02()
    {
        //
        activeWeapons[1].GetComponent<NCO_BulletManager>().shoot = true;

    }

}
