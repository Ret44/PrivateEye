using UnityEngine;
using System.Collections;
using TETCSharpClient;
using TETCSharpClient.Data;
using Assets.Scripts;


public class EyeHelperScript : MonoBehaviour, IGazeListener {

	public static bool fakeMouseMode = false;
	public TextMesh PositionText;
	public static EyeHelperScript Instance;
	private Vector3 lastGazeCoord;
	private GazeDataValidator gazeUtils;
	// Use this for initialization
	void Start () {		
		gazeUtils = new GazeDataValidator(30);
		GazeManager.Instance.AddGazeListener (this);
		lastGazeCoord = Vector3.zero;
		EyeHelperScript.Instance = this;
	}


	public void OnGazeUpdate(GazeData gazeData)
	{
		gazeUtils.Update (gazeData);
	}
	// Update is called once per frame
	void Update () {
		Point2D gazeCoords = gazeUtils.GetLastValidSmoothedGazeCoordinates();
		if (gazeCoords != null) {
			Point2D pos = UnityGazeUtils.getGazeCoordsToUnityWindowCoords(gazeCoords);		
			Vector3 screenPoint = new Vector3((float)pos.X, (float)pos.Y, Camera.main.nearClipPlane + .1f);		
			Vector3 planeCoord = Camera.main.ScreenToWorldPoint(screenPoint);
			this.transform.position = planeCoord;
			lastGazeCoord = screenPoint;	
			Debug.Log (lastGazeCoord.ToString());
		}
	}

	public static Vector3 getGazePosition(){
		if(fakeMouseMode){
			var mousePos = Input.mousePosition;
			return new Vector3(mousePos.x, mousePos.y, 0f);
		}else{
			return Instance.lastGazeCoord;
		}
	}

	public static float getDistanceFromPosition(Vector3 position){
		return Vector3.Distance(Camera.main.WorldToScreenPoint(position), getGazePosition());
	}
}
