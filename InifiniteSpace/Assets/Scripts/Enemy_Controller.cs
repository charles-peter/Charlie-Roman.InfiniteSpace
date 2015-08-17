using UnityEngine;
using System.Collections;

public class Enemy_Controller : MonoBehaviour 
{
	public Vector3 SpawnPosition;

	void Start()
	{
		GetComponet.rigidbody.position = SpawnPosition;
	}

}
