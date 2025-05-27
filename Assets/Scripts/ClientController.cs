using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ClientController : DropAreas
{
    List<int[]> recepies = new List<int[]>
    {
        new int[] { 0 }, // Example recipe: item IDs
        new int[] { 500 },
        new int[] { 1,4,0 }
    };
    
    List<int[]> Truerecepies = new List<int[]>
    {
        new int[] { 1,4,8,12,9,4,3,5,11,0 }, // Example recipe: item IDs
        new int[] { 1,4,8,12,9,13,4,3,5,11,0 },
        new int[] { 1,4,8,12,9,6,4,3,5,11,0}
    };
    /*

Ingredient ID List 

BottomBun 1
TopBun 0
Meat 2
Onion 3
Tomato 4
Lettuce 5
Pineapple 6
Oaxaca Cheese 7
Cheese 8
Bacon 9

French Fries 10

    mayonnaise 11
    ketchup 12
    guacamole 13

Raw/Burnt Meat 50

*/
    // public GameObject[] Clients;

    public int currentRecipeIndex = 0;

    public SpawnSistem spawnSistem;

    private void Start()
    {
        // Initialize the first client
        ChangeClient(-1);
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
                ChangeClient(currentRecipeIndex);
                spawnSistem.orderFinished =  true;
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

    public void ChangeClient(int lastclient)
    {
        int random = UnityEngine.Random.Range(0, recepies.Count);
        currentRecipeIndex =  random;

        spawnSistem.SpawnCliente();
        /*
        if (lastclient < Clients.Length - 1)
        {
            lastclient++;
        }
        else
        {
            //currentRecipeIndex = random;
            lastclient = 0;
        }
        //Debug.Log("Current recipe index: " + currentRecipeIndex);
        //Debug.Log("Last client: " + lastclient);
        // Set the new client active
        for (int i = 0; i < Clients.Length; i++)
        {
            Clients[i].SetActive(i == lastclient);
        }
        */
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
