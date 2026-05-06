using UnityEngine;
using UnityEngine.UI; // UGUI에 있는 애들을 쓰려면 Using 추가

public class ProfilePopupUI : MonoBehaviour
{
    public Text PlayerName;
    public Text PlayerLevel;
    public DaniTechUIButton Button_Close;
    // public Button Button_Colse2;
    // [SerializeField] private DaniTechUIButton Button_Close; // 똑같은 코드

    private void OnEnable()
    {
        ChangeCharacterInfo("홍길동", 30);

        Button_Close.BindOnClickButtonEvent(OnClick_CloseSelf);
    }

    public void ChangeCharacterInfo(string characterName, int characterLevel)
    {
        PlayerName.text = $"캐릭터 이름 : {characterName}";
        PlayerLevel.text = $"캐릭터 레벨 : Lv.{characterLevel}";
    }


    public void OnClick_CloseSelf()
    {
        DaniTechUIManager.Instance.CloseSpecificUI(DaniTechUIType.TestProfile);

    }
}
