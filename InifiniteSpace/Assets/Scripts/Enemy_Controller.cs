using UnityEngine;
using System.Collections;

public class Enemy_Controller : MonoBehaviour 
{
	Rigidbody m_rigidbody;

	GameObject target = null;

	public int m_heatlh;

	void Start()
	{
		m_rigidbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (m_heatlh <= 0)
			Destroy (gameObject);
	}

	void FixedUpdate()
	{

	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "BaseProjectile") 
		{
			m_heatlh -= other.GetComponent<Projectile>().Damage;
		}
	}
}
