using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class TextSlicer : MonoBehaviour
{
    [SerializeField] private int numberOfCharPerLine;
    private string _currentRow;

    public List<string> Slice(string textToSlice)
    {
        List<string> slicedText = new List<string>();
        int index = 0;
        string currentSelection = null;

        foreach(char c in textToSlice) // travel through each character in string
        {
            if (index >= numberOfCharPerLine && (c == '.' || c == '?' || c == '!'))
            {
                currentSelection += c;
                slicedText.Add(currentSelection);
                textToSlice.Replace(currentSelection, "");
                index = 0;
                currentSelection = null;
            }
            else if (index >= numberOfCharPerLine)
            {
                currentSelection += c;
                index++;
            }
            else
            {
                currentSelection += c;
                index++;
            }
        }
        if(currentSelection != null)
        {
            slicedText.Add(currentSelection);
        }
        
        return slicedText;
    }
}
