using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    private static RecipeManager instance;

    public static RecipeManager Instance {  get { return instance; } }
    
    public Stack<int> playerRecipe = new Stack<int>();





    /*

    Ingredient ID List 

    BottomBun 0
    TopBun 1
    Meat 2
    Onion 3
    Tomato 4
    Lettuce 5
    Pineapple 6
    Oaxaca Cheese 7
    Cheese 8
    Bacon 9
    Raw/Burnt Meat 50

    */
}
