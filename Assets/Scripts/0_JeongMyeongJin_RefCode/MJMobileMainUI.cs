using UnityEngine;
using UnityEngine.UI;

public class MJMobileMainUI : MonoBehaviour
{
    public Text Text_PlayerName;
    public Text Text_PlayerLevel;
    public DaniTechUIButton Button_StartCommand;
    public DaniTechUIButton Button_OpenQuest;
    public DaniTechUIButton Button_Profile;
    public DaniTechUIButton Button_Contributiveness;
    public DaniTechUIButton Button_Inventory;



    private void OnEnable()
    {
        Text_PlayerName.text = "춘식이";
        Text_PlayerLevel.text = "LV.3";
        Button_StartCommand.BindOnClickButtonEvent(OnClick_StartCommand);
        Button_OpenQuest.BindOnClickButtonEvent(OnClick_OpenQuest);
        Button_Profile.BindOnClickButtonEvent(OnClick_Profile);
        Button_Contributiveness.BindOnClickButtonEvent(OnClick_Contributiveness);
        Button_Inventory.BindOnClickButtonEvent(OnClick_OpenInventory);


    }


    public void OnClick_StartCommand()
    {
        GameDataTester.StartDataTest();
    }

    public void OnClick_OpenQuest()
    {
        DaniTechUIManager.Instance.OpenPopupUI(DaniTechUIType.QuestUI);
    }

    public void OnClick_Profile()
    {
        DaniTechUIManager.Instance.OpenTestProfile();
    }

    public void OnClick_Contributiveness()
    {
        DaniTechGameManager.Inst.PlayerContributiveness(100);
    }

    public void OnClick_OpenInventory()
    {
        DaniTechUIManager.Instance.OpenInventory();
    }
}