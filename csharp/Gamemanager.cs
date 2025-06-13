using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class Gamemanager : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameWinPanel;
    private bool isGameOver = false;
    private bool isGameWin = false;
    void Start()
    {
        gameOverPanel.SetActive(false); // Ẩn bảng Game Over khi bắt đầu
        UpdateScore();
        gameWinPanel.SetActive(false); // Ẩn bảng Game Win khi bắt đầu
    }
    public void AddScore(int points)
    {
        if (!isGameOver&& !isGameWin) // Chỉ thêm điểm nếu chưa game over hoặc game win
        {
            score += points;
            UpdateScore();
        }
    }
    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
    public void GameOver()
    {
        isGameOver = true;
        score = 0;
        Time.timeScale = 0; // Dừng thời gian khi game over
        gameOverPanel.SetActive(true); // Hiển thị bảng Game Over
    }
    public void GameWin()
    {
        isGameWin = true;
        Time.timeScale = 0; // Dừng thời gian khi game win
        gameWinPanel.SetActive(true); // Hiển thị bảng Game Win
    }
    public void RestartGame()
    {
        isGameOver = false;
        score = 0;
        UpdateScore();
        Time.timeScale = 1; // Tiếp tục thời gian khi khởi động lại
        SceneManager.LoadScene("Game"); // Tải lại cảnh hiện tại
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }
    public bool IsGameWin()
    {
        return isGameWin;
    }
    public void GotoMenu()
    {
        SceneManager.LoadScene("Menu"); // Quay về menu chính
        Time.timeScale = 1; // Đảm bảo thời gian được tiếp tục khi trở về menu
    }
}
