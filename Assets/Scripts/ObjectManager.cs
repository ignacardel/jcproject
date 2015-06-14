using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {

	public Boundary itemsBoundary;
	public Boundary sceneryBoundary;
	public GameObject world;
	public float radius;
	public float bornAngle;
	public float killAngle;
	public float sceneryAngle;
	public GameObject testCube;

	private GameObject[] sceneryItems;
	private GameObject cube;
	private GameObject cube2;
	private GameObject cube3;


	// Use this for initialization
	void Start () {
		//cube = Instantiate (testCube);
		//positionItem (cube.transform);

		sceneryItems = new GameObject[5];
		// populate planet
		for (var i=0; i<5; i++){
			// create a random item
			GameObject item = Instantiate(testCube);
			positionItem (item.transform);
			sceneryItems[i] = item;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (var i = 0; i < 5; i++){
			if (Vector3.Angle(sceneryItems[i].transform.up, Vector3.up) > killAngle){
				positionItem(sceneryItems[i].transform);
			}
		}
		/*if (Vector3.Angle(cube.transform.up, Vector3.up) > killAngle){
			positionItem (cube.transform);
		}*/
	}

	void positionItem(Transform item){
		//float angleY = Random.Range(itemsBoundary.xMin , itemsBoundary.xMax);
		float angleY;
		var dir = Quaternion.Euler(-bornAngle, 0, 0) * Vector3.forward;
		if (Random.value < 0.5){ // randomly select left or right sides
			angleY = Random.Range(-sceneryBoundary.xMax, -sceneryBoundary.xMin);
		} else {
			angleY = Random.Range(sceneryBoundary.xMin, sceneryBoundary.xMax);
		}
		dir = Quaternion.Euler(0,angleY, 0) * dir;
		// set item position and rotation
		item.position = world.transform.position + radius * dir;
		item.rotation = Quaternion.FromToRotation(Vector3.up, dir);
		item.transform.SetParent(world.transform);
	}
}
