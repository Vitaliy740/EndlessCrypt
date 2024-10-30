using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNextStairRoomTrigger : MonoBehaviour
{
    public RandomLoopRoom PreviousRoomPrefab;
    public RandomLoopRoom NextRoomPrefab;
    public RandomLoopRoom CurrentRoom;
    private bool generated = false;
    private void OnTriggerEnter(Collider other)
    {
        if (generated) return;
        if (other.gameObject.layer == 9)        
        {
            var stair = Instantiate(RoomManager.Instance.StairRoomPrefab);
            stair.NextStairGenerationTrigger.CurrentRoom = stair;
            //stair.NextStairGenerationTrigger.PreviousRoomPrefab = stair;
            stair.GenerateRoom(PreviousRoomPrefab);
            //PreviousRoomPrefab.GenerateRoom();

            var toDestroy = GameObject.FindGameObjectsWithTag("ObjectToDestroy");
            foreach (var item in toDestroy)
            {
                Destroy(item.gameObject);
            }
            var newRoom = Instantiate(NextRoomPrefab);
            CurrentRoom.tag = "ObjectToDestroy";
            newRoom.GenerateRoomOnTransform(CurrentRoom.StartPoint);
            generated = true;
        }

    }
}
