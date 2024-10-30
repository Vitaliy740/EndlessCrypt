using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEnterTrigger : MonoBehaviour
{
    public UnityEvent OnTriggerEnterEvent;
    // Start is called before the first frame update
    public bool RequireMakeSound = true;
    private bool isPlayed = false;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerEnter");
        if (other.gameObject.layer == 9) 
        {
            Debug.Log("TriggerCheckPassed");
            if(RequireMakeSound)
                SoundManager.Instance.SetInWater(true);
            if (!isPlayed)
            {
                OnTriggerEnterEvent?.Invoke();
                isPlayed = true;
            }
            this.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
