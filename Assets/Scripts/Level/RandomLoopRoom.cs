using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLoopRoom : MonoBehaviour
{
    public Transform StartPoint;
    public Transform EndPoint;
    public GenerateNextRommTrigger RoomGenerationTrigger;
    public GenerateNextStairRoomTrigger NextStairGenerationTrigger;
    public RandomLoopRoom TestRoom;
    // Start is called before the first frame update
    void Start()
    {
        //if (TestRoom) GenerateRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GenerateRoom(RandomLoopRoom fromRoom)
    {
        StartPoint.parent = null;
        this.gameObject.transform.parent = StartPoint;
        StartPoint.position = fromRoom.EndPoint.position;
        StartPoint.rotation = fromRoom.EndPoint.rotation * Quaternion.Euler(0, 180, 0);
        gameObject.transform.parent = null;
        StartPoint.SetParent(gameObject.transform);
    }
    public void GenerateRoomOnTransform(Transform prevRoomEndPoint) 
    {
        StartPoint.parent = null;
        this.gameObject.transform.parent = StartPoint;
        StartPoint.position = prevRoomEndPoint.position;
        StartPoint.rotation = prevRoomEndPoint.rotation * Quaternion.Euler(0, 180, 0);
        gameObject.transform.parent = null;
        StartPoint.SetParent(gameObject.transform);
    }
    public void GenerateRoomBackWard(RandomLoopRoom fromRoom)
    {
        StartPoint.parent = null;
        this.gameObject.transform.parent = StartPoint;
        StartPoint.position = fromRoom.StartPoint.position;
        StartPoint.rotation = fromRoom.StartPoint.rotation * Quaternion.Euler(0, 180, 0);
        gameObject.transform.parent = null;
        StartPoint.SetParent(gameObject.transform);
    }
    public void GenerateRoom() 
    {
        GenerateRoom(TestRoom);
    }
}
