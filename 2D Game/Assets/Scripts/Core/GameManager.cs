using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameOver = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) || Input.GetMouseButtonDown(2) ){
            // Restart the game
            RestartGame();
        }
    }
    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over!");
    }

    public void RestartGame()
    {
        isGameOver = false;
        PlayerController.Instance.isAlive = true;
        Debug.Log("Game Restarted!");
        SceneManager.LoadScene("Game");
    }


}
