using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool rotate = true;
    public float rotationSpeed = 180f;

    public bool hover = true;
    public float hoverHeight = 1f;
    public float hoverSpeed = 1f;

    private Vector3 startPosition;
    private bool hoverUp = true;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        Debug.Log("startPosition = " + startPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate) Rotate(rotationSpeed);

        if (hover)
        {
            MoveUpDown(hoverUp, hoverSpeed, hoverHeight);

            if (transform.position.y >= startPosition.y + hoverHeight)
            {
                hoverUp = false;
                // Debug.Log("Set hover DOWN");
            }
            else if (transform.position.y <= startPosition.y)
            {
                hoverUp = true;
                // Debug.Log("Set hover UP");
            }
        }
    }

    void Rotate(float speed)
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
    
    void MoveUpDown(bool goingUp, float speed, float height)
    {
        if (goingUp)
        {
            transform.position = transform.position + new Vector3(0, speed * Time.deltaTime, 0);
            Debug.Log("Going UP");
        }
        else
        {
            transform.position = transform.position - new Vector3(0, speed * Time.deltaTime, 0);
            Debug.Log("Going UP");
        }
    }
}
