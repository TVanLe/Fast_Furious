using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
   public void SetSprite(int index)
    {
        PlayerPrefs.SetInt("SpritePlayer", index);
    }
}
