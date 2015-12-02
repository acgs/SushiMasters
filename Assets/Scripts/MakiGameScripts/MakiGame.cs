using UnityEngine;
using System.Collections;

public class MakiGame : MonoBehaviour {
    private GameObject[] arrows;
    public SushiMenu menu;
    public float initial_xPos = 0f;
    public float initial_yPos = 2.159578f;
    public float initial_zPos = 0.7407658f;
    public Transform maki_prefab;
    // Use this for initialization
    void Start () {
        menu = GameObject.FindGameObjectsWithTag("sushimenu")[0].GetComponent<SushiMenu>();
       arrows = GameObject.FindGameObjectsWithTag("makiarrow");
       foreach(GameObject arrow in arrows){
            arrow.GetComponent<Arrow>().setMakiGame(this);
       }
    }

    // Update is called once per frame
    void Update () {

    }

    public void buildGame(){
		foreach(GameObject makibackground in GameObject.FindGameObjectsWithTag("makibackground"))
			makibackground.GetComponent<Renderer>().enabled = true;
		
        //randomly change orientation of arrows
        foreach(GameObject arrow in arrows){
            if(Random.Range(0,10) <= 5){
                Debug.Log("Swapping orientation of this arrow.");
                //arrow.GetComponent<Transform>().localScale = Vector3.Scale(arrow.GetComponent<Transform>().localScale , new Vector3(1.0F, -1.0F, 1.0F)); //scale in y
                arrow.GetComponent<Arrow>().toggleRightToLeft();
            }
            //show arrows
            arrow.GetComponent<Renderer>().enabled = true;
            //enable colliders of all children of arrow
            foreach(Transform child in arrow.transform){
                child.gameObject.GetComponent<Collider>().enabled = true;
            }
            //arrow.GetComponent<Collider>().enabled = true;
        }

    }
    public void failGame(){ //called by an arrow if the game is failed
        Debug.Log("Failed the game! Try Again!");
        cleanup();
    }
    public void winGame(){
        Debug.Log("Beat the Maki game!");
		Instantiate(maki_prefab, new Vector3(initial_xPos, initial_yPos, initial_zPos), Quaternion.identity);
        //Transform makiClone = (Transform) Instantiate(maki_prefab, new Vector3(initial_xPos, initial_yPos, initial_zPos), Quaternion.identity);
        cleanup();
    }
    void cleanup(){
		foreach(GameObject makibackground in GameObject.FindGameObjectsWithTag("makibackground"))
			makibackground.GetComponent<Renderer>().enabled = false;
        //hide arrows and other objects, rebuild menu
        foreach(GameObject arrow in arrows){
            arrow.GetComponent<Renderer>().enabled = false;
            foreach(Transform child in arrow.transform){
                child.gameObject.GetComponent<Collider>().enabled = false;
            }
            //arrow.GetComponent<Collider>().enabled = false;
            arrow.GetComponent<Arrow>().beaten = false;
            arrow.GetComponent<Arrow>().clicked = false;
        }
        menu.buildMenu();

    }
    public void beatArrow(){
        //Called when `arrow` is beaten. This checks for win condition.
        foreach(GameObject arrow in arrows){
            if(!arrow.GetComponent<Arrow>().beaten)
                return;
        }
        winGame();
    }
}
