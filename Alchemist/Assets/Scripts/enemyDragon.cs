using UnityEngine;
using System.Collections;

public class enemyDragon : MonoBehaviour {

	public Transform target;
	private bool isFaceRight = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x - target.position.x < 0 && isFaceRight) {
			Flip ();
			isFaceRight = false;
		} else if(transform.position.x - target.position.x > 0 && !isFaceRight) {
			Flip ();
			isFaceRight = true;
		}
		transform.position = new Vector3(Mathf.Lerp(transform.position.x, target.position.x, 0.3f * Time.deltaTime), 
			Mathf.Lerp(transform.position.y, target.position.y, 0.3f * Time.deltaTime), transform.position.z);
	}

	void Flip ()
	{
		transform.localScale = new Vector2 (-transform.localScale.x, transform.localScale.y);
	}
}
