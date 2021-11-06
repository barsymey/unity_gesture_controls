using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void OpenMenu()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void CloseMenu()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    void Start()
    {
        gameObject.SetActive(false);
    }
}
