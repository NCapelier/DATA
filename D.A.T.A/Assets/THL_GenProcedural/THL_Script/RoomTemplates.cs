using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    // only rooms lvl1
   public GameObject[] bottomRooms_lvl1;
   public GameObject[] topRooms_lvl1;
   public GameObject[] leftRooms_lvl1;
   public GameObject[] rightRooms_lvl1;

    // only rooms lvl2
    public GameObject[] bottomRooms_lvl2;
    public GameObject[] topRooms_lvl2;
    public GameObject[] leftRooms_lvl2;
    public GameObject[] rightRooms_lvl2;

    // only rooms lvl3
    public GameObject[] bottomRooms_lvl3;
    public GameObject[] topRooms_lvl3;
    public GameObject[] leftRooms_lvl3;
    public GameObject[] rightRooms_lvl3;

    public GameObject closedRoom;

   public List<GameObject> rooms;

   public float waitTime;
   private bool spawnedBoss;
   public GameObject boss;

   void Update(){
   
		if(waitTime <= 0 && spawnedBoss == false){
			for (int i = 0; i < rooms.Count; i++){
				if(i == rooms.Count-1){
					Instantiate(boss,rooms[i].transform.position, Quaternion.identity);
					spawnedBoss = true;
				}
			}
		} else {
			waitTime -= Time.deltaTime;
		}
   }
}
