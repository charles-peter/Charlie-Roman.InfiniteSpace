using UnityEngine;
using System.Collections;

public class SpaceShip_Controller : MonoBehaviour {


    Rigidbody m_rigidbody;
    public GameObject playerModel;
    Transform m_Transform;
    public float Tilt;
    public float Speed;

   

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

        //Vector3 move = new Vector3(0.0f,0.0f, fVertical);

		m_Transform.Rotate(0f,fHorizontal,0f);
		m_rigidbody.velocity = m_Transform.forward *Speed *fVertical;


		playerModel.transform.localRotation = Quaternion.Euler(0f,0f,fHorizontal * -Tilt);



        


        
	}
}
