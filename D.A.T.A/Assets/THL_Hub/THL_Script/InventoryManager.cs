using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
	public InventoryRun inventory;

	void Start (){
	
	}

	void Update (){
	
		if (Input.GetKeyDown(KeyCode.I))
		{
			inventory.gameObject.SetActive(!inventory.gameObject.activeSelf);
		}
	}
}
