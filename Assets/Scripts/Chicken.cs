using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Chicken : MonoBehaviour {
	
	public GameObject chickenExplosion, chicken1, chicken2;
	float health;

	// Use this for initialization
	void Start () {
	
		health = 100;

	}
	
	// Update is called once per frame
	void Update () {

		transform.LookAt(new Vector3(0, 1, 2.5f), Vector3.up);

		if(Game.playing){

			transform.FindChild("Chicken").transform.FindChild("Canvas").transform.FindChild("Slider").gameObject.SetActive(true);

			transform.Translate(Vector3.forward * Time.deltaTime * 1.5f);

			if(health <= 0){
				Instantiate(chickenExplosion, transform.position, Quaternion.Euler(270, 0, 0));
				if(gameObject.name == "Chicken Lvl3(Clone)"){
					Game.score += 20;
					Instantiate(chicken2, new Vector3(transform.position.x - 3, transform.position.y, transform.position.z), transform.rotation);
					Instantiate(chicken2, new Vector3(transform.position.x + 3, transform.position.y, transform.position.z), transform.rotation);
				}else if(gameObject.name == "Chicken Lvl2(Clone)"){
					Game.score += 10;
					Instantiate(chicken1, new Vector3(transform.position.x - 2, transform.position.y, transform.position.z), transform.rotation);
					Instantiate(chicken1, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), transform.rotation);
				}
				Game.score += 10;
				Player.chickenDie = true;
				Destroy(gameObject);
			}

			transform.FindChild("Chicken").transform.FindChild("Canvas").transform.FindChild("Slider").GetComponent<Slider>().value = (health/100);

		}else{
			transform.FindChild("Chicken").transform.FindChild("Canvas").transform.FindChild("Slider").gameObject.SetActive(false);
		}

	}

	void Hit () {

		if(gameObject.name == "Chicken Lvl3(Clone)"){
			health -= 1;
		}else if(gameObject.name == "Chicken Lvl2(Clone)"){
			health -= 2;
		}else if(gameObject.name == "Chicken Lvl1(Clone)"){
			health -= 4;
		}

	}

	void OnCollisionEnter (Collision col) {

		if(col.gameObject.tag == "Car"){

			Instantiate(chickenExplosion, transform.position, Quaternion.Euler(270, 0, 0));
			Destroy(gameObject);
			Player.Hit(name);

		}

	}

}
