using UnityEngine;
using System.Collections;

public class SpaceShip_Controller : MonoBehaviour {


    Rigidbody m_rigidbody;

	// Use this for initialization
	void Start () 
    {
        m_rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        float fVertical = Input.GetAxis("Vertical");
        float fHorizontal = Input.GetAxis("Horizontal");

        Vector3 move = new Vector3(fHorizontal,0.0f, fVertical);

        m_rigidbody.velocity = move*25;
	}
}
