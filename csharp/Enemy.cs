using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float Distance = 3f;
    private Vector2 startPosition;
    private bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float leftBound = startPosition.x - Distance;
        float rightBound = startPosition.x + Distance;
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            if (transform.position.x >= rightBound)
            {
                movingRight = false; // Đổi hướng di chuyển
                Flip(); // Đảo ngược hướng
            }
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            if (transform.position.x <= leftBound)
            {
                movingRight = true; // Đổi hướng di chuyển
                Flip(); // Đảo ngược hướng
            }
        }
    }
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Đảo ngược trục x
        transform.localScale = scale; // Cập nhật tỉ lệ mới
    }
}
