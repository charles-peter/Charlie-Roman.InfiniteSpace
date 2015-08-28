using UnityEngine;
using System.Collections;

public class _BaseHardPoint : MonoBehaviour {

	//This is the base class for mounting weapons on the ship...spawn points for the projectles



	public GameObject ProjectilePrefab;   // this is what we will be spawning...missiles-laser-w/e
	Transform myTransform; 				//where I am located
	public Transform MyTransform {
		get {
			return myTransform;
		}
		set {
			myTransform = value;
		}
	}

   			 

	virtual public void Load()
	{
		//this function will load/Instantiate the projectile to be fired;
	}

	virtual public bool Fire(GameObject target = null /*what are we firing at*/ )
	{
		//this function will actually fire the projectile
		return true;
	}
}
