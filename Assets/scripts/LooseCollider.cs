using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseCollider : MonoBehaviour {
private LevelManager levelmanager;
void Start()
{
		
}

void OnCollisionEnter2D(Collision2D collision )
{
		
		
}
	void OnTriggerEnter2D(Collider2D trigger)
	{levelmanager = GameObject.FindObjectOfType<LevelManager> ();
		levelmanager.LoadLevel ("lose");
}

}
