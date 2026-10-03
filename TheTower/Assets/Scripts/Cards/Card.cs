using UnityEngine;

[System.Serializable]
public class Card
{
    public string Name;
    public Sprite Sprite;
    public GameObject Object;
    public string Description;

    public Card (string name, Sprite sprite, GameObject gameObject, string description)
    {
        Name = name;
        Sprite = sprite;
        Object = gameObject;
        Description = description;
    }
}
