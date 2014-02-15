using UnityEngine;
using System.Collections;

public class rock : MonoBehaviour {

	//config
	private float sensDistance = 100f;
	private float minSpeed = 2.6f;
	private float maxSpeed = 3.2f;
		
	//references
	private SpriteRenderer rockSprite;

	//real variables
	private float speed; 
	private int hp;

	// Use this for initialization
	void Start () {
		hp = Random.Range((int)2, (int)4);
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


	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "blast"){
			Destroy(col.gameObject);
			hp--;
			Debug.Log("ała kurwa");
			if(hp==0){
				Destroy(this.gameObject);
			}
		}
	}
}
