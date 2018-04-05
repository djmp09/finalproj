using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class over : MonoBehaviour {

	public Text score;
	// Use this for initialization
	void Start () {
		score.text = "Your Score is " + pathgen.score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown){
			pathgen.score = 0;
			SceneManager.LoadScene (0);
		}

	}
}
