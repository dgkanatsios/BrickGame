using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour
{

    public float SpeedY = 7;
    private Vector2 InitialLocation;

    // Use this for initialization
    void Start()
    {
        InitialLocation = transform.position;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.CurrentGameState == GameManager.GameState.Playing)
            GiveBoostIfMovingOnXorYAxis();
    }

    private void GiveBoostIfMovingOnXorYAxis()
    {
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x - 0.2f) <= 0.2f)
        {
            //left or right? 
            bool right = Random.Range(-1.0f, 1.0f) >= 0;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(right ? 5.0f : -5.0f, 0), ForceMode2D.Impulse);
        }

        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y - 0.2f) <= 0.2f)
        {
            //up or down? 
            bool down = Random.Range(-1.0f, 1.0f) >= 0;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, down ? 5.0f : -5.0f), ForceMode2D.Impulse);
        }
    }

    public void StartBall()
    {
        transform.position = InitialLocation;
        GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-3.0f, 3.0f), SpeedY);
    }

    public void StopBall()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }


}
