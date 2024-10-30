using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteraction : Interaction
{
    public AudioClip PickupKey;
    public override void Interact()
    {
        base.Interact();
        Inventory.Instance.HaveKey = true;
        gameObject.SetActive(false);
        SoundManager.Instance.PlaySound(PickupKey);

    }
}
