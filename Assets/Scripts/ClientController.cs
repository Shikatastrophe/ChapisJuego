using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClientController : DropAreas
{
    /*
    List<int[]> recepies = new List<int[]>
    {
        new int[] { 0 }, // Example recipe: item IDs
        new int[] { 500 },
        new int[] { 1,4,0 }
    };
    
    */
    List<int[]> recepies = new List<int[]>
    {
        new int[] { 1,4,8,12,2,3,5,11,0, 10}, // Nanis 0
        new int[] { 1,4,8,12,9,13,2,3,5,11,0, 10}, //Junior 1
        new int[] { 1,4,8,12,9,6,2,3,5,11,0, 10}, //Fabis 2
        new int[] { 1,4,4,8,12,9,9,7,13,2,3,5,11,0, 10 }//La especial 3
    };
    /*

Ingredient ID List 

TopBun 0
BottomBun 1
Tomato 2
Onion 3
Meat 4
Lettuce 5
Pineapple 6
Oaxaca Cheese 7
Cheese 8
Bacon 9

French Fries 10

    mayonnaise 11
    ketchup 12
    guacamole 13

Raw/Burnt Meat 500

*/
    // public GameObject[] Clients;

    public int currentRecipeIndex = 0;

    public SpawnSistem spawnSistem;

    public PatienceSystem patience;

    public int NumOfClients = 10;

    public Sprite[] sprites;

    public SpriteRenderer RecipeWant;

    private void Start()
    {
        // Initialize the first client
        ChangeClient(-1);
        Invoke(nameof(ReturnRecipe), 3);
        RecipeWant.sprite = sprites[currentRecipeIndex];

    }

    public override void OnObjectDrop(DragAndDrop obj)
    {
        ServeBurger(obj);
    }

    public void ServeBurger(DragAndDrop obj)
    {
        if (obj.type == DragAndDrop.IngredientType.burger)
        {
            if (CheckRecipe(obj, currentRecipeIndex))
            {
                obj.Kill();
                CompleteOrder();

                //Debug.Log("Burger served!");
            }
            else
            {
                //Debug.Log("Wrong burger!");
                obj.ReturnToSender();
            }
        }
        else
        {
            //Debug.Log("Only burgers can be served!");
            obj.ReturnToSender();
        }
    }

    public void CompleteOrder()
    {
        Debug.Log("Order completed!");
        ChangeClient(currentRecipeIndex);
        spawnSistem.orderFinished = true;
        patience.orderCompleated = true;

        NumOfClients--;

        CheckForRemainingClients();

        RecipeWant.enabled = false;

        RecipeWant.sprite = sprites[currentRecipeIndex];

        Invoke(nameof(ReturnRecipe), 3);
    }

    public void CompleteOrder(DragAndDrop dragAndDrop)
    {
        if (CheckRecipe(dragAndDrop, currentRecipeIndex))
        {
            dragAndDrop.Kill();
            CompleteOrder();
        }
        else
        {
            Debug.Log("Wrong burger served to client!");
            //dragAndDrop.ReturnToSender();
        }

    }

    void ReturnRecipe()
    {
        RecipeWant.enabled = true;
    }

    public void CheckForRemainingClients()
    {
        if(NumOfClients <= 0)
        {
            SceneManager.LoadScene("Score");
        }
    }


    public void ChangeClient(int lastclient)
    {
        int random = UnityEngine.Random.Range(0, recepies.Count);
        currentRecipeIndex =  random;

        spawnSistem.SpawnCliente();

    }

    private bool CheckRecipe(DragAndDrop obj, int recipeID)
    {
        bool match = false;
        int[] burger = obj.recipe.ToArray();
        int[] recipe = recepies[recipeID];

        if (recipe.Length == burger.Length)
        {
            match = true;
            for (int i = 0; i < recipe.Length; i++)
            {
                if (recipe[i] != burger[i])
                {
                    match = false;

                }
            }

        }
        //Debug.Log("Recipe check: " + (match ? "Match!" : "No match!"));
        return match;
    }
}
