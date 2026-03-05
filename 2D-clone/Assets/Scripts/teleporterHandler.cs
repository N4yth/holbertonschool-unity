using UnityEngine;

public class teleporterHandler : MonoBehaviour
{
    [SerializeField] private int requiredSwitches = 1;

    private int currentSwitches = 0;

    public void ActivateSwitch()
    {
        currentSwitches++;

        CheckDoor();
    }

    public void DeactivateSwitch()
    {
        currentSwitches--;

        CheckDoor();
    }

    private void CheckDoor()
    {
        if (currentSwitches >= requiredSwitches)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        gameObject.SetActive(false);
    }

    void CloseDoor()
    {
        gameObject.SetActive(true);
    }
}