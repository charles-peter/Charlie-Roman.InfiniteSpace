using UnityEngine;
using System.Collections;


[RequireComponent (typeof(SphereCollider))]
public class _BaseRadar : MonoBehaviour 
{

	GameObject myTarget = null;

	SphereCollider myCollider;
	public float DetectionRange = 20f;
	public string TagToDetect = "Default";

	void Awake()
	{
		myCollider = GetComponent<SphereCollider>();
		myCollider.radius = DetectionRange;
		myCollider.isTrigger = true;

	}

	void Update()
	{
		//Debug.DrawLine(gameObject.transform.position, gameObject.transform.forward * DetectionRange, Color.red);
	}


	public void SetTarget(GameObject t)
	{
		myTarget = t;
	}
	public GameObject GetTarget()
	{
		return myTarget;
	}

//	void OnTriggerEnter(Collider other)
//	{
//		if(myTarget)
//			return;   //if we already have a target
//
//
//		if(other.tag == "Player") 
//		{
//			SetTarget(other.gameObject);
//		}
//	}
}
