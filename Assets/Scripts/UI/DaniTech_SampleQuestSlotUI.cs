using UnityEngine;
using UnityEngine.UI;

public class DaniTech_SampleQuestSlotUI : MonoBehaviour
{
    [SerializeField] private Text Text_QuestName;
    [SerializeField] private Text Text_QuestDescription;

    [SerializeField] private DaniTechUIButton Button_AcceptQuest;
    [SerializeField] private DaniTechUIButton Button_CancelQuest;

    private void OnEnable()
    {
        Button_AcceptQuest.BindOnClickButtonEvent(OnClick_AcceptQuest);
        Button_CancelQuest.BindOnClickButtonEvent(OnClick_CancelQuest);
    }

    public void SetQuestSlot(string questDataId)
    {
        // 나중에 데이터 찾아서 여기서 퀘스트 이름이라던가, 설명을 띄워 준다
        Text_QuestName.text = questDataId;
        // Text_QuestDescription
    }

    public void OnClick_AcceptQuest()
    {
        Debug.LogWarning("퀘스트를 수락했습니다.");
    }

    public void OnClick_CancelQuest()
    {
        Debug.LogWarning("퀘스트를 취소했습니다.");
    }



}
