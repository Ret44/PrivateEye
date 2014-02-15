using UnityEngine;
using System.Collections;

public class rock : MonoBehaviour {

	//config
<<<<<<< HEAD
	private float sensDistance = 100f;
	private float minSpeed = 0.7f;
	private float maxSpeed - 0.9f;
	
=======
	private float sensDistance = 200f;

>>>>>>> 3605bb1bde3bd2d4629b2997d5f93b80c4d6ddc7
	//references
	private SpriteRenderer rockSprite;

	//real variables
	private float speed; 

	// Use this for initialization
	void Start () {
		rockSprite = gameObject.GetComponent<SpriteRenderer>();
		speed = Random.Range(minSpeed, maxSpeed);
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += new Vector3 (-speed, 0f, 0f) * Time.deltaTime;

		if(EyeHelperScript.getDistanceFromPosition(transform.position) < sensDistance){
			rockSprite.color = Color.red;
		}else{
			rockSprite.color = Color.white;
		}
	
	}
}
