using UnityEngine;
using System.Collections;

public class TemakiGame : MonoBehaviour {
    public SushiMenu menu;
    public int ingredientIndex = 0;
    public float initial_xPos = 0f;
    public float initial_yPos = 2.159578f;
    public float initial_zPos = 0.7407658f;
    public Transform temaki_prefab;
    // Use this for initialization
    void Start () {
        menu = GameObject.FindGameObjectsWithTag("sushimenu")[0].GetComponent<SushiMenu>();

    }

    // Update is called once per frame
    void Update () {

    }

    public void buildGame(){
        GameObject.FindGameObjectWithTag("temakibackground").GetComponent<Renderer>().enabled = true;
        //randomly place children in one of three locations
        int i = 0;

        Transform[] allChildren = (Transform[]) GetComponentsInChildren<Transform>().Clone();

        Transform[] noriricefishChildren = new Transform[3];
        foreach(Transform child in allChildren){
            if(child.gameObject.tag == "fish" ||
                child.gameObject.tag == "nori" ||
                child.gameObject.tag == "rice"){
                noriricefishChildren[i] = child;
                i++;
            }
        }
        i=0;

        //Debug.Log(noriricefishChildren);
        ShuffleArray(noriricefishChildren);

        //Debug.Log(noriricefishChildren);
        foreach(Transform child in transform){
            child.gameObject.GetComponent<Collider>().enabled = true;
            child.GetComponent<Renderer>().enabled = true;
            if(child.gameObject.tag != "prepboard"){
                child.transform.position = noriricefishChildren[i].GetComponent<NoriRiceFish>().initialPosition;
                i++;
            }
        }
    }

    public static void ShuffleArray<T>(T[] arr) {
        for (int i = arr.Length - 1; i > 0; i--) {
            int r = Random.Range(0, i + 1);
            T tmp = arr[i];
            arr[i] = arr[r];
            arr[r] = tmp;
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
        Transform temakiClone = (Transform) Instantiate(temaki_prefab, new Vector3(initial_xPos, initial_yPos, initial_zPos), Quaternion.identity);
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
