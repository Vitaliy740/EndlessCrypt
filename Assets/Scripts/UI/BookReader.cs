using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BookReader : MonoBehaviour
{
    [TextArea]
    public string TESTTEXT;
    public TextMeshProUGUI LeftPage;
    public TextMeshProUGUI RightPage;
    private RectTransform _pageRectTransform;
    private Vector2 _preferedValues;
    private string _remainString;
    private List<string> _pages=new List<string>();
    private int _currentIndex=0;
    // Start is called before the first frame update
    void Start()
    {
        _pageRectTransform = RightPage.GetComponent<RectTransform>();
        this.transform.SetAsFirstSibling();
        //ShowText(TESTTEXT);
    }
    public void ShowText(string textToShow) 
    {
        _currentIndex = 0;
        _pages?.Clear();
        Vector2 blockSize = _pageRectTransform.rect.size;
        
        string remainText = textToShow;
        while (!string.IsNullOrEmpty(remainText))
        {
            string fitText = FitText(remainText, blockSize, RightPage);
            _pages.Add(fitText);
            remainText = remainText.Substring(fitText.Length);
            LeftPage.text = "";
        }
        
        // Ensure we have even number of pages by adding an empty page if necessary
        if (_pages.Count % 2 != 0)
        {
            _pages.Add("");
        }
        Debug.Log("CurrentPages: " + _pages.Count);
        //NextPage();
        ShowCurrentPages();
        

    }
    public void NextPage() 
    {
        if (_currentIndex < _pages.Count - 2)
        {
            _currentIndex += 2;
            Debug.Log("CurrInd " + _currentIndex);
            ShowCurrentPages();
        }
    }
    public void ShowCurrentPages() 
    {
        LeftPage.text = _pages[_currentIndex];
        LeftPage.ForceMeshUpdate();
        RightPage.text = _pages[_currentIndex + 1];
        RightPage.ForceMeshUpdate();
        SoundManager.Instance.PlayRandomBookSound();
    }
    public void PreviousPage() 
    {
        if (_currentIndex > 0)
        {
            Debug.Log("CurrInd " + _currentIndex);
            _currentIndex -= 2;
            ShowCurrentPages();
        }
    }
    /*private string FitText(string text, Vector2 blockSize, TextMeshProUGUI textBlock)
    {
        string fittedText = text;
        textBlock.text = fittedText;

        while (textBlock.GetPreferredValues().y >= blockSize.y)
        {
            if (fittedText.Length == 0)
            {
                break;
            }
            fittedText = fittedText.Substring(0, fittedText.Length - 1);
            textBlock.text = fittedText;
        }

        return fittedText;
    }*/
    private string FitText(string text, Vector2 blockSize, TextMeshProUGUI textBlock)
    {
        string fittedText = text;
        textBlock.text = fittedText;
        Vector2 size = textBlock.GetPreferredValues();

        // Initial coarse adjustment by removing a larger chunk of text
        while (size.y > blockSize.y)
        {
            if (fittedText.Length == 0)
            {
                break;
            }
            int removeCount = Mathf.CeilToInt(fittedText.Length * 0.01f); // Remove 10% of the text length at once
            fittedText = fittedText.Substring(0, fittedText.Length - removeCount);
            textBlock.text = fittedText;
            size = textBlock.GetPreferredValues();
        }

        // Fine adjustment by removing one character at a time
        while (size.y > blockSize.y)
        {
            if (fittedText.Length == 0)
            {
                break;
            }
            fittedText = fittedText.Substring(0, fittedText.Length - 1);
            textBlock.text = fittedText;
            size = textBlock.GetPreferredValues();
        }

        return fittedText;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
