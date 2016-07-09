using UnityEngine;
using System.Collections;

public class arrow : MonoBehaviour {

	public float XSpeed;
	//Rigidbody2D rigidbody2D;

	// Use this for initialization
	void Start () {
		//rigidbody2D = GetComponent<Rigidbody2D> ();
		Destroy(gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
		//rigidbody2D.velocity = new Vector2 (XSpeed,0);
	}
}
