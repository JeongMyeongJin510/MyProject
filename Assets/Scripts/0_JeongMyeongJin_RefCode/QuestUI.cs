using System.Collections.Generic;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private GameObject Prefab_QuestSlot;
    [SerializeField] private Transform Transform_QuestSlotUIRoot;
    [SerializeField] private DaniTechUIButton Button_TestCreateSlot;
    [SerializeField] private DaniTechUIButton Button_CloseBack;
    [SerializeField] private DaniTechUIButton Button_CloseSelf;

    private List<QuestSlotUI> _uiSlotList = new List<QuestSlotUI>();




    private void Awake()
    {
        DestroySlotOnAwake();
    }

    private void DestroySlotOnAwake()
    {
        var destroyTargetComponentList = Transform_QuestSlotUIRoot.GetComponentsInChildren<QuestSlotUI>();
        foreach (var childTransform in destroyTargetComponentList)
        {
            if (childTransform.gameObject != null)
            {
                Destroy(childTransform.gameObject);
            }
        }
    }

    private void OnEnable()
    {
        Button_TestCreateSlot.BindOnClickButtonEvent(OnClick_TestCreateSlot);
        Button_CloseBack.BindOnClickButtonEvent(OnClick_ClosePopup);
        Button_CloseSelf.BindOnClickButtonEvent(OnClick_ClosePopup);

    }

    public void OnClick_TestCreateSlot()
    {
        Debug.LogWarning("눌러짐");

        CreateQuestSlot("quest_main_1-1");
    }

    public void OnClick_ClosePopup()
    {
        DaniTechUIManager.Instance.CloseContentUI(DaniTechUIType.QuestUI);
    }


    private void CreateQuestSlot(string questDataId)
    {
        var gObj = Instantiate(Prefab_QuestSlot, Transform_QuestSlotUIRoot);
        if (gObj == null) return;

        var slotComponent = gObj.GetComponent<QuestSlotUI>();
        if (slotComponent == null) return;

        _uiSlotList.Add(slotComponent);
        slotComponent.SetQuestSlot(questDataId);

        Debug.Log($"슬롯 생성{_uiSlotList.Count}");
    }
}
