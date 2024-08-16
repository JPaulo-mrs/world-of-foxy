using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string nomeScene;

    public void trocaS()
    {
        SceneManager.LoadScene(nomeScene);
    } 
    public void sair()
    {
        Application.Quit();
    } 
}
