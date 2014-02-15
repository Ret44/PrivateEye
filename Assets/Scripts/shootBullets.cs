using UnityEngine;
using System.Collections;

public class shootBullets : MonoBehaviour {

	//lazy loading
	public GameObject blastPrefab;

	//movement config
	private float vx = 0f;
	private float vy = 0f;
	private float acc = 1.3f;
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

		transform.position += new Vector3(vx, vy, 0f);

		if(Input.GetKey(KeyCode.Space)){
			if(Time.time > lastShotTime + shootDelay){
				shoot ();
			}
		}

	}


	void shoot(){
		//Instantiate(blastPrefab, transform.position, Quaternion.identity);
	}
}
