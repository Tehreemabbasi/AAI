
using System.Collections.Generic;
using UnityEngine;

using FSM;

public class NpcStateMachine : StateMachine<NpcStateMachine>
{
    public enum NpcState
    {
        IDLE,
        CHASE,
        GROW,
    }

    public NpcState currentState;

    #region DATA

    public Transform target;

    #endregion

    private void OnEnable() => OnStateChanged += _OnStateChanged;
    private void OnDisable() => OnStateChanged -= _OnStateChanged;

    public override void FillStateMachineStates()
    {
        AllStates = new Dictionary<int, BaseState<NpcStateMachine>>()
        {
            { (int)NpcState.IDLE, new NpcStateIdle() },
            { (int)NpcState.CHASE, new NpcStateChase() },
            { (int)NpcState.GROW, new NpcStateGrow() }
        };
    }

    private void _OnStateChanged(int _stateIndex) => currentState = (NpcState)_stateIndex;
}


/*public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}*/
