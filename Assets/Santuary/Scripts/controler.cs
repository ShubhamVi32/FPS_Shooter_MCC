using UnityEngine;
using System.Collections;



public class controler : MonoBehaviour {

	public Transform target;
	public float speed;
	public float runingSpeed;
	float currentSpeed;
	public GameObject GameCamera;
	public Transform objectforward;
	bool isRuning = false;



	void Start () {
		currentSpeed = speed;
		target.position = transform.position;

	}
	


	void Update() {
		float relativePosx = target.position.x - transform.position.x;
		float relativePosz = target.position.z - transform.position.z;


		float x = Input.GetAxisRaw ("Horizontal");
		float z = Input.GetAxisRaw ("Vertical");

	

		if (x >= 1 || x <= -1 || z >= 1 || z <= -1) {

		

			Quaternion rotation = Quaternion.LookRotation (new Vector3 (relativePosx,0f,relativePosz));
		
			transform.rotation = rotation;
		
			
		
		}

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			isRuning = true;


		} 

		if (Input.GetKeyUp (KeyCode.LeftShift)){
			isRuning = false;
		}






	      if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D)) {
			transform.Translate ((Vector3.forward * Time.deltaTime * currentSpeed ));
		}

		if (Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.D)){

			currentSpeed  = 0;
		}

		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.S)){
			
			currentSpeed  = 0;
		}
	







		target.transform.rotation = GameCamera.transform.rotation;
		target.transform.eulerAngles = new Vector3 (0,target.transform.eulerAngles.y,0);


		if (Input.GetKey (KeyCode.W)&& !Input.GetKey (KeyCode.S)){

			if (isRuning == false){
				currentSpeed  = speed;
			}
			else {
				currentSpeed = runingSpeed;
			}

			target.Translate (Vector3.forward * Time.deltaTime * currentSpeed*4 );
			}


		if (Input.GetKey (KeyCode.D) && !Input.GetKey (KeyCode.A)) {

			if (isRuning == false){
				currentSpeed  = speed;
			}
			else {
				currentSpeed = runingSpeed;
			}
			target.Translate (Vector3.right * Time.deltaTime * currentSpeed*4 );

		}


		if (Input.GetKey (KeyCode.S) && !Input.GetKey (KeyCode.W)) {

			if (isRuning == false){
				currentSpeed  = speed;
			}
			else {
				currentSpeed = runingSpeed;
			}
			target.Translate (Vector3.back * Time.deltaTime * currentSpeed*4 );
			}


		

		if (Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D)) {

			if (isRuning == false){
				currentSpeed  = speed;
			}
			else {
				currentSpeed = runingSpeed;
			}
			target.Translate (Vector3.left * Time.deltaTime * currentSpeed*4 );
		}

		

		if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D)) {
			target.transform.position = objectforward.transform.position;
		
			if (isRuning == false){
				currentSpeed  = speed;
			}
			else {
				currentSpeed = runingSpeed;
			}

		}
	






	


	
	}

	

	}



