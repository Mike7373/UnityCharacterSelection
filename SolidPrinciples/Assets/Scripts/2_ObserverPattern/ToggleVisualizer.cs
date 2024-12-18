using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ToggleVisualizer : MonoBehaviour
{
    [SerializeField] private string _toggleName;
    [SerializeField] private ToggleGroupVisualizer _toggleGroup;
    [SerializeField] private Image _checkmark;
    
    private CustomToggle _toggle;
    private Button _button;
    private delegate void onDeselect();
    //private event onDeselect _deselectEvent;
    
    private void Awake()
    {
        _toggle = new CustomToggle(_toggleName);
        _button = GetComponent<Button>();
    }
    

    private void Start()
    {
        _toggleGroup.toggleGroup.Register(_toggle);
        _checkmark.enabled = false;
        _button.onClick.AddListener(Select);
    }

    private void OnDisable()
    {
        _toggleGroup.toggleGroup.Unregister(_toggle);
    }

    public void Select()
    {
        _toggleGroup.toggleGroup.Notify();
        _checkmark.enabled = true;
    }

    public void Deselect()
    {
        _checkmark.enabled = false;
    }
}
