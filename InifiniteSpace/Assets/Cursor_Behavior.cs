using UnityEngine;
using System.Collections;

public class Cursor_Behavior : MonoBehaviour {


    public Camera maincam;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
      		transform.position = Input.mousePosition;
	}
}
