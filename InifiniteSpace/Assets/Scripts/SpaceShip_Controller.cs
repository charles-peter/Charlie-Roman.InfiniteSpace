using UnityEngine;
using System.Collections;

public class SpaceShip_Controller : MonoBehaviour {


    Rigidbody m_rigidbody;
    GameObject playerModel;
    Transform m_Transform;
    public float Tilt;
    public float Speed;
	// Use this for initialization
	void Start () 
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_Transform = GetComponent<Transform>();
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
