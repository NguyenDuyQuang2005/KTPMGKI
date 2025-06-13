using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu1 : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game"); // Tải lại cảnh "Game"
    }
 public void QuitGame()
    {
        Application.Quit(); // Thoát ứng dụng   
    }
}
