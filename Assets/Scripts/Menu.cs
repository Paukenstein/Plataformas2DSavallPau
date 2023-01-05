using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public LifeControlller lifes;
    public int current_lifes;
    public TextMeshProUGUI vidas;
    public bool win = false;
    public GameObject victoria;
    private void Start()
    {
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game"|| SceneManager.GetActiveScene().name == "Gim")
        {
            current_lifes = lifes.lifes_current;
            vidas.text = current_lifes.ToString("00");

        }
        if (win)
        {
            StartCoroutine(Win_Courutine());
        }
    }
    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();

    }
    
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    IEnumerator Win_Courutine()
    {
        victoria.SetActive(true);
        yield return new WaitForSeconds(5);
        victoria.SetActive(false);
        SceneManager.LoadScene("MenuPrincipal");




    }
   
}