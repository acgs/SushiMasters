using UnityEngine;
using System.Collections;

public class sushiDestroyer : MonoBehaviour {

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "makisushi" || col.gameObject.tag == "nigirisushi" || col.gameObject.tag == "temakisushi"){
            Destroy(col.gameObject);
        }
    }
}
