using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	Animator anim;

	void Awake () {
		anim = GetComponent <Animator> ();
	}
	

	void FixedUpdate () {
	
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		Animating (h,v);

		if (Input.GetKey (KeyCode.LeftShift)) {
			bool running = h != 0f || v !=0f;
			anim.SetBool ("IsRunning", running);
			anim.SetBool ("IsWalking",false);
		} else {
			anim.SetBool ("IsRunning", false);
		}


	}

	void Animating (float h, float v){

		bool walking = h != 0f || v !=0f;
		anim.SetBool ("IsWalking", walking);
	}
}
