using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class howtoplayscript : MonoBehaviour {

	private List<GameObject> buttons = null;
	// Use this for initialization
	void Start () {
		Debug.Log("Making HowtoplayMenu...");
		buttons = new List<GameObject>();
		foreach(Transform child in transform){
			buttons.Add(child.gameObject);
		}
		//is there a better way to do this?
		buttons[0].GetComponent<howtoplaybutton>().scenetag = "mainmenu";
		foreach(GameObject button in buttons){
			button.GetComponent<howtoplaybutton>().menu = this;
		}
		Debug.Log("Done making HowtoplayMenu.");
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
