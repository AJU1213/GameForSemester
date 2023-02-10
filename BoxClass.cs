using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClass : MonoBehaviour
{
    private float boxSpeed = 5f;
    private bool isMoving = false;
    private bool hasReachedPoint = false;

    [SerializeField] private GameObject gameObj;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BoxMovement();
    }

    public void BoxMovement()
    {
        Vector2 startPos = transform.position;
        Vector2 endPos = new Vector2 (1f, transform.position.y); 
        if(isMoving == false)
        {
            transform.position = Vector2.MoveTowards (startPos, endPos , boxSpeed * Time.deltaTime);
            isMoving = true;
        }

        else if ((Vector2) transform.position == endPos)
        {
            isMoving = false;
            hasReachedPoint = true;
        }

        else if (isMoving == false && hasReachedPoint == true)
        {
            transform.position = Vector2.MoveTowards (endPos, startPos , boxSpeed * Time.deltaTime);
            isMoving = true;
        }

        else if ((Vector2) transform.position == startPos)
        {
            isMoving = false;
            hasReachedPoint = false;
        }
        

        //transform.position = new Vector2 (transform.position.x + .1f * boxSpeed, transform.position.y);
    }
}
