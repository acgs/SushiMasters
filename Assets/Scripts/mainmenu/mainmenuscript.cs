using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class mainmenuscript : MonoBehaviour {

	private List<GameObject> buttons = null;
	// Use this for initialization
	void Start () {
		Debug.Log("Making MainMenu...");
		buttons = new List<GameObject>();
		foreach(Transform child in transform){
			buttons.Add(child.gameObject);
		}
		//is there a better way to do this?
		buttons[0].GetComponent<mainmenubutton>().scenetag = "sushigame";
		buttons[1].GetComponent<mainmenubutton>().scenetag = "howtoplay";
		buttons[2].GetComponent<mainmenubutton>().scenetag = "credits";
		buttons [3].GetComponent<mainmenubutton> ().scenetag = "exit";
		foreach(GameObject button in buttons){
			button.GetComponent<mainmenubutton>().menu = this;
		}
		Debug.Log("Done making MainMenu.");
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
