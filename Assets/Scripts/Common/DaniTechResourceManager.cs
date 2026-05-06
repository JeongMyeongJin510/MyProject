using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class DaniTechResourceManager : MonoBehaviour
{
    public static DaniTechResourceManager Inst { get; set; }

    private void Awake()
    {
        Inst = this;
    }

    // 로드된 에셋들을 관리하기 위한 캐시 (메모리 해제 시 필요)
    private Dictionary<string, AsyncOperationHandle> _handles = new Dictionary<string, AsyncOperationHandle>();

    // 1. 에셋 로드 함수 (제네릭 사용)
    public void LoadAsset<T>(string address, System.Action<T> callback) where T : UnityEngine.Object
    {
        // 이미 로드된 에셋인지 확인
        if (_handles.TryGetValue(address, out AsyncOperationHandle handle))
        {
            callback?.Invoke(handle.Result as T);
            return;
        }

        // 어드레서블 로드 실행
        AsyncOperationHandle<T> loadHandle = Addressables.LoadAssetAsync<T>(address);

        // 비동기 처리를 위한 한시적 람다 사용
        loadHandle.Completed += (op) =>
        {
            if (op.Status == AsyncOperationStatus.Succeeded)
            {
                _handles[address] = op; // 핸들 저장
                callback?.Invoke(op.Result);
            }
            else
            {
                Debug.LogError($"에셋 로드 실패: {address}");
            }
        };
    }

    // 2. 프리팹 생성 함수
    public void Instantiate(string address, Transform parent = null)
    {
        Addressables.InstantiateAsync(address, parent).Completed += (op) =>
        {
            if (op.Status != AsyncOperationStatus.Succeeded)
                Debug.LogError($"프리팹 생성 실패: {address}");
        };
    }

    // 2-1. 스프라이트 로드 함수
    public void LoadSprite(string address, System.Action<Sprite> callback)
    {
        // 이미 로드된 스프라이트인지 확인 (캐시 활용)
        if (_handles.TryGetValue(address, out AsyncOperationHandle handle))
        {
            callback?.Invoke(handle.Result as Sprite);
            return;
        }

        // 스프라이트 형식으로 로드
        AsyncOperationHandle<Sprite> handleOrigin = Addressables.LoadAssetAsync<Sprite>(address);

        handleOrigin.Completed += (op) =>
        {
            if (op.Status == AsyncOperationStatus.Succeeded)
            {
                _handles[address] = op; // 핸들 저장 (나중에 Release하기 위함)
                callback?.Invoke(op.Result);
            }
            else
            {
                Debug.LogError($"스프라이트 로드 실패: {address}");
            }
        };
    }

    // 3. 메모리 해제 함수 (중요!)
    public void Release(string address)
    {
        if (_handles.TryGetValue(address, out AsyncOperationHandle handle))
        {
            Addressables.Release(handle);
            _handles.Remove(address);
            Debug.Log($"에셋 메모리 해제 완료: {address}");
        }
    }
}
