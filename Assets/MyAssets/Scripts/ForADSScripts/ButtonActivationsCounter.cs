using UnityEngine;
using UnityEngine.UI;

public class ButtonActivationsCounter : MonoBehaviour
{
    [SerializeField] private int maxActivationsCount = 2;
    public int PossibleActivationsCount { get; private set; }
    [SerializeField] private Text activationsCounter;

    private void Start()
    {
        PossibleActivationsCount = maxActivationsCount;
    }

    public void ReducePossibleActivationsCount()
    {
        PossibleActivationsCount--;
        ShowActivationsCount();
    }
    private void ShowActivationsCount()
    {
        string newMessage = activationsCounter.text;
        newMessage = newMessage.Remove(0, 1).Insert(0, PossibleActivationsCount.ToString());
        newMessage = newMessage.Remove(newMessage.Length - 1, 1).Insert(newMessage.Length - 1, maxActivationsCount.ToString());
        activationsCounter.text = newMessage;
    }
}