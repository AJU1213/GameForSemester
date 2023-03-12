using System.Collections;
using UnityEngine;

public class BoxClass : MonoBehaviour
{
    private float boxSpeed = 5f;
    private bool isMoving = false;
    private bool hasReachedPoint = false;

    [SerializeField] private GameObject gameObj;

    private void Start()
    {
        StartCoroutine(DelayedMovement());
    }

    private IEnumerator DelayedMovement()
    {
        yield return new WaitForSeconds(5f);
        StartCoroutine(MoveBox());
    }

    private IEnumerator MoveBox()
    {
        while (true)
        {
            Vector2 startPos = transform.position;
            Vector2 endPos = new Vector2(1f, transform.position.y);
            if (isMoving == false)
            {
                transform.position = Vector2.MoveTowards(startPos, endPos, boxSpeed * Time.deltaTime);
                isMoving = true;
            }
            else if ((Vector2)transform.position == endPos)
            {
                isMoving = false;
                hasReachedPoint = true;
            }
            else if (isMoving == false && hasReachedPoint == true)
            {
                transform.position = Vector2.MoveTowards(endPos, startPos, boxSpeed * Time.deltaTime);
                isMoving = true;
            }
            else if ((Vector2)transform.position == startPos)
            {
                isMoving = false;
                hasReachedPoint = false;
            }
            yield return null;
        }
    }
}

