using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    [SerializeField] Sprite[] select;
    SpriteRenderer thisSprite;

    private void Awake()
    {
        thisSprite = GetComponent<SpriteRenderer>();
        thisSprite.sprite = select[PlayerPrefs.GetInt("SpritePlayer", 0)];
    }
}
