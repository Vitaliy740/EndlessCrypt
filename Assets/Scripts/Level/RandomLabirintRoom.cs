using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLabirintRoom : MonoBehaviour
{
    public Transform StartPoint;
    public void GenerateLabirintRoom(Transform prevRoomEndPoint) 
    {
        StartPoint.parent = null;
        this.gameObject.transform.parent = StartPoint;
        StartPoint.position = prevRoomEndPoint.position;
        StartPoint.rotation = prevRoomEndPoint.rotation * Quaternion.Euler(0, 180, 0);
        gameObject.transform.parent = null;
        StartPoint.SetParent(gameObject.transform);
    }
}
