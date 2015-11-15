using UnityEngine;
using System.Collections;

public class plate : MonoBehaviour {

    void Start () {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("belt_path"), "time", 10, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop)); //
    }

    // Update is called once per frame
    void Update () {
    }

}
