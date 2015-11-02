using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
    public bool rightToLeft; //all arrows start off right to left.
    public MakiGame makiGame; //handle to the makigame so we don't have to look it up.
    public bool beaten; //if this arrow has been beaten this game.
    public bool clicked; //if this arrow is currently being swiped on
    private float lastXPos;
    private float lastYPos;

    // Use this for initialization
    void Start () {
        //rightToLeft = true;
        clicked = false;
        lastXPos = 0;
        lastYPos = 0;
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
        Debug.Log("Mouse clicked! Casting ray...");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100)){
                Debug.Log("Cast ray. Checking if we hit this rigidbody...");
                if(hit.rigidbody != null && hit.rigidbody == this.GetComponent<Rigidbody>()){
                    clicked = true;
                    Debug.Log("Starting swipe on arrow...");
                    lastYPos = Input.mousePosition.y;
                    lastXPos = Input.mousePosition.x;
                    return;
                }
            }
    }
    void onMouseClickUp(){
        if(clicked == true){
            clicked = false;
            Debug.Log("Ended swipe. Beat this arrow");
            this.GetComponent<Renderer>().enabled = false;//getComponent<Renderer>.enabled = false;
            this.GetComponent<Collider>().enabled = false;//getComponent<Collider>.enabled = false;
            beaten = true;
            makiGame.beatArrow();
        }
    }
    void onMouseHold(){
        if(!clicked){ return; }
        if(Input.mousePosition.y > lastYPos + 30 || Input.mousePosition.y < lastYPos - 30){ //decide how strict to be about vertical movement
            Debug.Log("Too much vertical movement!");
            if(makiGame != null){
                makiGame.failGame();
            }
        }
        /*
        else if(rightToLeft && Input.mousePosition.x > lastXPos + 20 ){
            Debug.Log("Horizontal movement backwards!");
            if(makiGame != null){
                makiGame.failGame();
            }
        }
        else if(!rightToLeft && Input.mousePosition.x < lastXPos + 20 ){
            Debug.Log("Horizontal movement backwards!");
            if(makiGame != null){
                makiGame.failGame();
            }
        }
        */
        lastXPos = Input.mousePosition.x;
    }

}
