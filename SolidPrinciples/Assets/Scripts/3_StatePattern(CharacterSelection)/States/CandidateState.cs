using UnityEngine;

public class CandidateState : ICharacterState
{
    private Animator _animator;
    private Character _character;
    private Light _light;
    
    public CandidateState(Animator animator, Character character)
    {
        _animator = animator;
        _character = character;
        _light = character.Light;
    }    
    
    public void EnterState()
    {
        _light.enabled = true;
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
        _light.enabled = false;
        _animator.SetBool("isCandidate", false);
        StatsCanvas.ToggleCanvas(false);
        Debug.Log("[CandidateState] Exit...");
    }
}
