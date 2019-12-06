using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addSpriteRenderer : MonoBehaviour
{

    List<GameObject> childrenList = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        foreach(Transform child in transform)
        {
            childrenList.Add(child.gameObject);
        }

        for(int i = 0; i < childrenList.Count; i++)
        {
            childrenList[i].AddComponent<SpriteRenderer>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
