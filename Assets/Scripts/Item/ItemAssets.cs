using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance {  get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    public Sprite maskSprite30;
    public Sprite clothSprite30;
    public Sprite gloveSprite30;
    public Sprite bootsSprite30;

    public Sprite maskSprite20;
    public Sprite clothSprite20;
    public Sprite gloveSprite20;
    public Sprite bootsSprite20;

    public Sprite maskSprite10;
    public Sprite clothSprite10;
    public Sprite gloveSprite10;
    public Sprite bootsSprite10;
}
