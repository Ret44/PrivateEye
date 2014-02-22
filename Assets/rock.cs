using UnityEngine;
using System.Collections;

public class rock : MonoBehaviour {
	
	//config
	private float sensDistance = 220f;
	private float minSpeed = 2.2f;
	private float maxSpeed = 2.8f;
	
	//references
	private SpriteRenderer rockSprite;
	public GameObject cheatForceField;
	
	//real variables
	private float speed; 
	public int hp;
	public bool cheating;
	
	// Use this for initialization
	void Start () {
		hp = Random.Range((int)4, (int)7);
		rockSprite = gameObject.GetComponent<SpriteRenderer>();

		speed = Random.Range(minSpeed, maxSpeed);
	}
	
	// Update is called once per frame
	void Update () {

				transform.position += new Vector3 (-speed, 0f, 0f) * Time.deltaTime;
				if (transform.position.x < -10f) {
						float Modifier = this.transform.localScale.x - 1.0f;
						Gameplay.Instance.SoundDestroyRock.pitch = (1 - Modifier) + 0.7f;
						Gameplay.Instance.SoundDestroyRock.Play ();
						Instantiate (Gameplay.Instance.ExploPrefab, this.transform.position, Quaternion.identity);
						Destroy (this.gameObject);
						Gameplay.ChangeMothership (-2);
				}
				if (EyeHelperScript.getDistanceFromPosition (transform.position) > sensDistance) {
						cheating = true;
				} else {
						cheating = false;
				}

				float changer = 1f * (EyeHelperScript.getDistanceFromPosition (transform.position) / 800);

				rockSprite.color = new Color (1f, 1f - (1f * changer), 1f - (1f * changer));
				if (cheating) {

						cheatForceField.SetActive (true);

				} else {

//rockSprite.color = Color.white;
						cheatForceField.SetActive (false);
				}

				cheatForceField.transform.position = transform.position;

	}


	//=====================
	//TE TRZY POD KONIEC SPAWNROCK() W GAMEPLAY.CS

	
	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "blast"){
			Destroy(col.gameObject);
			hp--;
			Instantiate(Gameplay.Instance.RockHit,this.transform.position,Quaternion.identity);
			if(hp==0){
				float Modifier = this.transform.localScale.x - 1.0f;
				Gameplay.Instance.SoundDestroyRock.pitch = (1-Modifier) + 0.7f;
				Gameplay.Instance.SoundDestroyRock.Play ();
				Gameplay.ChangeScore((int)(50 * (Modifier+0.1f)));
				Instantiate(Gameplay.Instance.ExploPrefab,this.transform.position,Quaternion.identity);
				Destroy(this.gameObject);
			}
		}
	}
}
