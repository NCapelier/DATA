using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
   public int openingDirection;
    // 1 -> need bottom door_lvl1
    // 2 -> need top door_lvl1
    // 3 -> need left door_lvl1
    // 4 -> need right door_lvl1

    // 5 -> need bottom door_lvl2
    // 6 -> need top door_lvl2
    // 7 -> need left door_lvl2
    // 8 -> need right door_lvl2

    // 9 -> need bottom door_lvl3
    // 10 -> need top door_lvl3
    // 11 -> need left door_lvl3
    // 12 -> need right door_lvl3

    private RoomTemplates templates;
   private int rand;
   private bool spawned = false;

   public float waitTime = 4f;


	void Start()
	{
		Destroy(gameObject, waitTime);
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		Invoke("Spawn", 0.1f);
	}



	void Spawn(){
		if(spawned == false){
            // spawn room lvl1
			if(openingDirection == 1){
				//need to spawn a room with bottom door lvl1
				rand = Random.Range(0, templates.bottomRooms_lvl1.Length);
				Instantiate(templates.bottomRooms_lvl1[rand], transform.position, templates.bottomRooms_lvl1[rand].transform.rotation);

			} else if(openingDirection == 2){
				//need to spawn a room with top door lvl1
				rand = Random.Range(0, templates.topRooms_lvl1.Length);
				Instantiate(templates.topRooms_lvl1[rand], transform.position, templates.topRooms_lvl1[rand].transform.rotation);

			}else if(openingDirection == 3){
				//need to spawn a room with left door lvl1
				rand = Random.Range(0, templates.leftRooms_lvl1.Length);
				Instantiate(templates.leftRooms_lvl1[rand], transform.position, templates.leftRooms_lvl1[rand].transform.rotation);

			}else if(openingDirection == 4){
				//need to spawn a room with right door lvl1
				rand = Random.Range(0, templates.rightRooms_lvl1.Length);
				Instantiate(templates.rightRooms_lvl1[rand], transform.position, templates.rightRooms_lvl1[rand].transform.rotation);
			}
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            // spawn room lvl2
            else if (openingDirection == 5)
            {
                //need to spawn a room with bottom door lvl2
                rand = Random.Range(0, templates.bottomRooms_lvl2.Length);
                Instantiate(templates.bottomRooms_lvl2[rand], transform.position, templates.bottomRooms_lvl2[rand].transform.rotation);

            }
            else if (openingDirection == 6)
            {
                //need to spawn a room with top door lvl2
                rand = Random.Range(0, templates.topRooms_lvl2.Length);
                Instantiate(templates.topRooms_lvl2[rand], transform.position, templates.topRooms_lvl2[rand].transform.rotation);

            }
            else if (openingDirection == 7)
            {
                //need to spawn a room with left door lvl2
                rand = Random.Range(0, templates.leftRooms_lvl2.Length);
                Instantiate(templates.leftRooms_lvl2[rand], transform.position, templates.leftRooms_lvl2[rand].transform.rotation);

            }
            else if (openingDirection == 8)
            {
                //need to spawn a room with right door lvl2
                rand = Random.Range(0, templates.rightRooms_lvl2.Length);
                Instantiate(templates.rightRooms_lvl2[rand], transform.position, templates.rightRooms_lvl2[rand].transform.rotation);
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            // spawn room lvl3
            else if (openingDirection == 9)
            {
                //need to spawn a room with bottom door lvl3
                rand = Random.Range(0, templates.bottomRooms_lvl3.Length);
                Instantiate(templates.bottomRooms_lvl3[rand], transform.position, templates.bottomRooms_lvl3[rand].transform.rotation);

            }
            else if (openingDirection == 10)
            {
                //need to spawn a room with top door lvl3
                rand = Random.Range(0, templates.topRooms_lvl3.Length);
                Instantiate(templates.topRooms_lvl3[rand], transform.position, templates.topRooms_lvl3[rand].transform.rotation);

            }
            else if (openingDirection == 11)
            {
                //need to spawn a room with left door lvl3
                rand = Random.Range(0, templates.leftRooms_lvl3.Length);
                Instantiate(templates.leftRooms_lvl3[rand], transform.position, templates.leftRooms_lvl3[rand].transform.rotation);

            }
            else if (openingDirection == 12)
            {
                //need to spawn a room with right door lvl3
                rand = Random.Range(0, templates.rightRooms_lvl3.Length);
                Instantiate(templates.rightRooms_lvl3[rand], transform.position, templates.rightRooms_lvl3[rand].transform.rotation);
            }


            spawned = true;

		}

		 
	}
   	   void OnTriggerEnter2D(Collider2D other){
		 	 if(other.CompareTag("SpawnRoomPoint") ){
				if(other.GetComponent<SpawnRoom>().spawned == false && spawned == false)
					Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
			 	 Destroy(gameObject);
			 }
			 spawned = true;

   }
}
