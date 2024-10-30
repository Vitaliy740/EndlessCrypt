using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory Instance;
    public Stack<int> ItemsIds = new Stack<int>();
    public bool HaveKey=false;
    private void Start()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
        else if (Instance != this) 
        {
            Destroy(this);
        }
    }
}
