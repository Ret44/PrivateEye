using UnityEngine;
using System.Collections;

public class Gameplay : MonoBehaviour {

	public static Gameplay Instance;
	public GameObject RockPrefab;
	public GameObject PowerUpPrefab;
	public GameObject ExploPrefab;
	public GameObject RockHit;
	public GameObject ShipExplo;
	public GameObject MothershipExplo;
	public int Mothership;
	public int Hull;
	public int Score;
	public GUIText GUIMothership; 
	public GUIText GUIHull;
	public GUIText GUIScore;
	public bool PlayerAlive;
	public float RockSpawnDelay;
	public float PowerupSpawnDelay;

	private float SpawnInterval = 1.9f;
	private float PowerupSpawnInterval = 7f;

	public AudioSource SoundRockHit;
	public AudioSource SoundBulletShot;
	public AudioSource SoundGotHit;
	public AudioSource SoundDestroyRock;

	// Use this for initialization
	void Start () {
		Gameplay.Instance = this;
		Hull = 30;
		Mothership = 0;
		Score = 0;
		Gameplay.ChangeMothership (30);
		Gameplay.ChangeHull(30);
		PlayerAlive = true;
		RockSpawnDelay = Time.time + SpawnInterval;
		PowerupSpawnDelay = Time.time + PowerupSpawnInterval;
		Gameplay.ChangeScore (0);
	}

	public static void SpawnRock()
	{	
		GameObject tmpRock = (GameObject)Instantiate (Gameplay.Instance.RockPrefab, 
		             								  new Vector3 (11.5f, UnityEngine.Random.Range (6f, -4f), 0f),
		                                              Quaternion.identity) as GameObject;
		                                              //Quaternion.Euler (0f, 0f, Random.Range (0, 360))) as GameObject;
		float ScaleRange = UnityEngine.Random.Range (0.0f, 1.0f);
		tmpRock.transform.localScale = new Vector3 (0.5f + ScaleRange, 0.5f + ScaleRange, 1f);
		tmpRock.GetComponent<rock> ().hp = (int)(1 + (2f * ScaleRange));

		var forceField = GameObject.Instantiate(Resources.Load("forcefield") ) as GameObject;
		forceField.transform.localScale = tmpRock.transform.localScale;
		tmpRock.GetComponent<rock>().cheatForceField = forceField;
	}

	public static void SpawnPowerup()
	{
		Instantiate (Gameplay.Instance.PowerUpPrefab);
	}
	public static void ChangeScore(int val)
	{
		Gameplay.Instance.Score += val;
		Gameplay.Instance.GUIScore.text = "SCORE:" + Gameplay.Instance.Score;
	}

	public static void ChangeHull(int val)
	{
		Gameplay.Instance.Hull += val;
		Gameplay.Instance.GUIHull.text = "HULL:";
		for (int i=0; i<Gameplay.Instance.Hull; i++)
			Gameplay.Instance.GUIHull.text += "|";

	}

	public static void ChangeMothership(int val)
	{
		Gameplay.Instance.Mothership += val;
		Gameplay.Instance.GUIMothership.text = "MOTHERSHIP:";
		for (int i=0; i<Gameplay.Instance.Mothership; i++)
			Gameplay.Instance.GUIMothership.text += "|";
		if (Gameplay.Instance.Mothership <= 0) {
				GameObject ship = GameObject.Find ("ship");
				Instantiate(Gameplay.Instance.ShipExplo,ship.transform.position,Quaternion.identity);
				Destroy (ship);
				Gameplay.Instance.SoundGotHit.Play ();
				Instantiate (Gameplay.Instance.MothershipExplo,new Vector3(-13f,0f,0f),Quaternion.identity);
			Gameplay.GameOverScreenShow();
				}
	}

	public static void GameOverScreenShow()
	{
		GameObject.Find ("GUI-GameOver").GetComponent<GUIText>().text = "GAME OVER";
		GameObject.Find ("GUI-GameOverScore").GetComponent<GUIText>().text = "Score : "+Gameplay.Instance.Score;
		GameObject.Find ("GUI-Score").GetComponent<GUIText>().text ="";
		GameObject.Find ("GUI-MadeBy").GetComponent<GUIText>().text ="Made by ExclamationMark & Ret // Music by Doktor Satan // #NGJ2014";
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R))
						Application.LoadLevel (1);
		if (Input.GetKeyDown (KeyCode.P)) {
			EyeHelperScript.fakeMouseMode = !EyeHelperScript.fakeMouseMode;
			if(EyeHelperScript.fakeMouseMode)
				GameObject.Find ("GUI-MouseFaking").GetComponent<GUIText>().text = "EYETRACKING MOUSE SIM ENABLED";
			else
				GameObject.Find ("GUI-MouseFaking").GetComponent<GUIText>().text = "";
				}
		if(Time.time > RockSpawnDelay)
		{
			SpawnRock ();
			RockSpawnDelay = Time.time + SpawnInterval;
		}
		if (Time.time > PowerupSpawnDelay)
		{
			SpawnPowerup ();
			PowerupSpawnDelay = Time.time + PowerupSpawnInterval;
		}

	}
}
