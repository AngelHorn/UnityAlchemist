using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
		//transform.position = target.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(Mathf.Lerp(transform.position.x, target.position.x, 4 * Time.deltaTime), 
			Mathf.Lerp(transform.position.y, target.position.y, Time.deltaTime), transform.position.z);
			//transform.Translate (Time.deltaTime, Time.deltaTime, 0, target);
	}


}
