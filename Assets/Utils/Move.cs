using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		position.y = Mathf.Sin (Time.time*3) * 200.0f;
		transform.position = position;
		transform.Rotate (0, 10 * Time.deltaTime, 0);
	}
}
