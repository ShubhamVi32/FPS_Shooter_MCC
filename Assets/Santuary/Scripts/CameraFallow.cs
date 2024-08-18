using UnityEngine;
using System.Collections;

public class CameraFallow : MonoBehaviour {

	public GameObject character;
	public Transform target;
	Vector3 characterPosition;
	public float cameraHeight;
	public float cameraEngle;

	void Start () {
	

	}
	

	void Update () {
	
		characterPosition = new Vector3 (character.transform.position.x + cameraEngle,cameraHeight,character.transform.position.z - cameraEngle);
		transform.position = characterPosition;
		transform.LookAt (target);
}
}