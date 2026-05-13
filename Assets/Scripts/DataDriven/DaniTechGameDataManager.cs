using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class DaniTechGameDataManager : MonoBehaviour
{
    public static DaniTechGameDataManager Instance { get; set; }

    private void Awake()
    {
        Instance = this;

        // +++ C# 콘솔때와 다르게 이제 Main()함수가 아닌
        // 모노의 메서드에서 호출될 수 있으므로, 데이터 매니저가 활성화되면 바로 모든 데이터를 한번 받아오자
        // 이처리는 원하는 시점이 있다면 이전해도 된다
        DaniTechGameUtil.LoadFullData();
    }

    // --- JsonUtility의 한계를 극복하기 위한 Wrapper 클래스 ---
    [Serializable]
    private class SerializationWrapper<T>
    {
        public List<T> items; // JSON 파일의 루트 키 이름이 "items"여야 함
    }
    // ---------------------------------------------------

    public Dictionary<string, DNCharacterData> CharacterDataList { get; private set; } = new Dictionary<string, DNCharacterData>();
    public Dictionary<string, DNSkillData> SkillDataList { get; private set; } = new Dictionary<string, DNSkillData>();
    public Dictionary<string, DNWeaponData> WeaponDataList { get; private set; } = new Dictionary<string, DNWeaponData>();
    public Dictionary<string, DNCostumeData> CostumeDataList { get; private set; } = new Dictionary<string, DNCostumeData>();
    public Dictionary<string, DNItemData> ItemDataList { get; private set; } = new Dictionary<string, DNItemData>();
    public Dictionary<string, DNDialogueGroupData> DialogueGroupDataList { get; private set; } = new Dictionary<string, DNDialogueGroupData>();
    public Dictionary<string, DNDialogueData> DialogueDataList { get; private set; } = new Dictionary<string, DNDialogueData>();


    private Dictionary<string, T> LoadData<T>(string jsonPath) where T : GameDataBase
    {
        if (!File.Exists(jsonPath))
        {
            Debug.LogError($"[Error] 파일을 찾을 수 없습니다: {jsonPath}");
            return new Dictionary<string, T>();
        }

        try
        {
            string jsonString = File.ReadAllText(jsonPath);

            // JsonUtility는 List<T>를 직접 못 가져오므로 Wrapper를 사용합니다.
            // 만약 JSON이 배열 형태([ {...}, {...} ])라면 아래 방식이 필요합니다.
            // 만약 JSON 구조가 { "items": [...] } 형태가 아니라면 
            // jsonString을 수정하여 강제로 감싸는 트릭을 써야 합니다.
            string wrappedJson = "{\"items\":" + jsonString + "}";
            SerializationWrapper<T> wrapper = JsonUtility.FromJson<SerializationWrapper<T>>(wrappedJson);

            if (wrapper != null && wrapper.items != null)
            {
                Debug.Log($"{typeof(T).Name} 데이터를 {wrapper.items.Count}개 로드했습니다.");
                return wrapper.items.ToDictionary(item => item.Id);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"[{typeof(T).Name} JSON 로드 오류] {ex.Message}");
        }

        return new Dictionary<string, T>();
    }

    public void LoadSkillData(string jsonPath)
    {
        SkillDataList = LoadData<DNSkillData>(jsonPath);
    }

    public void LoadCharacterData(string jsonPath)
    {
        CharacterDataList = LoadData<DNCharacterData>(jsonPath);
    }

    public void LoadWeaponData(string jsonPath)
    {
        WeaponDataList = LoadData<DNWeaponData>(jsonPath);
    }

    public void LoadCostumeData(string jsonPath)
    {
        CostumeDataList = LoadData<DNCostumeData>(jsonPath);
    }

    public void LoadDNItemData(string jsonPath)
    {
        ItemDataList = LoadData<DNItemData>(jsonPath);
    }

    public void LoadDNDialogueData()
    {
        DialogueGroupDataList = LoadData<DNDialogueGroupData>(DaniTechGameUtil.GetFullDataPath("DNDialogueGroup"));
        DialogueDataList = LoadData<DNDialogueData>(DaniTechGameUtil.GetFullDataPath("DNDialogue"));
    }


    // [아래는 사용을 위한 부분들을 메서드 정의] =========================================================================================
    // Get과 Find이름을 꼭 구별 하자!

    public DNCharacterData GetCharacterData(string id)
    {
        if (CharacterDataList == null || string.IsNullOrEmpty(id)) return null;

        return CharacterDataList.TryGetValue(id, out var item) ? item : null;
    }

    public DNSkillData GetSkill(string id)
    {
        if (SkillDataList == null || string.IsNullOrEmpty(id)) return null;

        return SkillDataList.TryGetValue(id, out var item) ? item : null;
    }

    public DNWeaponData GetWeaponData(string id)
    {
        if (WeaponDataList == null || string.IsNullOrEmpty(id)) return null;

        return WeaponDataList.TryGetValue(id, out var data) ? data : null;
    }

    public DNCostumeData GetCostumeData(string id)
    {
        if (CostumeDataList == null || string.IsNullOrEmpty(id)) return null;

        return CostumeDataList.TryGetValue(id, out var data) ? data : null;
    }

    public DNItemData GetDNItemData(string id)
    {
        if (ItemDataList == null || string.IsNullOrEmpty(id)) return null;

        return ItemDataList.TryGetValue(id, out var data) ? data : null;
    }

    public DNDialogueGroupData GetDNDialogueGroupData(string dataId)
    {
        if (DialogueGroupDataList == null || string.IsNullOrEmpty(dataId)) return null;

        return DialogueGroupDataList.TryGetValue(dataId, out var data) ? data : null;
    }

    public DNDialogueData GetDNDialogueData(string dataId)
    {
        if (DialogueDataList == null || string.IsNullOrEmpty(dataId)) return null;

        return DialogueDataList.TryGetValue(dataId, out var data) ? data : null;
    }
}