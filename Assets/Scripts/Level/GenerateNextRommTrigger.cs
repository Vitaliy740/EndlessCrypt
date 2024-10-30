using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenerateNextRommTrigger : MonoBehaviour
{
    private bool FirstItem = false, SecondItem = false, ThirdItem = false;
    public RandomLoopRoom LoopRoomPrefab;
    public RandomLoopRoom PreviousRoomPrefab;
    public RandomLoopRoom OriginalRoomPrefab;
    public GameObject WallBlock;
    private bool generated = false;
    public UnityEvent EventOnNoItems;

    public RandomLoopRoom QuestSolvedNextRoom;
    
    private void OnTriggerEnter(Collider other)
    {
        if (generated) return;
        if (other.gameObject.layer == 9) 
        {
            if (!RoomManager.Instance.IsItemsPlacedRight()) 
            {
                
                var room=Instantiate(LoopRoomPrefab);
                room.RoomGenerationTrigger.PreviousRoomPrefab = room;
                room.RoomGenerationTrigger.LoopRoomPrefab = RoomManager.Instance.RoomPrefab;
                room.GenerateRoom(PreviousRoomPrefab);
                WallBlock.SetActive(false);
                
                generated = true;
                EventOnNoItems?.Invoke();
            }
            else 
            {
                WallBlock.SetActive(false);
                var newStairRoom = Instantiate(QuestSolvedNextRoom);
                newStairRoom.GenerateRoom(PreviousRoomPrefab);
                newStairRoom.NextStairGenerationTrigger.CurrentRoom = newStairRoom;
                SoundManager.Instance.PlaySound(SoundManager.Instance.TaskCompleteSound);
            }
        }
    }
    
}
