using System.Collections.Generic;
using UnityEngine;

public class ChangingBackgroundColor : MonoBehaviour
{
    private Camera gameCamera;
    [SerializeField]
    private List<string> hexColors = new List<string>();
    private List<string> usedHexColors = new List<string>();

    private void Awake() => gameCamera = GetComponent<Camera>();

    private void OnEnable() => ScoreDivideEvent.ScoreDivided += SetRandomColor;
    private void OnDisable() => ScoreDivideEvent.ScoreDivided -= SetRandomColor;

    private void SetRandomColor()
    {
        Color color;
        int randomIndex;
        string randomHexColor = "";

        for (int colorIndex = 0; colorIndex < hexColors.Count; colorIndex++)
        {
            if (!IsUsedColor(colorIndex))
            {
                randomIndex = Random.Range(0, hexColors.Count);
                randomHexColor = hexColors[randomIndex];
            }
        }

        ColorUtility.TryParseHtmlString(randomHexColor, out color);
        gameCamera.backgroundColor = color;
    }
    private bool IsUsedColor(int colorsListIndex)
    {
        bool isColorUsed = false;

        for (int i = 0; i < usedHexColors.Count; i++)
        {
            if (hexColors[colorsListIndex] == usedHexColors[i])
            {
                isColorUsed = true;
                break;
            }
        }

        return isColorUsed;
    }
}
