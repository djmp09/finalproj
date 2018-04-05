using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pathgen : MonoBehaviour {
	public Transform[] types;
	public Transform coin;
	public Text scoreTxt;

	public Transform[] obs;
	public static int score = 0;
	int i;
	int z_tracker = 0;
	int count = 0;
	int ran = 0;
	int ran2 = 0;
	int ran3 = 0;
	bool spawn = true;
	public static AudioSource au;

	void Start () {

		au = GetComponent<AudioSource> ();
		for (int x = 0, z = 0; x < 50; x++, z+=2) {
			i = Random.Range (0, 10);
			ran = Random.Range (1, 5);
			Instantiate (types [i], new Vector3 (types [i].position.x, types [i].position.y, z), types [i].rotation);
			z_tracker = z;

			if (x%4 == 0) {
				ran = Random.Range (0, 11);
				ran2 = Random.Range (1, 5);
				ran3 = Random.Range (1, 5);
				while (ran2 == ran3) {
					ran3 = Random.Range (1, 5);
				}
				if (ran >= 6 && ran <= 11) {
					Instantiate (obs [ran], new Vector3 (ran2, 0.11f, z+10), obs [ran].rotation);
					Instantiate (coin, new Vector3 (ran3, 0.7f, z+10), coin.rotation);
				} else {
					Instantiate (obs [ran], new Vector3 (ran2, 0.68f, z+10), obs [ran].rotation);
					Instantiate (coin, new Vector3 (ran3, 0.7f, z+10), coin.rotation);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(cameramove.z_camera > (z_tracker-50)){
			for (int x = 0, z = z_tracker; x < 50; x++, z+=2) {
				i = Random.Range (0, 10);
				ran = Random.Range (1, 4);
				Instantiate (types [i], new Vector3 (types [i].position.x, types [i].position.y, z), types [i].rotation);
				z_tracker = z;

				if (x%4 == 0) {
					ran = Random.Range (0, 11);
					ran2 = Random.Range (1, 5);
					ran3 = Random.Range (1, 5);
					while (ran2 == ran3) {
						ran3 = Random.Range (1, 5);
					}
					if (ran >= 6 && ran <= 11) {
						Instantiate (obs [ran], new Vector3 (ran2, 0.11f, z+10), obs [ran].rotation);
						Instantiate (coin, new Vector3 (ran3, 0.7f, z+10), coin.rotation);
					} else {
						Instantiate (obs [ran], new Vector3 (ran2, obs[ran].position.y, z+10), obs [ran].rotation);
						Instantiate (coin, new Vector3 (ran3, 0.7f, z+10), coin.rotation);
					}
				}
			}
			cameramove.speed += 1;
		}
		scoreTxt.text = "SCORE: " + score.ToString ();
	}
}
