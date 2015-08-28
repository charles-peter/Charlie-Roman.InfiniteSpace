using UnityEngine;
using System.Collections;

public class Missile_HardPoint : _BaseHardPoint{


	//GameObject MissilePrefab;   // this is the type of missile we using

	SpaceShip_Controller myController;  // need access to this so we can obtain the correct prefab for the missile
	GameObject myMissile; // my current missile

	 
	bool Loaded = false;   // do i have a mussile in me?

	public float ReloadTime = 5f;
	float timer;

	// Use this for initialization
	void Start () 
	{
		myController = FindObjectOfType<SpaceShip_Controller>();
		MyTransform = GetComponent<Transform>();

		ProjectilePrefab = myController.getMissilePrefab();

	}

	override public void Load()
	{
		myMissile = Instantiate(ProjectilePrefab,MyTransform.position,MyTransform.rotation) as GameObject;
		myMissile.transform.parent = MyTransform;
		Loaded = true;

	}

	override public bool Fire(GameObject target = null)
	{

		if(Loaded==false)
			return false; // we did not fire

		myMissile.transform.parent = null;    //unparent the transform from the spawn point
		Missile_Behavior m = myMissile.GetComponent<Missile_Behavior>();
		m.Target = target;
		m.InFlight = true;    // set the missile to active flight
		myMissile = null;    //stop holding reference to this missile;
		Loaded = false;      // no longer have a missile in me

		//start the timer for the reload
		timer = Time.time + ReloadTime;
		return true;  // we fired
	}

	// Update is called once per frame
	void Update () 
	{
		if(Loaded == false && Time.time > timer)
			Load ();
	}
}
