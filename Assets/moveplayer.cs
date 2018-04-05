using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveplayer : MonoBehaviour {

	public KeyCode moveL;
	public KeyCode moveR;
	public float horizVel = 0;
	public ParticleSystem explo;
	AudioSource au;
	private Rigidbody player;
	void Start () {
		au = GetComponent<AudioSource> ();
		player = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		player.velocity = new Vector3 (horizVel * Time.deltaTime * (cameramove.speed*5), 0, cameramove.speed);
		if (Input.GetKey (moveL)) {
			horizVel = -2;
		} else if (Input.GetKey (moveR)) {
			horizVel = 2;
		} else {
			horizVel = 0;
		}
		Vector3 clamped_x = transform.position;
		clamped_x.x = Mathf.Clamp (transform.position.x, 0.5f, 4.1f);
		transform.position = clamped_x;
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "point") {
			pathgen.score += 1;
			pathgen.au.Play ();
			Destroy (col.gameObject);
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "kill") {
			cameramove.speed = 0;
			explo.Play ();
			if (!au.isPlaying) {
				au.Play ();
			}
			cameramove.dead = true;
			Destroy (col.gameObject, .5f);
			Destroy (gameObject, .5f);
		}
	}


}
