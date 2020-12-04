using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerController : MonoBehaviour
{
    public PlayerClass player;
    public GameController game;

    private static System.Random rand;
    private int value;
    private Text textValue;

    void Start()
    {
        rand = new System.Random();
        player = GameObject.Find("Player").GetComponent<PlayerClass>();
        game = GameObject.Find("GameController").GetComponent<GameController>();
        textValue = GetComponentInChildren<Text>();

        //SetFlower();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textValue.color = Color.yellow;
            game.ClearDialogue();
        }
    }

    // Called when object touches trigger collider.
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log(name + " detects Chomper!");

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log("Chomper picked up " + name + " worth " + value);

                if (player.NumberOfFlowers == 0)
                {
                    player.FlowerType = value;
                }

                if (value == player.FlowerType)
                {
                    player.AddToBasket(value);
                    player.DisplayBasket();
                    game.UpdateBasketText();
                    this.gameObject.SetActive(false);
                    textValue.color = Color.white;
                }
                else
                {
                    game.SetDialogue("Chomper: I can only pick up flowers of the same type!");
                    Debug.Log("Chomper can only pick up flowers of the same type!");
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textValue.color = Color.white;
        }
    }

    public void SetFlower()
    {
        value = rand.Next(1, 13);
        
        if (!(this.gameObject.activeSelf))
        {
            this.gameObject.SetActive(true);
        }

        textValue.text = value.ToString();
    }
}
