using UnityEngine;
using System.Collections;

public class rock : MonoBehaviour {

	//config
	private float sensDistance = 100f;
	private float minSpeed = 1.5f;
	private float maxSpeed = 2f;
	


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
