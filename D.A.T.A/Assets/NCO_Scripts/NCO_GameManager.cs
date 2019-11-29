using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCO_GameManager : MonoBehaviour
{

    GameObject instance;
    public GameObject player;
    public GameObject[] allWeapons;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        instance = (GameObject)Instantiate(Resources.Load("Prefabs/Weapons/Uzi"), player.transform);
        player.GetComponent<NCO_Weapons>().activeWeapons[0] = instance;

        instance = (GameObject)Instantiate(Resources.Load("Prefabs/Weapons/Shotgun"), player.transform);
        player.GetComponent<NCO_Weapons>().activeWeapons[1] = instance;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
