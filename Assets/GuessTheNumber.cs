using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GuessTheNumber : MonoBehaviour
{
    [SerializeField]
    private TMP_Text header;
    [SerializeField]
    private TMP_InputField playerInput;
    [SerializeField]
    private GameObject error;

    private int  randNum, attempt;
    private int[] guessedNumbers;
    private void Start()
    {
        GameSetup();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (error.activeInHierarchy)
            {
                CloseError();
                playerInput.ActivateInputField();
                return;
            }
            if (!playerInput.text.Equals(""))
            {
                SubmitGuess();
                if (attempt != 0)
                {
                    playerInput.ActivateInputField();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameSetup();
        }
    }

    public void SubmitGuess()
    {
        if (attempt != 0)
        {
            try
            {
                int guess = int.Parse(playerInput.text);
                if (guess <= 0 || guess > 10)
                {
                    error.SetActive(true);
                    return;
                }

                if (guessedNumbers.Contains(guess))
                {
                    header.SetText("You already guessed this number!");
                    return;
                }

                attempt--;
                guessedNumbers[attempt] = guess;

                if (guess != randNum)
                {
                    header.SetText("Incorrect! You have " + attempt + " attempt remaining");
                }
                else
                {
                    header.SetText("You won!");
                    attempt = 0;
                    return;
                }
                
                if (attempt == 0)
                {
                    header.SetText("You lose! Better luck next time.");
                }
            }
            catch
            {
                error.SetActive(true);
            }
        }
    }
    public void CloseError()
    {
        error.SetActive(false);
    }
    public void GameSetup()
    {
        CloseError();
        guessedNumbers = new int[3] { -1, -1, -1 };
        randNum = Random.Range(1, 10);
        attempt = 3;
        playerInput.text = "";
        header.SetText("I'm thinking of a number between 1 and 10. You have 3 attempts to guess it...");
        playerInput.ActivateInputField();
    }
}
