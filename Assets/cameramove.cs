using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameramove : MonoBehaviour {

	public static int speed = 4;
	public static float z_camera;
	public static bool dead = false;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, speed);
		cameramove.z_camera = transform.position.z;
		if (dead) {
			dead = false;
			StartCoroutine (death ());
		}
	}

	IEnumerator death(){
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene (2);
		speed = 4;
	}
}
