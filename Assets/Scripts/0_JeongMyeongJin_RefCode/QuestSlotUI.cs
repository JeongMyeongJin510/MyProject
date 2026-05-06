using UnityEngine;
using UnityEngine.UI;

public class QuestSlotUI : MonoBehaviour
{
    [SerializeField] private Text Text_QuestName;
    [SerializeField] private Text Text_QuestDescription;

    [SerializeField] private DaniTechUIButton Button_AcceptQuest;
    [SerializeField] private DaniTechUIButton Button_CancelQuest;

    private void OnEnable()
    {
        Button_AcceptQuest.BindOnClickButtonEvent(OnClick_AcceptQuest);
        Button_CancelQuest.BindOnClickButtonEvent(OnClick_CancelQuset);
    }

    public void SetQuestSlot(string questDataId)
    {
        Text_QuestName.text = questDataId;


    }

    public void OnClick_AcceptQuest()
    {
        Debug.LogWarning("퀘스트를 수락했습니다.");
    }

    public void OnClick_CancelQuset()
    {
        Debug.LogWarning("퀘스트를 취소했습니다.");
    }
}


