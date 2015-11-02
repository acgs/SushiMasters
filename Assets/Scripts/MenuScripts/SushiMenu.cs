using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
    private GameObject[] buttons = null;
    // Use this for initialization
    void Start () {
        buttons = GameObject.FindGameObjectsWithTag("sushiselectmenu");
        //is there a better way to do this?
        buttons[0].GetComponent<MenuButton>().gametag = "nigirigame";
        buttons[1].GetComponent<MenuButton>().gametag = "makigame";
        buttons[2].GetComponent<MenuButton>().gametag = "temakigame";
        foreach(GameObject button in buttons){
            button.GetComponent<MenuButton>().menu = this;
        }
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
