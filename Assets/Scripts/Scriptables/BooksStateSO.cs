using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BookState", menuName = "ScriptableObjects/BookState", order = 1)]
public class BooksStateSO : ScriptableObject
{
    public bool StarBookStateEnabled = false;
    public bool MoonBookStateEnabled = false;
    public bool SunBookStateEnabled = false;

    public void ResetState() 
    {
        StarBookStateEnabled = false;
        MoonBookStateEnabled = false;
        SunBookStateEnabled = false;
    }
}
