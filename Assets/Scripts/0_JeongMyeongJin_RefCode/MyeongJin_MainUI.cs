using UnityEngine;

public class MyeongJin_MainUI : MonoBehaviour
{
    [SerializeField] private DaniTechUIButton Btn_MyProfile;
    [SerializeField] private DaniTechUIButton Btn_Option;
    [SerializeField] private DaniTechUIButton Btn_StartBattle;
    [SerializeField] private DaniTechUIButton Btn_OpenInfoBook;
    [SerializeField] private DaniTechUIButton Btn_Inventory;
    [SerializeField] private DaniTechUIButton Btn_MailBox;
    [SerializeField] private DaniTechUIButton Btn_Store;
    [SerializeField] private DaniTechUIButton Btn_Level;

    private void OnEnable()
    {
        Btn_MyProfile.BindOnClickButtonEvent(OnClick_OpenMyProfile);
        Btn_Option.BindOnClickButtonEvent(OnClick_OpenOption);
        Btn_StartBattle.BindOnClickButtonEvent(OnClick_StartBattle);
        Btn_OpenInfoBook.BindOnClickButtonEvent(OnClick_OpenInfoBook);
        Btn_Inventory.BindOnClickButtonEvent(OnClick_OpenInventory);
        Btn_MailBox.BindOnClickButtonEvent(OnClick_MailBox);
        Btn_Store.BindOnClickButtonEvent(OnClick_Store);
        Btn_Level.BindOnClickButtonEvent(OnClick_Level);


    }

    public void OnClick_OpenMyProfile()
    {
        Debug.Log("프로필이 열렸다");
    }

    public void OnClick_OpenOption()
    {
        Debug.Log("설정이 열렸다");
    }

    public void OnClick_StartBattle()
    {
        Debug.Log("전투 시작");

    }

    public void OnClick_OpenInfoBook() 
    {
        Debug.Log("도감이 열렸다");

    }

    public void OnClick_OpenInventory()
    {
        Debug.Log("인벤토리");

    }

    public void OnClick_MailBox()
    {
        Debug.Log("우편함이 열렸다");

    }

    public void OnClick_Store()
    {
        Debug.Log("상점이 열렸다");

    }

    public void OnClick_Level()
    {
        Debug.Log("난이도 설정");

    }
}
