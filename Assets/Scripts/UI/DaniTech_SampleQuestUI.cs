using System.Collections.Generic;
using UnityEngine;

public class DaniTech_SampleQuestUI : MonoBehaviour
{
    [SerializeField] private GameObject Prefab_QuestSlot; // 나중에 에셋 로드로 변경될 수 있다!
    [SerializeField] private Transform Transform_QuestSlotUIRoot; // 퀘스트 슬롯을 Content라는 곳에 생성해야하기 때문에 이렇게 위치를 미리 등록해줄 수 있게 열어둔다.
    [SerializeField] private DaniTechUIButton Button_TestCreateSlot; // 받아온 퀘스트 목록에 따라 / 지금은 테스트니까 버튼 눌러질때로 슬롯 동적 생성
    [SerializeField] private DaniTechUIButton Button_CloseBack;
    [SerializeField] private DaniTechUIButton Button_CloseSelf;


    private List<DaniTech_SampleQuestSlotUI> _uiSlotList = new List<DaniTech_SampleQuestSlotUI>();


    private void Awake()
    {
        DestroySlotOnAwake();
    }

    private void DestroySlotOnAwake()
    {
        // 이거보단 컴포넌트를 찾는게 좀 더 낫긴 하다
        var destroyTargetComponentList = Transform_QuestSlotUIRoot.GetComponentsInChildren<DaniTech_SampleQuestSlotUI>();
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

        CreateQuestSlot("quest_main_1_1");
    }

    public void OnClick_ClosePopup()
    {
        // 우선은 이렇게 쓰지만, 결국 나중에 UIManager.Inst.CloseSpecificUI(UIType.QuestUI);처럼 UI매니저한테 요청하게 된다
        // 이렇게 닫는게 아니라 this.gameObject.SetActive(false); 아래 방법으로 공식적으로 닫아 줘야 한다
        DaniTechUIManager.Instance.ClosePopupUI(DaniTechUIType.QuestUI);
    }

    private void CreateQuestSlot(string questDataId)
    {
        // 1-1) 슬롯은 우선 생성되었다
        var gObj = Instantiate(Prefab_QuestSlot, Transform_QuestSlotUIRoot);
        if (gObj == null) return;

        // 2-1) 슬롯 게임오브젝트에서 우리가 필요한 관리할 컴포넌트를 꺼내와서 보관해두자!
        var slotComponent = gObj.GetComponent<DaniTech_SampleQuestSlotUI>();
        if(slotComponent == null) return;

        // 2-2) 슬롯 컴포넌트를 보관할 수 있다는건, 결국 그 컴포넌트가 들어가있는 GameObject도 보관 및 접근이 가능하다!
        _uiSlotList.Add(slotComponent);

        // 3-1) 이렇게 컴포넌트를 꺼내왔으면, 그 인스턴스 슬롯의 기능을 호출해서 그 게임오브젝트(UI)의 뭔가 상태를 변경하거나 수정 할 수 있다
            // 추후에는 이부분이 데이터드리븐과 함께 연동이 될 예정
        slotComponent.SetQuestSlot(questDataId);


        Debug.Log($"슬롯 생성됨 {_uiSlotList.Count}");
    }
}
