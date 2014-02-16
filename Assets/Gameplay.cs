using UnityEngine;
using System.Collections;

public class Gameplay : MonoBehaviour {

	public static Gameplay Instance;
	public GameObject RockPrefab;
	public GameObject ExploPrefab;
	public GameObject RockHit;
	public int Mothership;
	public int Hull;
	public int Score;
	public GUIText GUIMothership; 
	public GUIText GUIHull;
	public GUIText GUIScore;
	public bool PlayerAlive;
	public float RockSpawnDelay;

	public AudioSource SoundRockHit;
	public AudioSource SoundBulletShot;
	public AudioSource SoundGotHit;
	public AudioSource SoundDestroyRock;

	// Use this for initialization
	void Start () {
		Gameplay.Instance = this;
		Hull = 30;
		Mothership = 50;
		Score = 0;
		Gameplay.ChangeMothership (50);
		Gameplay.ChangeHull(30);
		PlayerAlive = true;
		RockSpawnDelay = Time.time + 5f;
		Gameplay.ChangeScore (0);
	}

	public static void SpawnRock()
	{	
		GameObject tmpRock = (GameObject)Instantiate (Gameplay.Instance.RockPrefab, 
		             								  new Vector3 (11.5f, UnityEngine.Random.Range (6f, -4f), 0f), 
		                                              Quaternion.Euler (0f, 0f, Random.Range (0, 360))) as GameObject;
		float ScaleRange = UnityEngine.Random.Range (0.0f, 1.0f);
		tmpRock.transform.localScale = new Vector3 (1f + ScaleRange, 1f + ScaleRange, 1f);
		tmpRock.GetComponent<rock> ().hp = (int)(2 + (3f * ScaleRange));
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
		Gameplay.Instance.GUIHull.text = "MOTHERSHIP:";
		for (int i=0; i<Gameplay.Instance.Mothership; i++)
			Gameplay.Instance.GUIHull.text += "|";
		
	}
	// Update is called once per frame
	void Update () {
		if(Time.time > RockSpawnDelay)
		{
			SpawnRock ();
			RockSpawnDelay = Time.time + 5f;
		}

	}
}
