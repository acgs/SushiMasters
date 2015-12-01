using UnityEngine;
using System.Collections;

public class CustomerCollisionHandler : MonoBehaviour {

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    void OnTriggerEnter(Collider col) {
        //Debug.Log("Collision with customer collider.");
        //Debug.Log(col.gameObject.tag);
        //Debug.Log(transform.parent.GetComponent<Customer>().type);
        if(transform.parent.GetComponent<Customer>().type == "tourist" && col.gameObject.tag == "makisushi")
        {
            onTriggered(col.gameObject);
        }
        if(transform.parent.GetComponent<Customer>().type == "critic" && col.gameObject.tag == "nigirisushi")
        {
            onTriggered(col.gameObject);
        }
        if(transform.parent.GetComponent<Customer>().type == "student" && col.gameObject.tag == "makisushi")
        {
            onTriggered(col.gameObject);
        }
    }

    void onTriggered(GameObject sushi){
        GameObject.FindGameObjectsWithTag(transform.parent.GetComponent<Customer>().pathName)[0].GetComponent<chair>().hasCustomer = false;
            Destroy(sushi);
            Destroy(transform.parent.gameObject);
    }
}
