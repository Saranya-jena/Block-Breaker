using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour {
 public bool autoplay=false;
 private ball Ball;
 void Start()
 {
		Ball = GameObject.FindObjectOfType<ball> ();
 }
	
	void Update () {
		if (autoplay == false) {
			moveWidMouse ();
		} else
			AutoPlay ();
	}

	void AutoPlay()
	{Vector3 paddlepos = new Vector3 (0.0f, this.transform.position.y,-5.0f);
		
		Vector3 ballpos = Ball.transform.position;
		paddlepos.x =  Mathf.Clamp(ballpos.x,-6.5f,6.5f);
		this.transform.position = paddlepos;

	}



	void moveWidMouse()
	{
		Vector3 paddlepos = new Vector3 (0.0f, this.transform.position.y,-5.0f);
		float pos=Input.mousePosition.x / Screen.width *16;

		paddlepos.x =  Mathf.Clamp(pos-8.0f,-6.5f,6.5f);
		this.transform.position = paddlepos;
	}
}
