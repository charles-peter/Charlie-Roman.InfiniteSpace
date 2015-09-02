using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_Radar : _BaseRadar {

	List<GameObject> Targets;

	// Use this for initialization
	void Start () 
	{
		Targets = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		float Scroll = Input.GetAxis("Mouse ScrollWheel");
		if(Scroll > 0f)
		{
			Debug.Log("Switching Targets- There are " + Targets.Count );
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == TagToDetect)
		{
			if(GetTarget()==null)
			{
				SetTarget(other.gameObject);
			}
			else if(Targets.Contains(other.gameObject)==false)
			{
				Targets.Add(other.gameObject);

			}
		}
	}
}
