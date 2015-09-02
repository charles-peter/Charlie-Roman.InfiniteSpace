using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceShip_Controller : MonoBehaviour, IDamageable<int> {

	//interface methods
	public void TakeDamage(int dam)
	{
		Health-=dam;
	}



	public int Health = 300;
    Rigidbody m_rigidbody;
    public GameObject playerModel;
    Transform m_Transform;
    public float Tilt;
    public float Speed;

	public GameObject m_Target; 

	Missile_HardPoint [] missiles; // holds the two spawn points for the missiles
	Laser_Hardpoint [] lasers;	   // holds all the laser spawn points - array in case we want multiple lasers
	public GameObject m_Missile;  // holds the prefab for missile
	public GameObject getMissilePrefab()
	{
		return m_Missile; // Accessor for the missile prefab, in case we wanna have different kinds of missiles;
	}

	//All the Variables needed for firing projectiles. 
	public GameObject Laser;
	public GameObject getLaserPrefab()
	{
		return Laser;  //  Accessor for the laser prefab, in case we wanna have different kinds of lasers;
	}



	// Use this for initialization
	void Start () 
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_Transform = GetComponent<Transform>();
		missiles = GetComponentsInChildren<Missile_HardPoint>();
		lasers = GetComponentsInChildren<Laser_Hardpoint>();
	}

	int nextmissile = 0;
	void Update()
	{
		if (Input.GetButton ("Fire1") ) 
		{
			lasers[0].Fire ();

		}


		if (Input.GetButtonDown ("Fire2") ) 
		{
			// Fire Missile

			bool b = missiles[nextmissile].Fire(m_Target);
			if(b)
			nextmissile = nextmissile^1;
			//Debug.Log(nextmissile);
		}
	}

	// Update is called once per frame
	void FixedUpdate () 
    {
        float fVertical = Input.GetAxis("Vertical");
        float fHorizontal = Input.GetAxis("Horizontal");

        //Vector3 move = new Vector3(0.0f,0.0f, fVertical);

		m_Transform.Rotate(0f,fHorizontal,0f);
		m_rigidbody.velocity = m_Transform.forward *Speed *fVertical;



			if(fVertical >= 0f)
				playerModel.transform.localRotation = Quaternion.Euler(0f,0f,fHorizontal * -Tilt);
			else
				playerModel.transform.localRotation = Quaternion.Euler(0f,0f,-fHorizontal * -Tilt);



        


        
	}
}
