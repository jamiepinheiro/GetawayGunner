using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public AudioClip chickenDying, hitSound;
	AudioSource aS;
	public Slider healthBar;
	public static float health;
	public static bool chickenDie;
	static bool gotHit;

	// Use this for initialization
	void Start () {

		aS = GetComponent<AudioSource>();
		health = 100;
		chickenDie = false;
		gotHit = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(Game.playing && !Game.gameOver){

			if(gotHit){
				aS.PlayOneShot(hitSound);
				gotHit = false;
			}

			if(chickenDie){
				aS.PlayOneShot(chickenDying);
				chickenDie = false;
			}

			if(health <= 0){
				Game.gameOver = true;
			}

			healthBar.gameObject.SetActive(true);
			healthBar.value = health/100.0f;

		}else{
			healthBar.gameObject.SetActive(false);
		}

	}
	public static void Hit (string name) {

		if(!Game.gameOver){

			gotHit = true;
			if(name == "Chicken Lvl3(Clone)"){
				health -= 33.4f;
			}else if(name == "Chicken Lvl2(Clone)"){
				health -= 25;
			}else if(name == "Chicken Lvl1(Clone)"){
				health -= 20;
			}

			CameraShake.shake = 0.2f;

			GameObject[] chickens = GameObject.FindGameObjectsWithTag("Chicken");

			foreach(GameObject chicken in chickens){
				chicken.transform.Translate(0, 0, 5, Space.World);
			}

		}

	}

}
