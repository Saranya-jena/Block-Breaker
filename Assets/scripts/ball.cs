using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ball : MonoBehaviour {
    private paddle Paddle;
  
    private Vector3 paddleToballVector;
    private bool hasStarted=false;
	// Use this for initialization
	void Start () {
		
		Paddle = GameObject.FindObjectOfType<paddle> ();
		paddleToballVector = this.transform.position- Paddle.transform.position;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!hasStarted) {
			this.transform.position = Paddle.transform.position + paddleToballVector;//lock the ball relative to the paddle
			if (Input.GetMouseButtonDown (0)) {//wait for mouse launch

				hasStarted = true;
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (2f, 10f);
			}
		}
	}
	void OnCollisionEnter2D(Collision2D col)
	{AudioSource audio = GetComponent<AudioSource> ();
		Vector2 tweak = new Vector2 (Random.Range (0f, 2f), Random.Range (0f, 2f));
		if(hasStarted)
		{
		audio.Play ();
		GetComponent<Rigidbody2D>().velocity +=tweak;

		}
	}
}
