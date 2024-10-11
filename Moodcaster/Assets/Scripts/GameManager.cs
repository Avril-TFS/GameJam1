using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;

    public Text gameOverText;
    public Button restartButton;
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

        restartButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
    }
    public void UpdateHealth()
    {
        int playerHealth = playerController.health;

        healthText.text = "Health: " + playerHealth;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverText.text = "You Died!\n\n You'll never become a full fledge mage at this rate! Try again, but this time add some direction and magnitude!!!";
        restartButton.gameObject.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Debug.Log("Restart");
    }
}
