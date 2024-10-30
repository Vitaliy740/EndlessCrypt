using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GetQuestBookInteraction))]

public class BookChecker : MonoBehaviour
{
    private void Start()
    {
        var interactionId = GetComponent<GetQuestBookInteraction>().BookId;
        var booksInInventory = Inventory.Instance.ItemsIds.ToArray();
        if (booksInInventory.Length > 2) 
        {
            gameObject.SetActive(false);
            return;
        }
        if (interactionId == 1) 
        {
            if (RoomManager.Instance.StarsPlaced) 
            {
                gameObject.SetActive(false);
                return;
            }
        }
        else if (interactionId == 2) 
        {
            if (RoomManager.Instance.StarsPlaced)
            {
                gameObject.SetActive(false);
                return;
            }
        }
        else 
        {
            if (RoomManager.Instance.StarsPlaced)
            {
                gameObject.SetActive(false);
                return;
            }

        }
        for (int i = 0; i < booksInInventory.Length; i++)
        {
            if(interactionId== booksInInventory[i]) 
            {
                gameObject.SetActive(false);
            }
        }
    }
}
