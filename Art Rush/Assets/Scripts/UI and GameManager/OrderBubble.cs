using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderBubble : MonoBehaviour
{
    public static void Create(Transform parent, Vector3 localPosition, PropType propType, ColorType colorType)
    {
        Transform orderBubbleTransform = Instantiate(CustomerSpawner.inst.publicFieldOrderBubble, parent);
        orderBubbleTransform.localPosition = localPosition;

        orderBubbleTransform.GetComponent<OrderBubble>().Setup(propType, colorType);
    }

    [SerializeField]
    private Sprite appleProp;
    [SerializeField]
    private Sprite duckProp;
    [SerializeField]
    private Sprite candleProp;
    [SerializeField]
    private Sprite iceProp;
    [SerializeField]
    private Sprite vaseProp;

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

    private SpriteRenderer backgroundSpriteRenderer;
    private SpriteRenderer propSpriteRenderer;
    private SpriteRenderer colorSpriteRenderer;

    private void Awake()
    {
        backgroundSpriteRenderer = transform.Find("Background").GetComponent<SpriteRenderer>();
        propSpriteRenderer= transform.Find("Prop").GetComponent<SpriteRenderer>();
        colorSpriteRenderer = transform.Find("Color").GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        Setup(PropType.Apple, ColorType.Blue);
    }

    private void Setup (PropType prop_wanted, ColorType color_wanted)
    {
        propSpriteRenderer.sprite = GetPropSprite(prop_wanted);
        colorSpriteRenderer.sprite = GetColorSprite(color_wanted);
    }

    private Sprite GetPropSprite(PropType propType)
    {
        switch(propType)
        {
            case PropType.Apple:
                return appleProp;
            case PropType.Duck:
                return duckProp;
            case PropType.Candle:
                return candleProp;
            case PropType.Ice:
                return iceProp;
            case PropType.Vase:
                return vaseProp;
            default:
                Debug.Log("PROP ERROR: GIVING APPLE");
                return appleProp;
        }
    }

    private Sprite GetColorSprite(ColorType colorType)
    {
        switch (colorType)
        {
            case ColorType.Blue:
                return blueColor;
            case ColorType.Red:
                return redColor;
            case ColorType.Yellow:
                return yellowColor;
            default:
                Debug.Log("COLOR ERROR: GIVING BLUE");
                return blueColor;
        }
    }

    void Update()
    {
        
    }
}
