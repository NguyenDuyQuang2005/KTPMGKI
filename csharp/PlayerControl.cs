using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    private AudioManaGer audioManager; // Thêm tham chiếu đến AudioManager
    private Animator animator;
    private bool isGrounded;

    private Rigidbody2D rb;
    private Gamemanager gameManager;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<Gamemanager>();
        audioManager = FindObjectOfType<AudioManaGer>(); // Lấy tham chiếu đến AudioManager
    }

    void Update()
    {
        if (gameManager.IsGameOver()|| gameManager.IsGameWin())
        {
            return; // Nếu game over, không xử lý điều khiển
        }
        HandleMoveMent();
        HandleJump();
        UpdateAnimation();
    }

    private void HandleMoveMent()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip character
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void HandleJump()
    {
        // Nếu nhấn Jump và đang đứng đất thì nhảy
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            audioManager.PlayJumpSound(); // Phát âm thanh khi nhảy
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        // Kiểm tra đang đứng trên mặt đất
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }
    private void UpdateAnimation()
    {
        bool isRunning = Mathf.Abs(rb.velocity.x) > 0.1f;
        bool isJumping = !isGrounded;
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);
    }
}
