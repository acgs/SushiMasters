using UnityEngine;
using System.Collections;

public class sushi_handler : MonoBehaviour {
    public string sushiType;
    public float initial_xPos = 0f;
    public float initial_yPos = 2.159578f;
    public float initial_zPos = 0.7407658f;
    public Transform plate;
    public bool moving = false;
    // Use this for initialization
    void Start () {
        Debug.Log("Created sushi!");
    }

    // Update is called once per frame
    void Update () {
        if(!moving){
            //check if there is an open plate at our position by raycasting
            //Ray ray = Camera.main.ScreenPointToRay(new Vector2(initial_xPos, initial_yPos));
            RaycastHit[] hits;
            hits = Physics.RaycastAll(new Vector3(initial_xPos, initial_yPos, 0), transform.forward, 100);
            foreach(RaycastHit hit in hits){
                foreach(GameObject plate in GameObject.FindGameObjectsWithTag("plate_collider")){
                    if(hit.collider == plate.GetComponent<Collider>()){
                        if(!plate.transform.parent.GetComponent<plate>().hasSushi){
                            //if so, attach this sushi to the plate.
                            this.plate = plate.transform.parent;
                            this.plate.GetComponent<plate>().hasSushi = true;
                            moving = true;
                            //display this sushi
                            GetComponent<SpriteRenderer>().enabled = true;
                            GetComponent<Collider>().enabled = true;
                            return;
                        }
                    }
                }
            }
            //if we get here, then there were no plates or no open plates. So, we'll just wait till next time.
            return;
        }
        //then we're moving. Just move our position to our plate's position
        transform.position = this.plate.transform.position;

    }

    void onDestroy(){
        //reset the plate's hasSushi
        this.plate.GetComponent<plate>().hasSushi = false;
    }
}
