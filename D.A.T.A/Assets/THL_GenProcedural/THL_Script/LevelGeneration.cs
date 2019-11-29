using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public Transform[] startingPositions;
    public GameObject[] rooms;

    private int direction;
    public float moveAmount;

    private float timeBtwRoom;
    public float startTimeBtwRoom = 0.25f;

    private bool stopGeneration;

	

    // public LayerMask room;

    // Start is called before the first frame update
    void Start()
    {
        int randStartingPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartingPos].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);

        direction = Random.Range(1, 6);

    }

    private void Update()
    {
        if (timeBtwRoom <= 0 && stopGeneration == false)
        {
            Move();
            timeBtwRoom = startTimeBtwRoom;
        }
        else
        {
            timeBtwRoom -= Time.deltaTime;
        }
    }
    private void Move()
    {
        if (direction == 1 || direction == 2)
        //Aller à droite
        {
            Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
            transform.position = newPos;
        }
        else if (direction == 3 || direction == 4) 
        //Aller a gauche
        {
            Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
            transform.position = newPos;
        }
        else if (direction == 5)
        //Aller en bas 
        {
          //  Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);

          //  if (roomDetection.GetComponent<RoomType>().type != 1 && roomDetection.GetComponent<RoomType>.type !=3)
           // {
           //     room.GetComponent<RoomType>().RoomDestruction();

           //     int randBottomRoom = Random.Range(1, 4);
            //    if (randBottomRoom == 2)
            //    {
            //        randBottomRoom = 1;
            //    }
            //    Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
           // }

            Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
            transform.position = newPos;

           
        }
        else if (direction == 6)
        //Aller en haut 
        {
           

            Vector2 newPos = new Vector2(transform.position.x, transform.position.y + moveAmount);
            transform.position = newPos;


        }
        else
        {
            stopGeneration = true;
        }

        Instantiate(rooms[0], transform.position, Quaternion.identity);
        direction = Random.Range(1, 6);

    }
}
