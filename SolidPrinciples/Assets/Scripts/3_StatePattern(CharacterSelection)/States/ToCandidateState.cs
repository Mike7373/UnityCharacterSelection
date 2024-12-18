using System.Collections;
using UnityEngine;

public class ToCandidateState : ICharacterState
{
    private Animator _animator;
    private static Character _currentCandidate;
    private Character _character;
    private Vector3 _targetPosition;
    private float _speed;
    private Light _light;

    public ToCandidateState(Animator animator, Character character, Vector3 targetPos)
    {
        _animator = animator;
        _character = character;
        _targetPosition = targetPos;
        _speed = character.ToCandidateSpeed;
        _light = character.Light;
        if (_currentCandidate != null)
        {
            _currentCandidate.StopAllCoroutines();
            _currentCandidate.SetState(new ToOverviewState(_currentCandidate,_currentCandidate.StartingPosition));
            _currentCandidate = character;
        }
        _currentCandidate = _character;

    }
    
    public void EnterState()
    {
        _light.enabled = true;
        _animator.SetBool("toCandidate", true);
        _character.StartCoroutine(Move());
        Debug.Log("[ToCandidateState] Enter...");
    }

    public void UpdateState()
    {
        Debug.Log("[ToCandidateState] Update...");
    }

    public void ExitState()
    {
        _light.enabled = false;
        _animator.SetBool("toCandidate", false);
        _character.transform.eulerAngles = _character.StartingRotation;
        Debug.Log("[ToCandidateState] Exit...");
    }
    
    //Si può utilizzare sia nell'update come coroutine :)
    private IEnumerator Move()
    {
        Transform transform = _character.transform;
        while (Vector3.Distance(transform.position, _targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed*Time.deltaTime);
            transform.LookAt(_targetPosition);
            yield return null;
        }
        _character.SetState(new CandidateState(_animator,_character));
    } 
}
