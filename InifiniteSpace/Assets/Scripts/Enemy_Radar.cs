using UnityEngine;
using System.Collections;

public class Enemy_Radar : _BaseRadar {


	Enemy_Controller myController;

	// Use this for initialization
	void Start () 
	{
		myController = GetComponentInParent<Enemy_Controller>();
	}
	
	// Update is called once per frame
	void Update () 
	{
//		if(GetTarget () == null)
//		{
//			myController.TargetAcquired(false);
//		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(GetTarget())
			return;   //if we already have a target


		if(other.tag == TagToDetect) 
		{
			SetTarget(other.gameObject);
			myController.TargetAcquired(true);
			Debug.Log(gameObject.name + " Acquired the target");
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject == GetTarget())
		{
			myController.TargetAcquired(false);
			SetTarget(null);
			Debug.Log(gameObject.name + " Lost the target");
		}
	}
}
