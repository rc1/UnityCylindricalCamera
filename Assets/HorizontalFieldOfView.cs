using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class HorizontalFieldOfView : MonoBehaviour {

	[Range(0,180)]
	public float horitzonalFieldOfView = 90;
	private Camera _camera;

	void Start () {
		_camera = GetComponent<Camera> ();
	}
		
	void Update() {
		float horitzonalFieldOfViewRad = Mathf.Deg2Rad * horitzonalFieldOfView;
		float cameraHorizontal = Mathf.Tan ( horitzonalFieldOfViewRad * 0.5f ) / _camera.aspect;
		float verticalFieldOfView = Mathf.Atan ( cameraHorizontal ) * 2.0f;
		_camera.fieldOfView = verticalFieldOfView * Mathf.Rad2Deg;
	}
}
