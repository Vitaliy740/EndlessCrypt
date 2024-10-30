using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetQuestBookInteraction : Interaction
{
    [Range(1,3)]
    public int BookId;
    public override void Interact()
    {
        Inventory.Instance.ItemsIds.Push(BookId);
        
        this.gameObject.SetActive(false);
        var placer = FindObjectsOfType<PlaceBookInteraction>();
        for (int i = 0; i < placer.Length; i++)
        {
            placer[i].EnableCollider();
        }
        var checkers = FindObjectsOfType<BookChecker>();
        for (int i = 0; i < checkers.Length; i++)
        {
            if(checkers[i].GetComponent<GetQuestBookInteraction>().BookId==BookId)
                checkers[i].gameObject.SetActive(false);
        }
        SoundManager.Instance.PlayRandomPickUpSound();
    }

}
