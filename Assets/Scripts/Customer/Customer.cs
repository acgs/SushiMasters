using UnityEngine;
using System.Collections;

public class Customer : MonoBehaviour {
    public string type;
    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {

    }



    public void startPath(string pathName){
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathName), "time", 2, "easetype", iTween.EaseType.linear)); //
    }
}
