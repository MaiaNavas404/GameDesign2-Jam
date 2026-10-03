using UnityEngine;

[System.Serializable]
public class Card
{
    public string Name;
    public Sprite Sprite;
    public GameObject Object;

    public Card (string name, Sprite sprite, GameObject gameObject)
    {
        Name = name;
        Sprite = sprite;
        Object = gameObject;
    }
}
