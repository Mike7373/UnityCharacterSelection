using System.Collections;
using UnityEngine;

public class ToOverviewState : ICharacterState
{
    private Character _character;
    private Vector3 _targetPosition;
    private float _speed;

    public ToOverviewState(Character character, Vector3 targetPos)
    {
        _character = character;
        _targetPosition = targetPos;
        _speed = character.ToOverviewSpeed;
    }
    
    public void EnterState()
    {
        _character.StartCoroutine(Move());
        Debug.Log("[ToOverviewState] Enter...");
    }

    public void UpdateState()
    {
        Debug.Log("[ToOverviewState] Update...");
    }

    public void ExitState()
    {
        Debug.Log("[ToOverviewState] Exit...");
    }
    
    private IEnumerator Move()
    {
        Transform transform = _character.transform;
        while (Vector3.Distance(transform.position, _targetPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed*Time.deltaTime);
            yield return null;
        }
        _character.SetState(new OverviewState());
    } 
}
