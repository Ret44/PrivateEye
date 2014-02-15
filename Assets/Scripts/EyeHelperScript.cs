using UnityEngine;
using System.Collections;
using TETCSharpClient;
using TETCSharpClient.Data;
using Assets.Scripts;


public class EyeHelperScript : MonoBehaviour, IGazeListener {

	public static bool fakeMouseMode = true;
	public TextMesh PositionText;

	private GazeDataValidator gazeUtils;
	// Use this for initialization
	void Start () {		
		gazeUtils = new GazeDataValidator(30);
		GazeManager.Instance.AddGazeListener (this);
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
		//	planeCoord.z = 0;
			this.transform.position = planeCoord;
			PositionText.text = "("+planeCoord.x+","+planeCoord.y+")";
		}
	}

	public static Vector3 getGazePosition(){
		if(fakeMouseMode){
			var mousePos = Input.mousePosition;
			return new Vector3(mousePos.x, mousePos.y, 0f);
		}else{
			return new Vector3(0f,0f, 0f);
		}
	}

	public static float getDistanceFromPosition(Vector3 position){
		return Vector3.Distance(Camera.main.WorldToScreenPoint(position), getGazePosition());
	}
}
