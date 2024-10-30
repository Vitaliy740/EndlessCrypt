using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomObjectPlacer : MonoBehaviour
{
    [SerializeField]
    private List<Transform> RandomPlaces;
    [SerializeField]
    private List<GameObject> RandomObjects;
    // Start is called before the first frame update
    void Start()
    {
        var rng = new System.Random();
        rng.Shuffle<GameObject>(RandomObjects);
        RandomizeObject();
    }
    public void RandomizeObject() 
    {
        for (int i = 0; i < RandomPlaces.Count; i++)
        {
            var obj=Instantiate(RandomObjects[i], RandomPlaces[i]);
            obj.SetActive(true);
            obj.transform.localPosition = Vector3.zero;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
public static class RandomExtensions
{
    public static void Shuffle<T>(this System.Random rng, List<T> array)
    {
        int n = array.Count;
        while (n > 1)
        {
            int k = rng.Next(n--);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }
}
