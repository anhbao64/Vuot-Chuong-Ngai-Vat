using UnityEngine;

public class MovingHorizontalPlatform : MonoBehaviour
{
    public float moveDistance = 3f;   // đi qua phải bao xa rồi quay lại
    public float moveSpeed = 2f;

    private Vector2 startPos;
    private Vector2 targetPos;
    private bool goingToTarget = true;

    void Start()
    {
        startPos = transform.position;
        targetPos = new Vector2(startPos.x + moveDistance, startPos.y);
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
