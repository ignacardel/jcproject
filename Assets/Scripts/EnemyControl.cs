using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {

	public GameObject world;
	Vector3 worldCenter; 

	// Use this for initialization
	void Start () {
		worldCenter = world.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.RotateAround(worldCenter, Vector3.down, 1f);
	}
}
