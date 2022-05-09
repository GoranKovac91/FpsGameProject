using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource _backGroundMusic;
    [SerializeField] private Canvas _takingDamageCanvas;
    [SerializeField] private Text _bulletsText;
    [SerializeField] private Text _hpText;
    [SerializeField] private Canvas _gamePlayCanvas;
    [SerializeField] private Canvas _gameEndCanvas;
    [SerializeField] private Canvas _levelFailedCanvas;
    [SerializeField] private Camera _levelFailedCamera;
    [SerializeField] private  Canvas _levelPausedCanvas;
    [SerializeField] private Canvas _gameStartCanvas;
    [SerializeField] public float _time = 5.0f;
    public PlayerInteractions playerInteractions;
    public Rifle weapon;
    [SerializeField] private int _bullets = Rifle._bullets;
    [SerializeField] private int _bulletsToRealod = Rifle._bulletsToReload;
    [SerializeField] public MouseLooker mouseLooker;
    [SerializeField] public Pistol pistol;
    [SerializeField] public Rifle rifle;
    [SerializeField] public FpsMouse mouse;
    

    private void Awake()
    {
        _gameEndCanvas.enabled = false;
        _takingDamageCanvas.enabled = false;
        _gameStartCanvas.enabled = true;        
        _backGroundMusic.Play();
        _gamePlayCanvas.enabled = true;
        _levelFailedCanvas.enabled = false;
        _levelFailedCamera.enabled = false;
        _levelPausedCanvas.enabled = false;
        UpdateBullets(_bullets, _bulletsToRealod);
        mouseLooker = FindObjectOfType<MouseLooker>();
        pistol = FindObjectOfType<Pistol>();
        rifle = FindObjectOfType<Rifle>();
        mouse = FindObjectOfType<FpsMouse>();             
    }
 

    private void Update()
    {
        _time -= Time.deltaTime;
        if (_time<=0)
        {
            _gameStartCanvas.enabled = false;
        }

        if (Input.GetButtonDown("Cancel")&&_levelFailedCanvas.enabled==false)
        {
            PauseGame();
        }
        
        _hpText.text = "HP" + playerInteractions.Health.ToString("F0");
        

    }

    public void TakingDamageCanvas(bool value)
    {
        if (value == true)
        {
            _takingDamageCanvas.enabled = true;
        }
        else
        {
            _takingDamageCanvas.enabled = false;
        }

    }
    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel()
    {
        UnPauseGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ContinueGame()
    {
        UnPauseGame();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LevelFailed()
    {
        _levelFailedCamera.enabled = true;
        _levelFailedCanvas.enabled = true;    
    }
    public void UpdateBullets(int current, int max)
    {
        _bulletsText.text = current.ToString() + "/" + max.ToString();
    }
    public void PauseGame()
    {
        Cursor.visible = true ;
        Cursor.lockState = CursorLockMode.None;
        _levelPausedCanvas.enabled = true;
        mouse.enabled = false;
        //pistol.enabled = false;
        //rifle.enabled = false;
        Time.timeScale = 0;       
    }
    public void UnPauseGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _levelPausedCanvas.enabled = false;
        mouse.enabled = true;
        //pistol.enabled = true;
        //rifle.enabled = true;
        Time.timeScale = 1;    
    }
    public void EndGame()
    {
        _gameEndCanvas.enabled = true;
    }
      
}
