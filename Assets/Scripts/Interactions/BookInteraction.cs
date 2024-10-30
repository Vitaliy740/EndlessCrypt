using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class BookInteraction : Interaction
{
    [Inject]
    private BookReader _reader;
    [TextArea]
    public string BookText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void Interact()
    {
        _reader?.transform.GetChild(0).gameObject.SetActive(true);
        _reader?.ShowText(BookText);
        OpenMenuController.Instance?.EnterOpenMenuState();
        base.Interact();

    }
    public 
    // Update is called once per frame
    void Update()
    {
        
    }
}
