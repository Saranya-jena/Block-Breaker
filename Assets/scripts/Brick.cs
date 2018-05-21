using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
public static int breakableCount=0;
private	bool isbreakable;
private int timesHit;
private LevelManager levelmanager;
public Sprite[] hitSprite;

public GameObject smoke;
	public AudioClip crack;
	// Use this for initialization
	void Start () {
		isbreakable = (this.tag=="breakable");//keep track of breakable bricks
        



        if (this.gameObject.CompareTag("breakable"))

        {
			breakableCount++;
		}

		timesHit = 0;
		levelmanager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D col)
	{AudioSource.PlayClipAtPoint (crack, transform.position, 2.0f);
	if(isbreakable){
			HandleHits ();
	}
	}


	void HandleHits ()
	{
		int maxHit; 
		maxHit = hitSprite.Length + 1;
		timesHit++;
		if (timesHit >= maxHit) {
			breakableCount--;
			levelmanager.BrickDestroyed ();
            GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
            ParticleSystem ps = smokePuff.GetComponent<ParticleSystem>();
            ParticleSystem.MainModule psmain = ps.main;
            psmain.startColor = gameObject.GetComponent<SpriteRenderer>().color;


            //Assign that material to the particle renderer
            ps.GetComponent<Renderer>().material = createParticleMaterial();
            Destroy (gameObject);
		}
		else{
			LoadSprites ();
		}
	}
    Material createParticleMaterial()
    {
        //Create Particle Shader
        Shader particleShder = Shader.Find("Particles/Alpha Blended Premultiply");

        //Create new Particle Material
        Material particleMat = new Material(particleShder);

        Texture particleTexture = null;

        //Find the default "Default-Particle" Texture
        foreach (Texture pText in Resources.FindObjectsOfTypeAll<Texture>())
            if (pText.name == "Default-Particle")
                particleTexture = pText;

        //Add the particle "Default-Particle" Texture to the material
        particleMat.mainTexture = particleTexture;

        return particleMat;
    }

        void LoadSprites()
	{
		int spriteIndex = timesHit - 1;
		if (hitSprite [spriteIndex] != null)
			this.GetComponent<SpriteRenderer> ().sprite = hitSprite [spriteIndex];
		else
			Debug.LogError ("brick missing");
	}
	//TODO remove this function once we can actually win
	void SimulateWin()
	{
		levelmanager.LoadNextLevel ();

	}
}
