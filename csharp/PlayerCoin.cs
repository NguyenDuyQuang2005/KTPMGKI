using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollition : MonoBehaviour
{
  private Gamemanager gameManager;
  private AudioManaGer audioManager;
  private void Awake()
  {
    // Lấy tham chiếu đến GameManager
    gameManager = FindObjectOfType<Gamemanager>();
    audioManager = FindObjectOfType<AudioManaGer>();
  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    // Kiểm tra va chạm với đối tượng có tag "Enemy"
    if (collision.CompareTag("Coin"))
    {
      gameManager.AddScore(1); // Gọi hàm AddScore từ GameManager để tăng điểm
      Destroy(collision.gameObject); // Hủy đối tượng Coin sau khi va chạm
      audioManager.PlayCoinSound(); // Phát âm thanh khi thu thập Coin
    }
    else if (collision.CompareTag("trap"))
    {
      gameManager.GameOver(); // Gọi hàm AddScore từ GameManager để giảm điểm
    }
    else if (collision.CompareTag("Enemy"))
    {
      gameManager.GameOver(); // Gọi hàm AddScore từ GameManager để giảm điểm
    }
    else if (collision.CompareTag("Key"))
    {
      gameManager.GameWin(); // Gọi hàm GameWin từ GameManager để kết thúc trò chơi
      Destroy(collision.gameObject); // Hủy đối tượng Key sau khi va chạm
    }
  }
}
