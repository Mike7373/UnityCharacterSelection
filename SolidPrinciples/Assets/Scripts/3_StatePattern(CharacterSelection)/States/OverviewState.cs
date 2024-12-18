using UnityEngine;

public class OverviewState : ICharacterState
{
    public void EnterState()
    {
        Debug.Log("[OverviewState] Enter...");
    }

    public void UpdateState()
    {
        Debug.Log("[OverviewState] Update...");
    }

    public void ExitState()
    {
        Debug.Log("[OverviewState] Exit...");
    }
}
