using UnityEngine;

public class MusicManager : MonoBehaviour
{

    //reference to itself
    private static MusicManager musicManagerInstance; //only one copy of this variable at the time so only 1 audio

    void Start()
    {
        musicManagerInstance = GameObject.FindObjectOfType<MusicManager>(); //finding audio in hierarchy
    }

    void Awake()
    {
        DontDestroyOnLoad(this); //this function will let the music sounds all the time not destroying

        //keeping only 1 audio in game
        if (musicManagerInstance == null) 
        {
            musicManagerInstance = this; //no audio then create
        }
        else
        {
            Destroy(gameObject); //there is audio then destroy new one
        }
    }
}
