using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	public float speed;
	public float LifeTime;
	Rigidbody m_rigidbody;
	float life = 0.0f;


	void Start()
	{
		m_rigidbody = GetComponent<Rigidbody>();
		LifeTime += Time.time;

	}

	void Update()
	{
		life = Time.time;
		if (life > LifeTime)
			Destroy(gameObject);
	}

	void FixedUpdate()
	{
		m_rigidbody.velocity = m_rigidbody.transform.forward * speed;
	}
}
