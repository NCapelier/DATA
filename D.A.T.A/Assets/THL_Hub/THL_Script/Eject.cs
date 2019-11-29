using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Eject : MonoBehaviour
{
	public GameObject item;
	private Transform player;
	//public int DistanceEjection = 5;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	public void SpawnDroppedItem(){
		Vector2 playerPos = new Vector2(player.position.x , player.position.y +3);
		Instantiate(item, playerPos, Quaternion.identity);
	}
        
    
}
