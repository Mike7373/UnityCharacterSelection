using System;
using UnityEngine;

public class ToggleGroupVisualizer : MonoBehaviour
{
    [SerializeField] private string _groupName;
    public CustomToggleGroup toggleGroup;

    private void Awake()
    {
        toggleGroup = new CustomToggleGroup(_groupName);
    }
}
