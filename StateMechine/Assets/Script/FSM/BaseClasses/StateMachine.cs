using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class StateMachine<T> : MonoBehaviour where T : StateMachine<T>
{
    protected event Action<int> OnStateChanged = delegate { };
    private int m_currentStateIndex;
    public int CurrentStateIndex => m_currentStateIndex;
    private BaseState<T> m_currentState;
    private Dictionary<int, BaseState<T>> m_allStates = new Dictionary<int, BaseStae<T>>();
    public Dictionary<int, BaseState<T>> AllStates
    {
        get => m_allStates;
        set
        {
            m_allStates = value;
            InitializeStateMachine();
        }
    }
    public virtual void Awake() => FillStateMachineStates();
    public abstract void FillStateMachineStates();

    public void InitializeStateMachine(BaseState<T> _currentState = null)
    {
        m_currentStateIndex = currentState == null ? 0 : AllStates.First(_state => _state.Value == _currentState);
        m_currentState = _currentState ?? AllStates.Values.First();
        m_currentState.OnStateEnter();
    }
    public virtual void Update() => m_currentState.OnStateUpdate(Time.deltaTime);

    public void SetNewState(int _newState)
    {
        m_currentStateIndex = _newState;
        m_currentState = AllStates[_newState];
        m_currentState.OnStateEnter();
        OnstateCanged(_newState);
    }
}

/*public class NpcStateMachine : StateMachine<NpcStateMachine>
{
    public enum NpcState
    {
        Idle, 
        Chase,
        Grow,
    }
    public NpcState currentState;
    public Transform target;
    private void OnEnable() => OnstateChanged += _OnStateChanged;
    private void OnDisable() => OnStateChanged -= _OnStateChanged;

    public override void FillStateMachineStates()
    {
        AllStates = new Dictionary<int, BaseState<NpcStateMachine>>()
        {
            {(int)NpcState.Idle, new NpcStateIdle() },
            { (int)NpcState.Chase, new NpcStateChase()},
            {(int)NpcState.Grow, new NpcStateGrow() }
        };
    }
    private void _OnStateChanged(int _stateIndex) => currentState = (NpcState)_stateIndex;
}*/
