using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]

public class CameraFulstrumGizmo : MonoBehaviour {

	public virtual void OnDrawGizmos() {
		Matrix4x4 temp = Gizmos.matrix;
		Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
		Gizmos.color = new Color (1.0f, 1.0f, 0.0f, 0.1f);
		if (GetComponent<Camera>().orthographic) {
			float spread = GetComponent<Camera>().farClipPlane - GetComponent<Camera>().nearClipPlane;
			float center = (GetComponent<Camera>().farClipPlane + GetComponent<Camera>().nearClipPlane)*0.5f;
			Gizmos.DrawWireCube(new Vector3(0,0,center), new Vector3(GetComponent<Camera>().orthographicSize*2*GetComponent<Camera>().aspect, GetComponent<Camera>().orthographicSize*2, spread));
		} else {
			Gizmos.DrawFrustum(Vector3.zero, GetComponent<Camera>().fieldOfView, GetComponent<Camera>().farClipPlane, GetComponent<Camera>().nearClipPlane, GetComponent<Camera>().aspect);
		}
		Gizmos.matrix = temp;
	}

}
