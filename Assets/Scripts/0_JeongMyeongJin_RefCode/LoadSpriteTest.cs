using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadSpriteTest : MonoBehaviour
{
    [SerializeField] private RawImage RawImage_LoadingImg;
    [SerializeField] private Slider Slider_LoadingBar;


    private void OnEnable()
    {
        LoadAndSetLoadingImg();
        StartCoroutine(CoStrartLoadingBarEffect());
    }

    private void LoadAndSetLoadingImg()
    {
        var texture = Resources.Load<Texture>("Texture/Texture_LoadingImage");
        if (texture != null)
        {
            RawImage_LoadingImg.texture = texture;
        }
    }

    IEnumerator CoStrartLoadingBarEffect()
    {
        Slider_LoadingBar.value = 0.2f;
        yield return new WaitForSeconds(0.3f);

        Slider_LoadingBar.value = 0.4f;

        yield return new WaitForSeconds(0.5f);

        Slider_LoadingBar.value = 0.7f;

        yield return new WaitForSeconds(1.0f);

        Slider_LoadingBar.value = 1.0f;

        yield return new WaitForSeconds(1.3f);


        this.gameObject.SetActive(false);

    }
}
