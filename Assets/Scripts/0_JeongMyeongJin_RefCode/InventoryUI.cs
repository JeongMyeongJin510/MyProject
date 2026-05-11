using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public DaniTechUIButton Button_Close;

    private void OnEnable()
    {
        Button_Close.BindOnClickButtonEvent(OnClick_CloseSelf);
    }

    public void OnClick_CloseSelf()
    {
        DaniTechUIManager.Instance.CloseSpecificUI(DaniTechUIType.InventoryUI);
    }

}
