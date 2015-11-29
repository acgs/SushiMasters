using UnityEngine;
using System.Collections;

public class plate : MonoBehaviour {
    public bool hasSushi = false;
    float rotationAmount = -36.0f;

    void Start () {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("belt_path"), "time", 10, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.loop)); //
    }

    // Update is called once per frame
    void Update () {
        Vector3 rot = transform.rotation.eulerAngles;
        rot.z = rot.z + rotationAmount * Time.deltaTime;
        if(rot.z > 360)
            rot.z -= 360;
        else if(rot.z < 360)
            rot.z += 360;

         transform.eulerAngles = rot;
    }

}
