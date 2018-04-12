using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

	public Vector3 offset;
	public PlayerController player;

	// Use this for initialization
	void Start () {
		
	}

	//Update is called once per frame
	void Update()
	{
		if (player)
		{
			float pos_x = player.transform.position.x;
			float pos_y = player.transform.position.y;
			float pos_z = player.transform.position.z;
			transform.position = new Vector3(pos_x, pos_y, pos_z) + offset;
		}		
	}
}
