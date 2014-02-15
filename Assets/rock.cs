using UnityEngine;
using System.Collections;

public class rock : MonoBehaviour {

	//config
	private float sensDistance = 100f;

	//references
	private SpriteRenderer rockSprite;

	// Use this for initialization
	void Start () {
		rockSprite = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

		if(EyeHelperScript.getDistanceFromPosition(transform.position) < sensDistance){
			rockSprite.color = Color.red;
		}else{
			rockSprite.color = Color.white;
		}
	
	}
}
