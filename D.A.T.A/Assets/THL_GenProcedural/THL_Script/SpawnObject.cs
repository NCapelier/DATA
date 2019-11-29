using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{


    public GameObject[] objects;
    public GameObject instance;
    public int orderringFactor;

    // Start is called before the first frame update
    void Start()
    {
        orderringFactor = 10;

        int rand = Random.Range(0, objects.Length);
        instance = Instantiate(objects[rand], transform.position, Quaternion.identity);

        if(instance.tag == "Building")
        {
            instance.GetComponent<SpriteRenderer>().sortingOrder = 10 - (int) (instance.transform.position.y);
        }
        else if (instance.tag == "Roof")
        {
            instance.GetComponent<SpriteRenderer>().sortingOrder = transform.parent.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
        }
        else if (instance.tag == "Publicity")
        {
            instance.GetComponent<SpriteRenderer>().sortingOrder = transform.parent.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
        }
        else if (transform.parent.gameObject != null)
        {
            instance.GetComponent<SpriteRenderer>().sortingOrder = transform.parent.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
        }

       
        StartCoroutine(Destroyer());
    }

    IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);

    }

}