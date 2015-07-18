using UnityEngine;
using System.Collections;

public class FloorScript : MonoBehaviour
{
    public GameManager gameManager;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
            gameManager.DecreaseLives();
    }
}
