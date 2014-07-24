using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float input;

        if (Input.touchCount > 0)//touch input
        {
            input = Input.touches[0].position.x >= Screen.width / 2 ? 1f : -1f;
        }
        else//keyboard input
        {
            input = Input.GetAxis("Horizontal");
        }

        transform.Translate(new Vector2(input * speed * Time.deltaTime, 0));
        float currentX = Mathf.Clamp(transform.position.x, LeftBlockTransform.position.x + 1, RightBLockTransform.position.x - 1);
        transform.position = new Vector3(currentX, transform.position.y, transform.position.z);
    }

    public Transform LeftBlockTransform, RightBLockTransform;
    public float speed = 50;
     
}
