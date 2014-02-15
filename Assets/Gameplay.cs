using UnityEngine;
using System.Collections;

public class Gameplay : MonoBehaviour {

	public static Gameplay Instance;
	public GameObject RockPrefab;
	public int Hull;
	public int Score;
	public GUIText GUIHull;
	public GUIText GUIScore;
	public bool PlayerAlive;
	public float RockSpawnDelay;

	// Use this for initialization
	void Start () {
		Gameplay.Instance = this;
		Hull = 50;
		Score = 0;
		Gameplay.ChangeHull(50);
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
	// Update is called once per frame
	void Update () {
		if(Time.time > RockSpawnDelay)
		{
			SpawnRock ();
			RockSpawnDelay = Time.time + 5f;
		}

	}
}
