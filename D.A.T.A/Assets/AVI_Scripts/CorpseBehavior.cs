using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseBehavior : MonoBehaviour
{
    public int data = 3;
    public float hackTime = 3;
    bool isCloseEnouth = false;
    bool isTryingHack = false;
    int playerData;
    GameObject dataLoading;

    private void Start()
    {
        //playerData = GameObject.Find("Player").GetComponent<>().data;                   mising data script
    }

    // Update is called once per frame
    void Update()
    {
        /*if (data < 1)
        {
            Destroy(gameObject);
        }*/

        if (isCloseEnouth == true && isTryingHack == false)
        {
            isTryingHack = true;
            StartCoroutine("Hack");
        }

    }

    IEnumerator Hack()
    {
        dataLoading = (GameObject)Instantiate(Resources.Load("Prefabs/Others/DataLoading"));
        dataLoading.transform.parent = gameObject.transform;
        dataLoading.transform.position = new Vector2(transform.position.x, transform.position.y + 5);

        yield return new WaitForSeconds(hackTime);


        if (isCloseEnouth == true)
        {
            //playerData += data;
            Destroy(dataLoading);
        }

        isTryingHack = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isCloseEnouth = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isCloseEnouth = false;
        }
    }

    public int Data
    {
        get
        {
            return data;
        }
        set
        {
            data = value;
        }
    }

}






