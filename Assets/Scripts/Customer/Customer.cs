using UnityEngine;
using System.Collections;

public class Customer : MonoBehaviour {
    private SpriteRenderer spriteRenderer;

    /*These attributes get default values from the prefab */
    public string type;
    public float initialScore;
    public float currentScore;
    public float scoreDeclineRate; //amount to decrement every second
    public Sprite normalSprite;
    public Sprite angrySprite;
    // Use this for initialization
    void Start () {
        currentScore = initialScore;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer.sprite == null){
            spriteRenderer.sprite = normalSprite;
        }
    }

    // Update is called once per frame
    void Update () {
        if(currentScore <= initialScore * 0.2f && spriteRenderer.sprite != angrySprite){
            spriteRenderer.sprite = angrySprite;
        }

        if(currentScore <= 0.0f){
            //destroy this customer
            Destroy(transform.gameObject);
        }
        currentScore -= scoreDeclineRate * Time.deltaTime;

    }



    public void startPath(string pathName){
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath(pathName), "time", 2, "easetype", iTween.EaseType.linear)); //
    }
}
