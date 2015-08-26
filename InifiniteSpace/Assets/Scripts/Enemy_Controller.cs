using UnityEngine;
using System.Collections;

public class Enemy_Controller : MonoBehaviour 
{
	Rigidbody m_rigidbody;
	Transform m_transform;

	GameObject target;

	public int m_heatlh;
	public float m_speed;
	public float m_turnRate;
	public int m_RadarRange;

	void Start()
	{
		m_rigidbody = GetComponent<Rigidbody>();
		m_transform = GetComponent<Transform>();
	}

	void Update()
	{
		if (m_heatlh <= 0)
			Destroy (gameObject);


	}

	void FixedUpdate()
	{
		/*if(target != null && target.tag == "Player") 
		{
			//m_rigidbody.velocity = Vector3(0f, 0f, 0f);
			//m_rigidbody.velocity = m_transform.forward * m_speed;
		} 
		else*/
		{
			m_transform.Rotate(0f, m_turnRate, 0f);
			m_rigidbody.velocity = m_transform.forward * m_speed;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "BaseProjectile") 
		{
			m_heatlh -= other.GetComponent<Projectile>().Damage;
		}
	}
	
	public GameObject Target {
		get {
			return target;
		}
		set {
			target = value;
		}
	}
}
