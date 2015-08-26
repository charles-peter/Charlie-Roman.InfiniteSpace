using UnityEngine;
using System.Collections;

public class Radar_Controller : MonoBehaviour 
{
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player") 
		{
			GetComponentInParent<Enemy_Controller>().Target = other.gameObject;
		}
	}
}
