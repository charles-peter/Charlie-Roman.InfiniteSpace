using UnityEngine;
using System.Collections;

public class HUD_Controller : MonoBehaviour 
{
	SpaceShip_Controller m_Player;
	float m_StartHealth;

	public RectTransform m_HealthBar;
	

	// Use this for initialization
	void Start () 
	{
		m_Player = FindObjectOfType<SpaceShip_Controller>();
		m_StartHealth = m_Player.Health;
	}
	
	// Update is called once per frame
	void Update () 
	{


	}
}
