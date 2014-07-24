using UnityEngine;
using System.Collections;

public class FloorScript : MonoBehaviour
{


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
            GameManager.DecreaseLives();
    }
}
