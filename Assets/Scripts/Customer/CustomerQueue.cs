using UnityEngine;
using System.Collections;

public class CustomerQueue : MonoBehaviour {
    public string[] path_names = {"chair1_path", "chair2_path", "chair3_path", "chair4_path", "chair5_path", "chair6_path", "chair7_path", "chair8_path", "chair9_path", "chair10_path"};
    public Vector3[] path_starts = {new Vector3(0,0,0),new Vector3(3.700406f,2.539425f,0f),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0),new Vector3(0,0,0)};
    public Transform tourist_prefab;
    public Transform salaryman_prefab;
    public Transform student_prefab;
    public Transform critic_prefab;
    protected string[] customers;
    public float[] customer_times;
    public int[] customer_chair;
    public int customer_index = 0;

    public Transform getCustomerPrefab(string prefabName){
        if(prefabName == "tourist"){
            return tourist_prefab;
        }
        if(prefabName == "salaryman"){
            return salaryman_prefab;
        }
        if(prefabName == "student"){
            return student_prefab;
        }
        if(prefabName == "critic"){
            return critic_prefab;
        }
        return null;
    }
}
