using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private AlertTrigger _alertTrigger;
    [SerializeField] private Alert _alert;

    private void OnEnable()
    {
        _alertTrigger.ThiefCame += CallMethodsOnThiefEntry;
        _alertTrigger.ThiefLeft += CallMethodsOnThiefExit;
    }

    private void OnDisable()
    {
        _alertTrigger.ThiefCame -= CallMethodsOnThiefEntry;
        _alertTrigger.ThiefLeft -= CallMethodsOnThiefExit;
    }

    private void CallMethodsOnThiefEntry()
    {
        _alert.TurnOnAlert();
    }

    private void CallMethodsOnThiefExit()
    {
        _alert.TurnOffAlert();
    }
}
