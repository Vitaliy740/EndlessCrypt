using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance;

    public RandomLoopRoom RoomPrefab;
    public RandomLoopRoom StairRoomPrefab;
    public bool MoonBookPlaced = false, StarsBookPlaced = false, SunBookPlaced = false;
    public bool MoonPlaced = false, StarsPlaced = false, SunPlaced = false;
    public int RequireNumberOfRightTurns=4;
    private int LabirintRightTurnsCount = 1;
    public List<BooksStateSO> states=new List<BooksStateSO>();
    private void Start()
    {
        if(Instance == null) 
        {
            Instance = this;
        }
        else if (Instance != this) 
        {
            Destroy(this.gameObject);
        }
    }
    private void Awake()
    {
        foreach (var item in states)
        {
            item.ResetState();
        }
    }
    public void ChangeRightTurnsCall(bool isRight,bool negativeImpact) 
    {
        if (isRight)
        {
            LabirintRightTurnsCount += 1;
        }
        else if(negativeImpact) 
        {
            LabirintRightTurnsCount -= 1;
        }
        if (LabirintRightTurnsCount >= RequireNumberOfRightTurns) 
        {
            PlaySolvedSound();
        }
        if (LabirintRightTurnsCount < 0) 
        {
            LabirintRightTurnsCount = 0;
        }

    }
    public bool ChecThirdQuest() 
    {
        return LabirintRightTurnsCount >= RequireNumberOfRightTurns;
    }

    private void PlaySolvedSound() 
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.TaskCompleteSound);
    }
    public void PlaceCorrectMoonBoock() 
    {
        MoonBookPlaced = true;
    }
    public void PlaceNotCorrectMoonBook() 
    {
        MoonBookPlaced = false;
    }
    public void PlaceCorrectStarsBoock()
    {
        StarsBookPlaced = true;
    }
    public void PlaceNotStarsMoonBook()
    {
        StarsBookPlaced = false;
    }
    public void PlaceCorrectSunBoock()
    {
        SunBookPlaced = true;
    }
    public void PlaceNotCorrectSunBook()
    {
        SunBookPlaced = false;
    }
    public bool IsItemsPlacedRight() 
    {
        return MoonBookPlaced && StarsBookPlaced && SunBookPlaced;
    }
}
