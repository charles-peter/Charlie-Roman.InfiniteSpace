using UnityEngine;
using System.Collections;

public class Enemy_Controller : MonoBehaviour 
{
	public Vector3 SpawnPosition;
	Rigidbody m_rigidbody;

	void Start()
	{
		m_rigidbody = GetComponent<Rigidbody>();
		m_rigidbody.position = SpawnPosition;
	}

}
