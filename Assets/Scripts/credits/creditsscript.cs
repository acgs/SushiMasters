using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class creditsscript : MonoBehaviour {

	private List<GameObject> buttons = null;
	// Use this for initialization
	void Start () {
		Debug.Log("Making CreditsMenu...");
		buttons = new List<GameObject>();
		foreach(Transform child in transform){
			buttons.Add(child.gameObject);
		}
		//is there a better way to do this?
		buttons[0].GetComponent<creditsbutton>().scenetag = "mainmenu";
		foreach(GameObject button in buttons){
			button.GetComponent<creditsbutton>().menu = this;
		}
		Debug.Log("Done making creditsmenu.");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void buildMenu(){
		//Display the menu buttons
		foreach(GameObject button in buttons){
			button.GetComponent<Renderer>().enabled = true;
			button.GetComponent<Collider>().enabled = true;
		}
	}
	public void destroyMenu(){
		foreach(GameObject button in buttons){
			button.GetComponent<Renderer>().enabled = false;
			button.GetComponent<Collider>().enabled = false;
		}
	}
}
