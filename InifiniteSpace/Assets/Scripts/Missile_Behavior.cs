using UnityEngine;
using System.Collections;

public class Missile_Behavior : MonoBehaviour {


	public float Speed = 100f;
	public float TrackAngle = 5f;
	public float SplashRadius = 5f;
	public float Damage = 300f;
	public float maxLifetime = 5f;
	float currLife;
	bool inFlight = false;


	Rigidbody m_RigidBody;
	Transform m_Transform;

	public bool InFlight {
		get {
			return inFlight;
		}
		set {
			inFlight = value;
			if(value)
			{
				m_RigidBody.isKinematic = false;
				m_Transform.parent = null;
				Destroy (gameObject, maxLifetime);
			}
		}
	}

	private GameObject target = null;



	public GameObject Target {
		get {
			return target;
		}
		set {
			target = value;
		}
	}



	void Start () 
	{
		m_RigidBody = GetComponent<Rigidbody>();
		m_RigidBody.isKinematic = true;
		m_Transform = GetComponent<Transform>();

	}

	void Update()
	{


	}

	void FixedUpdate () 
	{
		if(inFlight && target == null)
		{
			m_RigidBody.velocity = m_Transform.forward * Speed;
			m_RigidBody.AddForce(m_Transform.forward * Speed,ForceMode.Acceleration);
		}
		else if(inFlight && target)
		{
			m_Transform.rotation = Quaternion.Slerp(m_Transform.rotation, Quaternion.LookRotation(target.transform.position- m_Transform.position),TrackAngle * Time.deltaTime);
			m_RigidBody.velocity = m_Transform.forward * Speed;
			m_RigidBody.AddForce(m_Transform.forward * Speed,ForceMode.Acceleration);
		}
	}
}
