using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class FizzBuzz : MonoBehaviour
{
    int nValue;
    int fizzValue;
    int buzzValue;
    public float timeBetween;

    public TMP_InputField nValueInputField;
    public TMP_InputField fizzValueInputField;
    public TMP_InputField buzzValueInputField;

    string[] strArray;
    public TextMeshProUGUI outputText;

    /// <summary>
    /// tied to the "Start" button, starts the FizzBuzzMethod
    /// </summary>
    public void FizzBuzzStart()
    {
        outputText.text = "";
        nValue = Int32.Parse(nValueInputField.text);
        fizzValue = Int32.Parse(fizzValueInputField.text);
        buzzValue = Int32.Parse(buzzValueInputField.text);

        FizzBuzzMethod(nValue, fizzValue, buzzValue, outputText);
        //StartCoroutine(TextSlower(timeBetween));
    }

    /// <summary>
    /// logic to figure out what items should be fizz and which items should be buzz.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="xValue"></param>
    /// <param name="yValue"></param>
    /// <param name="outputDisplay"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    private void FizzBuzzMethod(int input, int xValue, int yValue, TextMeshProUGUI outputDisplay)
    {
        if(input < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        for(int i = 1; i < nValue; i++)
        {
            if (i % xValue == 0 && i % yValue == 0)
            {
                outputDisplay.text += "FizzBuzz ";
            }
            else if (i % xValue == 0)
            {
                outputDisplay.text += "Fizz ";
            }
            else if (i % yValue == 0)
            {
                outputDisplay.text += "Buzz ";
            }
            else
            {
                outputDisplay.text += i.ToString() + " ";
            }
        }
        strArray = outputDisplay.text.Split(' ');
        outputText.text = "";
        StartCoroutine(TextSlower(timeBetween));
    }

    /// <summary>
    /// slows down the time between outputs, can be set by the user in game
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    IEnumerator TextSlower(float time)
    {
        for (int i = 0; i < strArray.Length; i++)
        {
            outputText.text += strArray[i] + " ";
            yield return new WaitForSeconds(time);
        }
    }
}