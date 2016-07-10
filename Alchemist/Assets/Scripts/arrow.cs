using UnityEngine;
using System.Collections;

public class arrow : MonoBehaviour
{

	public float XSpeed;
	//Rigidbody2D rigidbody2D;

	// Use this for initialization
	void Start ()
	{
		//rigidbody2D = GetComponent<Rigidbody2D> ();
		Destroy (gameObject, 5);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//rigidbody2D.velocity = new Vector2 (XSpeed,0);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if(col.name == "player"){
			return;
		}
		if (name == "arrow_air(Clone)" && col.name == "earthDragon") {
			Destroy (col.gameObject);
		} else if (name == "arrow_earth(Clone)" && col.name == "waterDragon") {
			Destroy (col.gameObject);
		} else if (name == "arrow_water(Clone)" && col.name == "fireDragon") {
			Destroy (col.gameObject);
		} else if (name == "arrow_fire(Clone)" && col.name == "airDragon") {
			Destroy (col.gameObject);
		}
		Destroy (gameObject);

	}
}
