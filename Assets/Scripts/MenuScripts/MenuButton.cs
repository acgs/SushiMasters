using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {
    private bool clicked = false;
    public SushiMenu menu;
    public string gametag;
    // Use this for initialization
    void Start () {
        Debug.Log("Creating a MenuButton...");
        //menu = null;
        //gametag = null;
        Debug.Log("Done making MenuButton.");
    }

    // Update is called once per frame
    void Update () {

        if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
                if(Physics.Raycast(ray, out hit, 100)){
                    Debug.Log("Cast ray. Checking if we hit this rigidbody...");
                    if(hit.rigidbody != null && hit.rigidbody == GetComponent<Rigidbody>()){
                        clicked = true;
                        Debug.Log("Got click on button");
                        Debug.Log("Selecting minigame:");
                        Debug.Log(gametag);
                        return;
                    }
                }
        }
        if(Input.GetMouseButtonUp(0)){
            if(clicked == true){
                clicked = false;
                Debug.Log("Click ended on button. Making mini game...");
                Debug.Log(gametag);
                if(menu == null){
                    Debug.Log("No reference to menu script!");
                }
                if(gametag == null){
                    Debug.Log("No gametag!");
                }
                if(menu != null && gametag != null){
                    Debug.Log("Destroying menu...");
                    menu.destroyMenu();


                    //think of better way to do this
                    if(gametag == "temakigame"){
                        //GameObject.FindGameObjectsWithTag(gametag)[0].GetComponent<gametag>().buildGame();
                    }
                    if(gametag == "makigame"){
                        GameObject.FindGameObjectsWithTag(gametag)[0].GetComponent<MakiGame>().buildGame();
                    }
                }
                return;
            }
        }

       foreach (Touch touch in Input.touches){
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            switch (touch.phase){
                case TouchPhase.Began:
                if(Physics.Raycast(ray, out hit, 100)){
                    if(hit.rigidbody != null && hit.rigidbody == GetComponent<Rigidbody>()){
                        clicked = true;
                        Debug.Log("Got click on temaki button");
                        break;
                    }
                }

                    break;
                case TouchPhase.Moved:
                    break; //do nothing
                case TouchPhase.Ended:
                    if(clicked){
                        clicked = false;
                        Debug.Log("Click ended on temaki button. Making temaki game...");
                        //make menu buttons invisible and non-interactive
                        //load temaki minigame
                    }
                    break;
            }
       }
    }
}
