using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typer : MonoBehaviour
{
    public Text wordOutput = null;

    private string remainingWord = string.Empty;
    private string currentWord = "word";
  
 
    void Start()
    {
        SetCurrentWord();
    }


    private void SetCurrentWord()
    {
        SetRemainingWord(currentWord);
    }
    
    private void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = remainingWord;

    }


    void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if(Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if (keysPressed.Length == 1)
                EnterLetter(keysPressed);
        }
    }

    private void EnterLetter(string typedLetter)
    {
        if(IsCorrectLetter(typedLetter))
        {
            RemoveLetter();

            if(IsWordCorrect())
            {
                SetCurrentWord();
            }
        }

    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;

    }

    private bool IsWordCorrect()
    {
        return remainingWord.Length == 0;
    }

    private void RemoveLetter()
    {
        string newString = remainingWord.Remove(0,1);
        SetRemainingWord(newString);
    }
}
