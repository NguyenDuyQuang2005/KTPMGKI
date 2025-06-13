using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFlat : MonoBehaviour
{
  [SerializeField] private Transform startPoint; // Điểm bắt đầu
  [SerializeField] private Transform endPoint; // Điểm kết thúc
  [SerializeField] private float moveSpeed = 2f; // Tốc độ di chuyển
  private Vector3 targetPosition; // Vị trí mục tiêu
    void Start()
    {
        targetPosition = startPoint.position; // Bắt đầu di chuyển đến điểm kết thúc
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Đổi hướng di chuyển khi đến điểm kết thúc hoặc điểm bắt đầu
            if (targetPosition == startPoint.position)
            {
                targetPosition = endPoint.position; // Di chuyển đến điểm kết thúc
            }
            else
            {
                targetPosition = startPoint.position; // Di chuyển về điểm bắt đầu
            }
        }
    }
}
