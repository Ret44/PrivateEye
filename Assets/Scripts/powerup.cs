using UnityEngine;
using System.Collections;

public class powerup : MonoBehaviour {

	//configuration
	private float sensDistance = 200f;


	public Sprite[] powerupSprites;
	public AudioSource pickupSound;


	private bool cheating;
	private SpriteRenderer spr;

	public int baseSprite = 0;


	// Use this for initialization
	void Start () {
		//sbaseSprite = Random.Range(0f, 1f);
		spr = gameObject.GetComponent<SpriteRenderer>();
			if(Random.value > 0.5f)
				baseSprite = 0;
			else
				baseSprite = 2;



		var spawnY = 0f;
		if(Random.value > 0.5f){
			//spawn top
			spawnY = 6.8f;
		}else{
			//spawn bottom
			spawnY = -4.9f;
		}
		transform.position = new Vector3(-2f, spawnY, -1f);
		rigidbody2D.velocity = new Vector2(Random.value*-1f-0.5f, spawnY*-0.2f);
		rigidbody2D.angularVelocity = Random.value*16f-8f;

	}
	
	// Update is called once per frame
	void Update () {
		if(EyeHelperScript.getDistanceFromPosition(transform.position) > sensDistance){
			cheating = true;
		}else{
			cheating = false;
		}	


		if(cheating){
			spr.sprite = powerupSprites[baseSprite+1];
		}else{
			spr.sprite = powerupSprites[baseSprite];

		}
		//Debug.Log (baseSprite);
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.name == "ship"){
			Destroy(this.gameObject);

			if(baseSprite==0){

				if(cheating){
					Gameplay.ChangeScore(-1000);
				}else{
					Gameplay.ChangeScore (1000);
				}
			}else{
				if(cheating){
					Gameplay.ChangeMothership(-5);
				}else{
					Gameplay.ChangeMothership(+5);
				}
			}

		}
	}
}
