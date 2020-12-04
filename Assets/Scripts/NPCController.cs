using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    public PlayerClass player;
    public GameController game;

    private int demand;
    private Text textValue;
    private string dialogue;
    private static System.Random rand;

    void Start()
    {
        dialogue = "";
        textValue = GetComponentInChildren<Text>();
        player = GameObject.Find("Player").GetComponent<PlayerClass>();
        game = GameObject.Find("GameController").GetComponent<GameController>();
        Order();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log(name + " detects Chomper!");

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (player.BasketValue == 0)
                {
                    dialogue = "Eleanor: I'm waiting! I want " + demand + "! >:(";
                    //Debug.Log("I'm waiting! I want " + demand + "!");
                }
                else
                {
                    if (player.BasketValue == demand)
                    {
                        game.UpdateScore(1);
                        dialogue = "Eleanor: That was perfect! Thank you! :)";
                        //Debug.Log("Thank you!");
                    }
                    else if (player.BasketValue > demand)
                    {
                        game.UpdateScore(-1);
                        dialogue = "Eleanor: Ugh. That was too many flowers. "
                                  + "I wanted " + demand + ", but you gave me "
                                  + player.BasketValue + ".";

                        /*Debug.Log("Ugh. That was too many flowers in one sitting.\n"
                                  + "I wanted " + demand + ", but you gave me " 
                                  + player.BasketValue + ".");*/
                    }
                    else
                    {
                        game.UpdateScore(-1);
                        dialogue = "Eleanor: Hey! That was too few flowers! "
                                  + "I wanted " + demand + ", but you gave me "
                                  + player.BasketValue + ".";
                        /*Debug.Log("Hey! That was too few flowers!\n"
                                  + "I wanted " + demand + ", but you gave me "
                                  + player.BasketValue + ".");*/
                    }

                    player.ClearBasket();
                    game.UpdateBasketText();
                    Order();
                }

                game.SetDialogue(dialogue);
            }
        }
    }

    public void Order()
    {
        rand = new System.Random();
        demand = rand.Next(1, 13) * rand.Next(1, 13);
        textValue.text = demand.ToString();
        //dialogue = "Hey Chomper, I'm craving " + demand + " worth of flowers.";
        Debug.Log("Hey Chomper, I'm craving " + demand + " worth of flowers.");
        //game.SetDialogue(dialogue);
    }

}