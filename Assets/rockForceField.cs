using UnityEngine;
using System.Collections;

public class rockForceField : MonoBehaviour {


	//config
	private float pushingAwayForce = 5.5f; //NOT A FORCE. LOL
	private float pushingBackForce = -1.3f; //ALSO NOT A FORCE. LOL

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "blast"){

			var deltaY = (this.transform.position - col.transform.position).y;
			if(deltaY > 0f){
				col.transform.position += new Vector3(pushingBackForce, -pushingAwayForce, 0f) * Time.deltaTime;
			}else{
				col.transform.position += new Vector3(pushingBackForce, pushingAwayForce, 0f) * Time.deltaTime;
			}


		}
	}
}
