using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushTimer : MonoBehaviour
{
    public AudioClip CrushRockClip;
    public float TimeBeforeCrush = 45f;
    private float CurrentTime = 0f;
    public GameObject DeatPanel;
    public bool IsUnderCrush;
    private bool crushed = false;
    private void Update()
    {
        if (crushed) return;
        CurrentTime += Time.deltaTime;
        if (CurrentTime > 10f && !GetComponent<ParticleSystem>().isPlaying) 
        {
            GetComponent<ParticleSystem>().Play();
        }
        if (CurrentTime > TimeBeforeCrush) 
        {
            CrushToDeath();
        }
    }
    public void Start()
    {
        //CrushToDeath();
    }
    public void CrushToDeath() 
    {
        SoundManager.Instance.PlaySound(CrushRockClip);
        if (IsUnderCrush) 
        {
            DeatPanel.SetActive(true);
            OpenMenuController.Instance.EnterOpenMenuState();
            OpenMenuController.Instance._inputs.enabled = false;
            crushed = true;
            Destroy(this.gameObject);
        }
    }
    public void SetIsUnderCrush(bool v) 
    {
        IsUnderCrush = v;
    }
}
