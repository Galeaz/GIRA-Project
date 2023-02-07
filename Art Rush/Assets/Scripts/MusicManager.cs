using UnityEngine;

public class MusicManager : MonoBehaviour
{
    /* IT MADE THE MUSIC TOGGLE AND SLIDER USELESS
    //reference to itself
    private static MusicManager musicManagerInstance; //only one copy of this variable at the time so only 1 audio

    void Awake()
    {
        DontDestroyOnLoad(this); //this function will let the music sounds all the time not destroying

        if(musicManagerInstance == null)
        {
            musicManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }*/
}
