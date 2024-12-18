using UnityEngine;

public class CandidateState : ICharacterState
{
    private Animator _animator;
    private Character _character;
    
    public CandidateState(Animator animator, Character character)
    {
        _animator = animator;
        _character = character;
    }    
    
    public void EnterState()
    {
        _animator.SetBool("isCandidate", true);
        StatsCanvas.DrawStats(_character.CharacterStats, _character.CharacterName);
        StatsCanvas.ToggleCanvas(true);
        Debug.Log("[CandidateState] Enter...");
    }

    public void UpdateState()
    {
        Debug.Log("[CandidateState] Update...");
    }

    public void ExitState()
    {
        _animator.SetBool("isCandidate", false);
        StatsCanvas.ToggleCanvas(false);
        Debug.Log("[CandidateState] Exit...");
    }
}
