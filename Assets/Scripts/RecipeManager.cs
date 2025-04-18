using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    private static RecipeManager instance;

    public static RecipeManager Instance {  get { return instance; } }
    
    public Stack<int> playerRecipe = new Stack<int>();
}
