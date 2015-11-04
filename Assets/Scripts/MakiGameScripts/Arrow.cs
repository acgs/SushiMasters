using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
    public bool rightToLeft; //all arrows start off right to left.
    public MakiGame makiGame; //handle to the makigame so we don't have to look it up.
    public bool beaten; //if this arrow has been beaten this game.
    public bool clicked; //if this arrow is currently being swiped on

    // Use this for initialization
    void Start () {
        //rightToLeft = true;
        clicked = false;
        //makiGame = null;
        beaten = false;
    }

    public void setMakiGame(MakiGame game){
        makiGame = game;
    }

    public void setRightToLeft(bool rightToLeft){
        this.rightToLeft = rightToLeft;
    }

    public void toggleRightToLeft(){
        setRightToLeft(!rightToLeft);
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetMouseButtonDown(0)){
            onMouseClickDown();
            return;
        }
        if(Input.GetMouseButtonUp(0)){
            onMouseClickUp();
            return;
        }
        if(Input.GetMouseButton(0)){ //holding down (swiping)
            onMouseHold();
            return;
        }
    }
    void onMouseClickDown(){
        Debug.Log("Mouse clicked in arrow! Casting ray...");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100)){
            Debug.Log("Cast ray. Checking if we hit this collider...");
            if(hit.collider != null){
                if(rightToLeft){
                    if(hit.collider == transform.Find("right_collider").GetComponent<Collider>()){
                        clicked = true;
                        Debug.Log("Starting swipe on arrow...");
                        return;
                    }
                }
                else{
                    if(hit.collider == transform.Find("left_collider").GetComponent<Collider>()){
                        clicked = true;
                        Debug.Log("Starting swipe on arrow...");
                        return;
                    }
                }
            }
        }
    }
    void onMouseClickUp(){
        if(!clicked){return;}
        Debug.Log("In arrow onMouseClickUp.");
        //raycast to see if we ended on the correct collider
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100)){
            if(rightToLeft){
                if(hit.collider != transform.Find("left_collider").GetComponent<Collider>()){
                    if(makiGame != null){
                        makiGame.failGame();
                    }
                    return;
                }
            }
            else{
                if(hit.collider != transform.Find("right_collider").GetComponent<Collider>()){
                    if(makiGame != null){
                        makiGame.failGame();
                    }
                    return;
                }
            }
            //if we make it this far, then the arrow is beat.
            clicked = false;
            Debug.Log("Ended swipe. Beat this arrow");
            this.GetComponent<Renderer>().enabled = false;//getComponent<Renderer>.enabled = false;
            //this.GetComponent<Collider>().enabled = false;//getComponent<Collider>.enabled = false;
            foreach(Transform child in transform){
                child.gameObject.GetComponent<Collider>().enabled = false;
            }
            beaten = true;
            makiGame.beatArrow();
            return;
        }
        //fail because we didn't detect a hit
        if(makiGame != null){
            makiGame.failGame();
        }
    }
    void onMouseHold(){
        if(!clicked){ return; }
        Debug.Log("In arrow onMouseHold.");

        //just check that we're still colliding with body collider
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.Log("Casting ray from mouse position:");
        Debug.Log(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100)){
            if(hit.collider == null){
                Debug.Log("No collider hit! Failed game.");
                if(makiGame != null){
                    makiGame.failGame();
                }
                return;
            }
            if(hit.collider != transform.Find("right_collider").GetComponent<Collider>() && hit.collider != transform.Find("left_collider").GetComponent<Collider>() && hit.collider != transform.Find("body").GetComponent<Collider>()){
                Debug.Log("Collided with something besides this arrow's colliders! Failed game.");
                makiGame.failGame();
                return;
            }
            Debug.Log("Collided with one of this arrow's colliders:");
            Debug.Log(hit.collider);
            return;
        }
        Debug.Log("No ray cast hit. Failed game.");
        if(makiGame != null){
            makiGame.failGame();
        }
    }

}
