using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{    
    [SerializeField] float erunSpeed = 5f;
    [SerializeField] float leftBound = 0.16f;
    [SerializeField] float rightBound = 1.76f;
    private bool movingRight = true;

    void Start()
    {
    }

    void Update()
    {
        if (movingRight)
        {
            GetComponent<SpriteRenderer>().flipX= true;
            transform.Translate(Vector3.right * erunSpeed * Time.deltaTime);
            if (transform.position.x >= rightBound)
            {
                movingRight = false;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX= false;
            transform.Translate(Vector3.left * erunSpeed * Time.deltaTime);
            if (transform.position.x <= leftBound)
            {
                movingRight = true;
            }
        }
    }
}