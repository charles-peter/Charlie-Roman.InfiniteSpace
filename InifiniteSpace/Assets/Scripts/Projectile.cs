using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	public float speed;
	Rigidbody m_rigidbody;

	void Start()
	{
		m_rigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		m_rigidbody.velocity = m_rigidbody.transform.forward * speed;
	}
}
