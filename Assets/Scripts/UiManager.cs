using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public Text bulletCount;
    public Text playerScore_txt;
    public Image healthBar;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void ShowBulletCount(int count)
    {
        bulletCount.text = $"Bullet:{count}";
    }
    public void ShowScore(int point)
    {
        playerScore_txt.text = $"Score:{point}";
    }

    public void ShowHealthBar(float health)
    {
        healthBar.fillAmount = health;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetMouseButton(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
