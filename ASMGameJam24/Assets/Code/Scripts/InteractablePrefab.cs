// MyPrefab.cs
using UnityEngine;

public class InteractablePrefab : MonoBehaviour, IInteractable
{
    [SerializeField] private string objectType;
    public string ObjectType => objectType;

}