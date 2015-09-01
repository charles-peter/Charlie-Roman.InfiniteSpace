using UnityEngine;
using System.Collections;

public class Laser_Hardpoint : _BaseHardPoint {


	public float fireRate;
	float nextFire = 0.0f;

	SpaceShip_Controller myController;  // need access to this so we can obtain the correct prefab for the Laser



	// Use this for initialization
	void Start () 
	{
		myController = FindObjectOfType<SpaceShip_Controller>();
		MyTransform = GetComponent<Transform>();
		ProjectilePrefab = myController.getLaserPrefab();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	override public bool Fire(GameObject target = null)
	{
		if(Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(ProjectilePrefab, MyTransform.position, MyTransform.rotation);
			return true;
		}
		return false;
	}
}
