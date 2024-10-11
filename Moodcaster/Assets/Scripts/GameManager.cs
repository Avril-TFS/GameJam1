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
    public Text spellText;
    public Text victoryText;

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
    public void Victory()
    {
        Time.timeScale = 0;
        victoryText.text = "Congratulations!\n\nYou made it through the dungeon!";
        restartButton.gameObject.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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
    public void AngerSpellText()
    {
        spellText.text = "Emotion detected: Anger! Cast Iratus Ignis!";
    }
    public void DisgustSpellText()
    {
        spellText.text = "Emotion detected: Disgust! Cast Impulsum!";
    }
    public void FearSpellText()
    {
        spellText.text = "Emotion detected: Fear! Cast Noctis Timor!";
    }
    public void SadSpellText()
    {
        spellText.text = "Emotion detected: Sadness. Cast Lacrimae!";
    }
    public void HappySpellText()
    {
        spellText.text = "Emotion detected: Happiness. Cast Radiatus!";
    }
    public void ExcitedSpellText()
    {
        spellText.text = "Emotion detected: Excitement! Cast Celeritas!";
    }
}
