using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private TMP_Text healthText;
    private GameObject player;
    private int playerHealth;
    private HealthBase healthBase;


    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        healthText = GameObject.Find("HealthText").GetComponent<TMP_Text>();
        healthBase = player.GetComponent<HealthPlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = (int)player.GetComponent<HealthPlayer>().initHealth;
        healthText.text = playerHealth.ToString();

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Debug.Log("You win!");
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("EndScene");
            return;
        }
    }
}
