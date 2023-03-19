using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalOnlineMenu : MonoBehaviour
{
    //singleton
    public static LocalOnlineMenu LOM_instance;

    public GameObject local_Button;
    public GameObject online_Button;
    public GameObject goBack_Button;

    private void Awake()
    {
        LOM_instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true); //activates menu
    }

    public void PlayLocalGame()
    {
        SceneManager.LoadScene("Launcher"); //loads singleplayer game scene
    }

    public void PlayOnlineGame()
    {
        SceneManager.LoadScene("Multiplayer Game"); //loads singleplayer game scene
    }

    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu"); //loads singleplayer game scene
    }
}
