using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Character Selection")] 
    [SerializeField] private Animator _animator;
    [SerializeField] private Light _light;
    [SerializeField] private Transform _candidateTransform;
    [SerializeField] private float _toCandidateSpeed = 5f;
    [SerializeField] private float _toOverviewSpeed = 20f;

    [Header("Character Info")] 
    [SerializeField] private string _characterName;
    [SerializeField] private Stats _stats;

    public string CharacterName => _characterName;
    public Stats CharacterStats => _stats;
    public float ToCandidateSpeed => _toCandidateSpeed;
    public float ToOverviewSpeed => _toOverviewSpeed;
    public Vector3 StartingPosition { get; private set; }
    private Vector3 _candidatePosition;
    private ICharacterState _currentState;

    void Start()
    {
        StartingPosition = transform.position;
        _candidatePosition = _candidateTransform.position;
        _currentState = new OverviewState();
        _currentState.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.UpdateState();
        //CheckInputs();
    }

    public void SetState(ICharacterState newState)
    {
        if (_currentState != null)
        {
            _currentState.ExitState();
        }

        //Logiche varie di transizione

        _currentState = newState;
        _currentState.EnterState();
    }

    private void OnMouseEnter()
    {
        if (_currentState.GetType() == typeof(OverviewState))
        {
            SetState(new HighlitedState(_light));
        }
    }

    private void OnMouseExit()
    {
        if (_currentState.GetType() == typeof(HighlitedState))
        {
            SetState(new OverviewState());    
        }
    }

    private void OnMouseDown()
    {
        ChooseAction();
    }

    //Sceglie l'azione da compiere in base allo stato in cui si trova il character
    private void ChooseAction()
    {
        if (_currentState.GetType() == typeof(HighlitedState))
        {
            SetState(new ToCandidateState(_animator,this, _candidatePosition));
        }

        if (_currentState.GetType() == typeof(CandidateState))
        {
            SetState(new ToOverviewState(this, StartingPosition));
        }
    }
}
