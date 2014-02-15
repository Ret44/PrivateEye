using UnityEngine;
using System.Collections;

public class shootBullets : MonoBehaviour {

	//lazy loading
	public GameObject blastPrefab;

	//movement config
	private float vx = 0f;
	private float vy = 0f;
	private float acc = 1.9f;
	private float damp = 0.76f;
	private float shootDelay = 0.4f;
	
	//frame config
//	private float boxTop = 5f;
//	private float boxRight = 11f;
//	private float boxDown = -5f;
//	private float boxLeft = -11f;



	//actually stuff
	float lastShotTime = 0f;


	void Start () {
	
	}
	

	void Update () {
		vx += Input.GetAxis("Horizontal") * acc * Time.deltaTime;
		vx *= damp;

		vy += Input.GetAxis("Vertical") * acc * Time.deltaTime;
		vy *= damp;

		Vector3 newPos = transform.position + new Vector3(vx, vy, 0f);
		if (newPos.x > -9.75f && newPos.x < 9.5f && newPos.y > -4.5f && newPos.y < 6.4f)
						transform.position = newPos;

		if(Input.GetKey(KeyCode.Space)){
			if(Time.time > lastShotTime + shootDelay){
				shoot ();
				lastShotTime = Time.time;
			}
		}

	}


	void shoot(){
		var blast = Instantiate(blastPrefab, transform.position, Quaternion.identity) as GameObject;
		blast.rigidbody2D.velocity = new Vector2(9f, 0f);
	}
}
