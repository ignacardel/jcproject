using UnityEngine;
using System.Collections;

public class GroundMovementControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0f, 0f, -5f * Time.deltaTime);
	}
}
