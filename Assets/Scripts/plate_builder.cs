using UnityEngine;
using System.Collections;

public class plate_builder : MonoBehaviour {
    public float delay = 0.5f;
    public float nextUsage;
    public int numPlates = 40;
    public float initial_xPos = 0f;
    public float initial_yPos = 2.159578f;
    public float initial_zPos = 0.7407658f;
    public Transform plate_prefab;
    // Use this for initialization
    void Start () {
        nextUsage = Time.time + delay;
    }

    // Update is called once per frame
    void Update () {
        if (numPlates > 0 && Time.time > nextUsage){
            //instantiate plate prefab and set its script to enabled
            Transform plateClone = (Transform) Instantiate(plate_prefab, new Vector3(initial_xPos, initial_yPos, initial_zPos), Quaternion.identity);
            nextUsage = Time.time + delay;
            plateClone.GetComponent<plate>().enabled = true;
            plateClone.GetComponent<Collider>().enabled = true;
            numPlates--;

        }
    }
}
