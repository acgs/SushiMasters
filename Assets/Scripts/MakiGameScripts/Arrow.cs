using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    public bool rightToLeft; //all arrows start off right to left.
    public MakiGame makiGame; //handle to the makigame so we don't have to look it up.
    public bool beaten; //if this arrow has been beaten this game.
    public bool clicked; //if this arrow is currently being swiped on

    /*Set through unity*/
    public Sprite leftToRightSprite;
    public Sprite rightToLeftSprite;

    // Use this for initialization
    void Start () {
        //rightToLeft = true;
        clicked = false;
        //makiGame = null;
        beaten = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer.sprite == null){
            spriteRenderer.sprite = leftToRightSprite;
        }
    }

    public void setMakiGame(MakiGame game){
        makiGame = game;
    }

    public void setRightToLeft(bool rightToLeft){
        this.rightToLeft = rightToLeft;
        if(this.rightToLeft){
            spriteRenderer.sprite = rightToLeftSprite;
        }
        else{
            spriteRenderer.sprite = leftToRightSprite;
        }
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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100)){
            if(hit.collider != null){
                if(rightToLeft){
                    if(hit.collider == transform.Find("right_collider").GetComponent<Collider>()){
                        clicked = true;
                        return;
                    }
                }
                else{
                    if(hit.collider == transform.Find("left_collider").GetComponent<Collider>()){
                        clicked = true;
                        return;
                    }
                }
            }
        }
    }
    void onMouseClickUp(){
        if(!clicked){return;}
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
            this.GetComponent<Renderer>().enabled = false;//getComponent<Renderer>.enabled = false;
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

        //just check that we're still colliding with body collider
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100)){
            if(hit.collider == null){
                if(makiGame != null){
                    makiGame.failGame();
                }
                return;
            }
            if(hit.collider != transform.Find("right_collider").GetComponent<Collider>() && hit.collider != transform.Find("left_collider").GetComponent<Collider>() && hit.collider != transform.Find("body").GetComponent<Collider>()){
                makiGame.failGame();
                return;
            }
            return;
        }
        if(makiGame != null){
            makiGame.failGame();
        }
    }

}
