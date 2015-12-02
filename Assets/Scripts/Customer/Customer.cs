using UnityEngine;
using System.Collections;

public class Customer : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    private bool waitingOnChair;
    private bool startedMove;
    public string pathName;

    /*These attributes get default values from the prefab */
    public string type;
    public float initialScore;
    public float currentScore;
    public float scoreDeclineRate; //amount to decrement every second
    public Sprite normalSprite;
    public Sprite angrySprite;
    // Use this for initialization
    void Start () {
        transform.GetChild(0).GetComponent<Collider>().enabled = false;
        waitingOnChair = true;
        startedMove = false;
        currentScore = initialScore;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer.sprite == null){
            spriteRenderer.sprite = normalSprite;
        }
		if(pathName == "chair5_path" || pathName == "chair6_path"){
			//rotate collider by 90 degrees
			transform.GetChild(0).Rotate(new Vector3(0,0,90));
		}
		if(pathName == "chair4_path" ){
			//rotate collider by -45 degrees
			transform.GetChild(0).Rotate(new Vector3(0,0,-45));
		}
		if(pathName == "chair7_path"){
			//rotate collider by 45 degrees
			transform.GetChild(0).Rotate(new Vector3(0,0,45));
		}
    }

    // Update is called once per frame
    void Update () {
        if(!startedMove && canMove()){
            startPath(pathName);
        }
        if(spriteRenderer == null){
            Debug.Log("ERROR: spriteRenderer is null!");
            Debug.Log("Trying to reget component...");
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        if(normalSprite == null){
            Debug.Log("ERROR: normalSprite is null!");
        }
        if(angrySprite == null){
            Debug.Log("ERROR: angrySprite is null!");
        }
        if(currentScore <= initialScore * 0.2f && spriteRenderer.sprite != angrySprite){
            spriteRenderer.sprite = angrySprite;
        }

        if(currentScore <= 0.0f){
            //destroy this customer
            Destroy(transform.gameObject);
            GameObject.FindGameObjectsWithTag(pathName)[0].GetComponent<chair>().hasCustomer = false;
        }
        currentScore -= scoreDeclineRate * Time.deltaTime;

    }

    private bool canMove(){
        /*
        We check if our chair has a customer in it already. If so, we keep waiting.
        */
        //Debug.Log("Checking if we can move to our chair with tag");
        //Debug.Log(pathName);
        if(pathName == null || pathName == "")
            return false;
        GameObject chair = GameObject.FindGameObjectsWithTag(pathName)[0];
        if(chair == null){
            Debug.Log("ERROR! NO CHAIR WITH TAG");
            Debug.Log(pathName);
            Debug.Log("COULD BE FOUND! NOT MOVING!");
            return false;
        }
        if(chair.GetComponent<chair>().hasCustomer){
            //Debug.Log("Chair has customer in it still!");
            return false;
        }

        //else, we can start moving and set waitingOnChair false
        chair.GetComponent<chair>().hasCustomer = true;
        waitingOnChair = false;
        return true;
    }

    private void onPathEnd(){
        /*Just a callback for the iTween path to call to activate the collider when we stop moving*/
        transform.GetChild(0).GetComponent<Collider>().enabled = true;
    }

    public void startPath(string pathName){
        startedMove = true;
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathName), "time", 2, "easetype", iTween.EaseType.linear,
            "onComplete","onPathEnd")); //
    }
}
