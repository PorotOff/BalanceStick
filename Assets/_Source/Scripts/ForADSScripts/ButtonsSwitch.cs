using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsSwitch : MonoBehaviour
{
    [SerializeField] private List<Button> buttons = new List<Button>();
    [SerializeField] private List<ButtonActivationsCounter> buttonsActivationsCounters = new List<ButtonActivationsCounter>();

    public void DisableButtons()
    {
        foreach (var button in buttons) button.interactable = false;
    }
    public void EnableButtons()
    {
        if (buttonsActivationsCounters[(int)ButtonsNames.getExtraLife].PossibleActivationsCount > 0)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                if (buttonsActivationsCounters[i].PossibleActivationsCount > 0)
                {
                    buttons[i].interactable = true;
                }
            }
        }
    }

    private enum ButtonsNames
    {
        makeStickShorter,
        getExtraLife
    }
}
