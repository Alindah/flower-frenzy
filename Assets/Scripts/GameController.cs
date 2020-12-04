using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This class takes care of UI stuff as well as the scoring system and win conditions.
 * 
 * Controls:
 * WASD/Arrow Keys: Move
 * Space: Pick up flowers. Interact with Eleanor.
 * R: Reset flowers.
 * Backspace: Discard basket.
 * 
 */
public class GameController : MonoBehaviour
{
    public PlayerClass player;
    public GameObject[] flowerArray;

    private int scoreCorrect;
    private int scoreIncorrect;

    private Text textScoreCorrect;
    private Text textScoreIncorrect;
    private Text textBasket;
    private Text textDialogue;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerClass>();

        textScoreCorrect = GameObject.Find("Correct").GetComponent<Text>();
        textScoreIncorrect = GameObject.Find("Incorrect").GetComponent<Text>();
        textBasket = GameObject.Find("Basket").GetComponent<Text>();
        textDialogue = GameObject.Find("Dialogue").GetComponent<Text>();

        flowerArray = GameObject.FindGameObjectsWithTag("Flower");

        ResetFlowers();
        ClearDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetFlowers();
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            player.ClearBasket();
            UpdateBasketText();
        }
    }

    public void DisplayScore()
    {
        Debug.Log("Your score is " + scoreCorrect + " : " + scoreIncorrect);
    }

    public void UpdateScore(int score)
    {
        if (score > 0)
        {
            scoreCorrect++;
            textScoreCorrect.text = scoreCorrect.ToString();
        }
        else
        {
            scoreIncorrect++;
            textScoreIncorrect.text = scoreIncorrect.ToString();
        }

        DisplayScore();
    }

    public void UpdateBasketText()
    {
        if (player.NumberOfFlowers == 0)
        {
            textBasket.text = player.NumberOfFlowers.ToString();
        }
        else
        {
            textBasket.text = player.FlowerType + " x " + player.NumberOfFlowers.ToString();
        }
    }

    public void ResetFlowers()
    {
        foreach (GameObject flower in flowerArray)
        {
            flower.GetComponent<FlowerController>().SetFlower();
        }

        SetDialogue("Let it rain! New flowers have grown.");
        //Debug.Log("Let it rain! New flowers have grown.");
    }

    public void SetDialogue(string dialogue)
    {
        textDialogue.text = dialogue;
    }

    public void ClearDialogue()
    {
        textDialogue.text = "";
        //Debug.Log("Dialogue cleared.");
    }
}
