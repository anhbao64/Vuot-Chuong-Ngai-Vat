using UnityEngine;

public class MovingVerticalPlatform : MonoBehaviour
{
    public float moveDistance = 3f;   // đi lên bao xa rồi xuống
    public float moveSpeed = 2f;

    private Vector2 startPos;
    private Vector2 targetPos;
    private bool goingToTarget = true;

    void Start()
    {
        startPos = transform.position;
        targetPos = new Vector2(startPos.x, startPos.y + moveDistance);
    }

    void Update()
    {
        if (goingToTarget)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetPos) < 0.05f)
                goingToTarget = false;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, startPos) < 0.05f)
                goingToTarget = true;
        }
    }
}
