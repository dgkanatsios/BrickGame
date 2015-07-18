using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        InitializeColor();
    }

    public void InitializeColor()
    {
        GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }


    // Update is called once per frame
    void Update () {
	
	}

    void OnCollisionExit2D(Collision2D col)
    {
        gameObject.SetActive(false);
        GameManager.Score += 20;
        GameManager.BlocksAlive--;
    }
}
