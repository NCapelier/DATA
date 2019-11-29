﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
	
    void OnTriggerEnter2D(Collider2D collision){
		if(collision.gameObject.tag == "ClosedWall"){
			Destroy(collision.gameObject);
		}
	}
}
