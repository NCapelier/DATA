using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingOrderringLayer : MonoBehaviour
{

    public int orderingFactor;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder -= (int) (GetComponent<Transform>().position.y / orderingFactor) ;
                
    }


}
