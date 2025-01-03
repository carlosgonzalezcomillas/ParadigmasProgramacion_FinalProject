using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayMenu : MonoBehaviour
{
    [SerializeField] private GameObject howButton;
    [SerializeField] private GameObject commandsMenu;

    public void Help()
    {
        howButton.SetActive(false);
        commandsMenu.SetActive(true);
    }

    public void Back()
    {
        howButton.SetActive(true);
        commandsMenu.SetActive(false);
    }

}
