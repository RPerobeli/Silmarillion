
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Item/Create New Item")]
public class InventoryItem : ScriptableObject
{
    public int Id;
    public string Name;
    public Sprite Icon;
    public bool Craftable;
    public List<int> Ingredients;

}
