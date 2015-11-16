using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class NoriRiceFish : MonoBehaviour{
    public bool clicked;
    public TemakiGame temakigame;
    public Vector3 screenPoint;
    public Vector3 offset;
    public Vector3 initialPosition;

    // Use this for initialization
    void Start () {
        initialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
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
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray, 100);

        if(hits.Length > 0){
            foreach(RaycastHit hit in hits){
                if(hit.collider == GetComponent<Collider>()){
                    clicked = true;
                    screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                    offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
                    return;
                }
            }
        }
    }

    void onMouseHold(){
        if(!clicked){ return; }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray, 100);

        if(hits.Length > 0){
            foreach(RaycastHit hit in hits){
                if(hit.collider == GetComponent<Collider>()){
                    Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
                    Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
                    transform.position = curPosition;
                    return;
                }
            }
        }
    }


    void onMouseClickUp(){
        if(!clicked){return;}

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray, 100);
        if(hits.Length > 0){
            bool ingredientCollided = false;
            bool prepBoardCollided = false;

            foreach(RaycastHit hit in hits){
                if(hit.collider == GetComponent<Collider>()){
                    ingredientCollided = true;
                }
                if(hit.collider == GameObject.FindGameObjectWithTag("prepboard").GetComponent<Collider>()){
                    prepBoardCollided = true;
                }
            }

            if(ingredientCollided && prepBoardCollided){
                temakigame.ingredientOnBoard(gameObject);
            }
        }


        clicked = false;
    }





}



