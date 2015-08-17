using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	public float speed;

	void Start()
	{
		GetComponents.rigidbody.velocity = transform.forwad * speed
	}
}
