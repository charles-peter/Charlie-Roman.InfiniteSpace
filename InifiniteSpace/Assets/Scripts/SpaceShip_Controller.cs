using UnityEngine;
using System.Collections;

public class SpaceShip_Controller : MonoBehaviour {


    Rigidbody m_rigidbody;
    GameObject playerModel;
    Transform m_Transform;
    public float Tilt;
    public float Speed;

	//All the Variables needed for firing projectiles. 
	public GameObject projectile;
	public Transform projSpawn;
	public float fireRate;
	float nextFire = 0.0f;

	// Use this for initialization
	void Start () 
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_Transform = GetComponent<Transform>();
	}


	void Update()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(projectile, projSpawn.position, projSpawn.rotation);
		}
	}

	// Update is called once per frame
	void FixedUpdate () 
    {
        float fVertical = Input.GetAxis("Vertical");
        float fHorizontal = Input.GetAxis("Horizontal");

        Vector3 move = new Vector3(0.0f,0.0f, fVertical);

        m_rigidbody.velocity = m_Transform.forward *Speed *fVertical;
        m_Transform.Rotate(0.0f, fHorizontal * Tilt, 0.0f);
	}
}
