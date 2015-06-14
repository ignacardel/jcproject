using UnityEngine;
using System.Collections;

public class WorldRotation : MonoBehaviour {

    //Velocidad de rotación de la esfera
	public float rotationSpeed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;
		transform.Rotate (Vector3.down * rotationSpeed * dt);
	}
	
    public void SetRotationSpeed(float speed) {
		rotationSpeed = speed;
	}
}
