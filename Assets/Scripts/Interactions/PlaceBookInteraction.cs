using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBookInteraction : Interaction
{
    [Range(1,3)]
    public int CorrectId;
    public GameObject CurrentShelfPrefab;

    public BooksStateSO bookState;

    public GameObject StarsBook;
    public GameObject MoonBook;
    public GameObject SunBook;

    public List<AudioClip> PutSounds=new List<AudioClip>();
    //1-Звезды 2-луна 3-Солнце
    public override void Interact()
    {
        int currb = Inventory.Instance.ItemsIds.Pop();
        if (currb == 1) 
        {
            StarsBook.SetActive(true);
            RoomManager.Instance.StarsPlaced = true;
            bookState.StarBookStateEnabled = true;
        }
        else if (currb == 2) 
        {
            MoonBook.SetActive(true);
            RoomManager.Instance.MoonPlaced = true;
            bookState.MoonBookStateEnabled = true;
        }
        else if (currb==3) 
        {
            SunBook.SetActive(true);
            RoomManager.Instance.SunPlaced = true;
            bookState.SunBookStateEnabled = true;
        }
        if (currb == CorrectId) 
        {
            if (currb == 1)
            {
                RoomManager.Instance.StarsBookPlaced=true;
                bookState.StarBookStateEnabled = true;
            }
            else if (currb == 2)
            {
                RoomManager.Instance.MoonBookPlaced = true;
                bookState.MoonBookStateEnabled = true;
            }
            else if (currb == 3)
            {
                RoomManager.Instance.SunBookPlaced = true;
                bookState.SunBookStateEnabled = true;
            }
        }
        this.enabled = false;
        base.Interact();
        var PlaceBookInteractions = FindObjectsOfType<PlaceBookInteraction>();
        for (int i = 0; i < PlaceBookInteractions.Length; i++)
        {
            PlaceBookInteractions[i].CheckRequirements();
        }
        GetComponent<Collider>().enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {


        LoadBookState();
        EnableCollider();
        CheckRequirements();

    }
    public void LoadBookState() 
    {
        StarsBook.SetActive(bookState.StarBookStateEnabled);
        MoonBook.SetActive(bookState.MoonBookStateEnabled);
        SunBook.SetActive(bookState.SunBookStateEnabled);
    }
    public void CheckRequirements() 
    {
        if (Inventory.Instance.ItemsIds.Count < 1)
        {
            GetComponent<Collider>().enabled = false;
            return;
        }
        if (StarsBook.activeSelf || MoonBook.activeSelf || SunBook.activeSelf)
        {
            GetComponent<Collider>().enabled = false;
        }
    }
    public void EnableCollider()
    {
        if (!StarsBook.activeSelf && !MoonBook.activeSelf && !SunBook.activeSelf)
        {
            GetComponent<Collider>().enabled = true;
        }
        bookState.StarBookStateEnabled = StarsBook.activeSelf;
        bookState.MoonBookStateEnabled = MoonBook.activeSelf;
        bookState.SunBookStateEnabled = SunBook.activeSelf;
        RoomManager.Instance.StarsPlaced = StarsBook.activeSelf;
        RoomManager.Instance.MoonPlaced=MoonBook.activeSelf;
        RoomManager.Instance.SunPlaced= SunBook.activeSelf;
    }
    public void PlayRandomPutSound() 
    {
        SoundManager.Instance.PlayRandomPutSound();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
