using UnityEngine;
using System.Collections;

public class Enemy_Controller : MonoBehaviour, IDamageable<int> 
{
	//interface Methods
	public void TakeDamage(int dam)
	{
		m_heatlh -=dam;
	}



	Rigidbody m_rigidbody;
	Transform m_transform;

	GameObject target;

	//General Enemy Attributes
	public int m_heatlh;
	public float m_speed;
	public float m_turnRate;
	public bool m_BaseBehavior;

	//Ai Behavior stuff.
	Vector3 m_ToTarget;

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
		if (m_BaseBehavior == true) 
		{
			if (target != null && target.tag == "Player") 
			{
				m_ToTarget = target.GetComponent<SpaceShip_Controller>().transform.position - m_transform.position;
				// The step size is equal to speed times frame time.
				var step = m_turnRate * Time.deltaTime;
				var newDir = Vector3.RotateTowards(m_transform.forward, m_ToTarget, step, 0.0f);
				//Debug.DrawRay(transform.position, newDir, Color.red);
				// Move our position a step closer to the target.
				m_transform.rotation = Quaternion.LookRotation(newDir);
				
				m_rigidbody.velocity = m_transform.forward * m_speed;
			} 
			else 
			{
				//If there is no target it does a base patrol;
				m_transform.Rotate (0f, m_turnRate, 0f);
				m_rigidbody.velocity = m_transform.forward * m_speed;
			}
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "BaseProjectile") 
		{
			 TakeDamage(other.GetComponent<Projectile>().Damage);
		}
			
//		else if (other.tag == "Player") 
//		{
//			Destroy(gameObject);
//		}
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
