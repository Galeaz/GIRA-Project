using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderUI : MonoBehaviour
{
    //Props
    [SerializeField]
    private Sprite appleProp;
    [SerializeField]
    private Sprite duckProp;
    [SerializeField]
    private Sprite candleProp;
    [SerializeField]
    private Sprite iceProp;
    /*[SerializeField]
    private Sprite vaseProp;*/

    //Colors
    [SerializeField]
    private Sprite blueColor;
    [SerializeField]
    private Sprite redColor;
    [SerializeField]
    private Sprite yellowColor;

    public enum PropType
    {
        Apple,
        Duck,
        Candle,
        Ice,
        Vase
    }

    public enum ColorType
    {
        Blue,
        Red,
        Yellow
    }

    private SpriteRenderer propSpriteRenderer;
    private SpriteRenderer colorSpriteRenderer;

    private void Start()
    {
        propSpriteRenderer = GetComponent<SpriteRenderer>();
        colorSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void showOrderUI(int prop_wanted, int color_wanted)
    {
        //selecting proper prop
        switch (prop_wanted)
        {
            case 0:
                propSpriteRenderer.sprite = appleProp;
                break;
            case 1:
                propSpriteRenderer.sprite = duckProp;
                break;
            case 2:
                propSpriteRenderer.sprite = candleProp;
                break;
            case 3:
                propSpriteRenderer.sprite = iceProp;
                break;
            /*case 4:
                propSpriteRenderer.sprite = vaseProp;
                break;*/
            default:
                Debug.Log("PROP ERROR: GIVING APPLE");
                propSpriteRenderer.sprite = appleProp;
                break;
        }

        //selecting proper color
        switch (color_wanted)
        {
            case 0:
                colorSpriteRenderer.sprite = blueColor;
                break;
            case 1:
                colorSpriteRenderer.sprite = redColor;
                break;
            case 2:
                colorSpriteRenderer.sprite = yellowColor;
                break;
            default:
                Debug.Log("COLOR ERROR: GIVING BLUE");
                colorSpriteRenderer.sprite = blueColor;
                break; 
        }
    }
}
