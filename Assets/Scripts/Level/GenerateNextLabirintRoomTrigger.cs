using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNextLabirintRoomTrigger : MonoBehaviour
{
    public bool IsRightTurn = false;
    public bool NegativeTrigger = true;
    public List<RandomLabirintRoom> RoomsPrefabs=new List<RandomLabirintRoom>();
    public Transform WayEndPointTrigger;
    public GameObject WallQuad;
    private bool generated = false;
    private RandomLabirintRoom ThisRoom;

    public RandomLabirintRoom EndingRoom;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (generated) return;
        if (other.gameObject.layer == 9)
        {
            if (!RoomManager.Instance.ChecThirdQuest())
            {
                int rndNum = Random.Range(0, RoomsPrefabs.Count);
                var newLRoom = Instantiate(RoomsPrefabs[rndNum]);
                newLRoom.GenerateLabirintRoom(WayEndPointTrigger);
                
                generated = true;
                var objToDestroy = GameObject.FindGameObjectsWithTag("ObjectToDestroy");
                for (int i = 0; i < objToDestroy.Length; i++)
                {
                    if (objToDestroy[i].gameObject != ThisRoom.gameObject)
                        Destroy(objToDestroy[i].gameObject);
                }
                ThisRoom.tag = "ObjectToDestroy";
                RoomManager.Instance.ChangeRightTurnsCall(IsRightTurn, NegativeTrigger);
            }
            else 
            {
                var LastRoom = Instantiate(EndingRoom);
                LastRoom.GenerateLabirintRoom(WayEndPointTrigger);
            }
            WallQuad.SetActive(false);
        }
    }
    private void Start()
    {
        ThisRoom = transform.parent.GetComponent<RandomLabirintRoom>();
    }
}
