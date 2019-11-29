using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int hp;
    [SerializeField]
    private int hpmin = 5;
    [SerializeField]
    private int hpmax = 10;


    [SerializeField]
    private int def = 0;
    [SerializeField]
    private int speed = 5;
    public GameObject player;

    [SerializeField]
    private GameObject gameManager;
    private Pathfinding pathfinding;

    public int detectionDistance;
    bool tooClose = false;


    public bool canatk = true;

    List<Node> finalPath = new List<Node>();
    Vector3 previousTargetPos;

    int i;

    bool canCastWeapon = true;
    float cdWeapon = 1.0f;
    float range;
    float attackAngle;
    public Quaternion orientation;
    public GameObject weapon;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        weapon = GenerateWeapon();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    GameObject corpse;

    // Start is called before the first frame update
    void Start()
    {
        hp = UnityEngine.Random.Range(hpmin, hpmax);


        pathfinding = gameManager.GetComponent<Pathfinding>();

        range = weapon.GetComponent<NCO_BulletManager>().speed * weapon.GetComponent<NCO_BulletManager>().lifeTime;
    }

    // Update is called once per frame
    void Update()
    {

        orientation = GetComponentInChildren<NCO_EnnemyAim>().transform.rotation;

        if (hp < 1)
        {
            Death();
        }

        if (Vector3.Distance(player.transform.position, transform.position) <= detectionDistance)
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= range)
            {
                if (Vector3.Distance(player.transform.position, transform.position) <= (range / 3))
                {
                    tooClose = true;
                }

                else
                {
                    tooClose = false;
                    finalPath = new List<Node>();
                }
            }

            else
            {
                tooClose = false;
                if (previousTargetPos != player.transform.position)
                {
                    finalPath = pathfinding.FindPath(transform.position, player.transform.position);
                    i = 0;
                }

            }
        }

        else
        {
            tooClose = false;
            finalPath = new List<Node>();
        }

        previousTargetPos = player.transform.position;

        if (tooClose)
        {
            Debug.Log("tooclose");
            Vector3 run = transform.position - player.transform.position;
            finalPath = pathfinding.FindPath(transform.position, transform.position + run);
            i = 0;
        }

        if (finalPath.Count > 0)
        {
            if (i < finalPath.Count)
            {
                if (transform.position != finalPath[i].pos)
                {
                    transform.position = Vector2.MoveTowards(transform.position, finalPath[i].pos, speed * Time.deltaTime);
                }
                else
                {
                    i++;
                    try
                    {
                        transform.position = Vector2.MoveTowards(transform.position, finalPath[i].pos, speed * Time.deltaTime);
                    }

                    catch (Exception e)
                    {
                        Debug.Log(e);
                        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                    }
                }
            }
        }

    }


    void Death()
    {
        Instantiate(Resources.Load("Prefabs/Corpse"), gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


    public int HP
    {
        get
        {
            return hp;
        }
        set
        {
            value = value - def;
            if (value > 0)
            {
                hp = hp - value;
            }
        }
    }

    public GameObject GenerateWeapon()
    {
        int i = UnityEngine.Random.Range(0, gameManager.GetComponent<NCO_GameManager>().allWeapons.Length);
        GameObject instance = (GameObject)Instantiate(gameManager.GetComponent<NCO_GameManager>().allWeapons[i], gameObject.transform);
        return instance;
    }

}
