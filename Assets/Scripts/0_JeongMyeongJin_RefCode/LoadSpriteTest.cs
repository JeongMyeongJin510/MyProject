using UnityEngine;
using UnityEngine.UI;

public class LoadSpriteTest : MonoBehaviour
{
    [SerializeField] private Image Image_LoadSampleTest;

    private void OnEnable()
    {
        Sprite loadedSprite = Resources.Load<Sprite>("2D/Background");
        if (loadedSprite != null)
        {
            Image_LoadSampleTest.sprite = loadedSprite;
        }


    }
}
