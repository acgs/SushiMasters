using UnityEngine;
using System.Collections;

public class TemakiGame : MonoBehaviour {
    public SushiMenu menu;
    public int ingredientIndex = 0;

    // Use this for initialization
    void Start () {
        menu = GameObject.FindGameObjectsWithTag("sushimenu")[0].GetComponent<SushiMenu>();

    }

    // Update is called once per frame
    void Update () {

    }

    public void buildGame(){
        GameObject.FindGameObjectWithTag("temakibackground").GetComponent<Renderer>().enabled = true;
        foreach(Transform child in transform){
            child.gameObject.GetComponent<Collider>().enabled = true;
            child.GetComponent<Renderer>().enabled = true;
        }
    }


    public void ingredientOnBoard(GameObject ingredient){
        if(ingredient == GameObject.FindGameObjectWithTag("nori")){
            if(ingredientIndex == 0){
                ingredientIndex++;
                ingredient.GetComponent<Collider>().enabled = false;
            }
            else{
                failGame();
            }
        }

        if(ingredient == GameObject.FindGameObjectWithTag("rice")){
            if(ingredientIndex == 1){
                ingredientIndex++;
                ingredient.GetComponent<Collider>().enabled = false;
            }
            else{
                failGame();
            }
        }

        if(ingredient == GameObject.FindGameObjectWithTag("fish")){
            if(ingredientIndex == 2){
                ingredient.GetComponent<Collider>().enabled = false;
                winGame();
            }
            else{
                failGame();
            }
        }
    }


    public void failGame(){ //called by an arrow if the game is failed
        Debug.Log("Failed the game! Try Again!");
        ingredientIndex = 0;
        cleanup();
    }
    public void winGame(){
        Debug.Log("Beat the Temaki game!");
        ingredientIndex = 0;
        cleanup();
    }

    void cleanup(){
        GameObject.FindGameObjectWithTag("temakibackground").GetComponent<Renderer>().enabled = false;
        foreach(Transform child in transform){
            child.gameObject.GetComponent<Collider>().enabled = false;
            child.gameObject.GetComponent<Renderer>().enabled = false;
            //move back to initial position
            if(child.gameObject != GameObject.FindGameObjectWithTag("prepboard")){
                child.position = child.gameObject.GetComponent<NoriRiceFish>().initialPosition;
            }
        }
        menu.buildMenu();
    }
}
