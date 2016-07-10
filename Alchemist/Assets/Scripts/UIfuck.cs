using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UIfuck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}


	public void OnExitClick(){
		Application.Quit ();
	}

	public void OnReloadClick(){
		Application.LoadLevel ("Demo_1");
	}
}
