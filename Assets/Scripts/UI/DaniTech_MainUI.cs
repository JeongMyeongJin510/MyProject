using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DaniTech_MainUI : MonoBehaviour
{
    public void OnClick_PopupSimpleMsg()
    {
        DaniTechUIManager.Instance.OpenSimplePopup("심플 팝업 출력 됨");

    }
}
