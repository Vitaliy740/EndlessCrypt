using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LockInteraction : Interaction
{
    public AudioClip RockLockSound;
    public UnityEvent AfterStartEvents;
    public override void Interact()
    {
        if (Inventory.Instance.HaveKey)
        {
            SoundManager.Instance.PlaySound(RockLockSound);
            base.Interact();
            this.enabled = false;
            Inventory.Instance.HaveKey = false;
        }
    }
    public AudioClip MechanismStartSound;

    public void StartMechanism() 
    {
        SoundManager.Instance.PlaySound(MechanismStartSound);
        AfterStartEvents?.Invoke();
    }
}
