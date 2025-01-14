using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerManager1 : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;
    public GameObject settingMenuScreen;
    public GameObject panelMove;
    public GameObject panelJump;
    public GameObject panelAttack;
    public GameObject panelHealth;
    public GameObject panelPause;

    public static Vector2 lastCheckPointPos = new Vector2(-7, 0);

    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;

    private PlayerControls playerControls;

    private void Awake()
    {
        // Save coin
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        // Save coin end
        isGameOver = false;
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;

        playerControls = new PlayerControls();
        playerControls.Land.Pause.performed += OnPause;
    }

    private void OnEnable()
    {
        playerControls.Land.Enable();
    }

    private void OnDisable()
    {
        playerControls.Land.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(numberOfCoins);
        coinsText.text = numberOfCoins.ToString();
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void settingScreenActive()
    {
        settingMenuScreen.SetActive(true);
        pauseMenuScreen.SetActive(false);
    }

    public void settingScreenDeActive()
    {
        pauseMenuScreen.SetActive(true);
        settingMenuScreen.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Move()
    {
        panelMove.SetActive(false);
        panelMove.SetActive(false);
    }

    public void Jump()
    {
        panelJump.SetActive(false);
        panelAttack.SetActive(true);
    }

    public void Attack()
    {
        panelAttack.SetActive(false);
        panelHealth.SetActive(true);
    }

    public void Health()
    {
        panelHealth.SetActive(false);
        panelPause.SetActive(true);
    }

    public void Pause()
    {
        panelPause.SetActive(false);
    }

    public void ExitGame()
    {
        // This will work only in built application, not in editor
        Application.Quit();
#if UNITY_EDITOR
        // If in the editor, stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        PauseGame();
    }
}