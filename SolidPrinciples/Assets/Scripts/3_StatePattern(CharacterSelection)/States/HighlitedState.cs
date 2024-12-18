using UnityEngine;

public class HighlitedState : ICharacterState
{
    private Light _light;

    public HighlitedState(Character character)
    {
        _light = character.Light;
        _light.enabled = false;
    }
    
    public void EnterState()
    {
        _light.enabled = true;
        Debug.Log("[HiglitedState] Enter...");
    }

    public void UpdateState()
    {
        Debug.Log("[HiglitedState] Update...");
    }

    public void ExitState()
    {
        _light.enabled = false;
        Debug.Log("[OverviewState] Exit...");
    }
}