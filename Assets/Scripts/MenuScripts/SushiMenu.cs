using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SushiMenu : MonoBehaviour {
    private List<GameObject> buttons = null;
    // Use this for initialization
    void Start () {
        Debug.Log("Making SushiMenu...");
        buttons = new List<GameObject>();
        foreach(Transform child in transform){
            buttons.Add(child.gameObject);
        }
        //is there a better way to do this?
        buttons[0].GetComponent<MenuButton>().gametag = "nigirigame";
        buttons[1].GetComponent<MenuButton>().gametag = "makigame";
        buttons[2].GetComponent<MenuButton>().gametag = "temakigame";
        foreach(GameObject button in buttons){
            button.GetComponent<MenuButton>().menu = this;
        }
        Debug.Log("Done making SushiMenu.");
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
