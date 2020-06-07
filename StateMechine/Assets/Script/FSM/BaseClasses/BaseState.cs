using System;
using System.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public abstract class BaseState<T> : IState where T : StateMachine<T>
{
    public void InitState(T _stateMachine)
    {
        SetActions();
        SetTransitions();
        SetOwner(_stateMachine);
    }

    public abstract void SetActions();
    public abstract void SetTransition();
    protected T m_stateMachine;
    protected BaseAction<T>[] m_actions;


    private void SetOwner(T _stateMachine)
    {
        m_stateMachine = _stateMachine;
        foreach (BaseAction<T> _action in m_actions)
            _action.SetOwner(_stateMachine);
        foreach (Transition<T> _transition in m_transitions)
            _transition.SetOwner(_stateMachine);
    }
    public virtual void OnStateEnter()
    {
        foreach (BaseAction<T> _action in m_actions)
            _action.OnStateEnter();
        foreach (Transition<T> _transition in m_transitions)
            _transition.OnStateEnter();
    }
    public virtual void OnStateUpdate(float _dt)
    {
        int _state = -1;
        foreach (BaseAction<T> _action in m_actions)
            _action.DoAction(_dt);
        foreach (Transition<T> _transition in m_transitions)
            _state = _transition.DoTransition();

        if (_state != m_stateMachine.CurrentStateIndex)
            m_stateMachine.SetNewState(_state);
    }
    public virtual void OnStateExit()
    {
        foreach (BaseAction<T> _action in m_actions)
            _action.OnStateExit();
        foreach (Transition<T> _transition in m_transitions)
            _transition.OnStateExit();
    }
}


public class NpcStateIdle : BaseState<NpcStateMachine>
{
    public override void SetActions()
    {
        m_action = new BaseAction<NpcStateMachine>[]
        {
            new NpcActionIdle(),
            new NpcActionRotate(),
        };
    }
    public override void SetTransition()
    {
        m_transitions = new Transition<NpcStateMachine>[]
        {
            new Transition<NpcStateMachine>("ToChase",new NpcDecisionInRange(3f)), (int)NpcStateMachine.NpcState.Chase,
            (int)NpcStateMachine.NpcState.Idle
        };
    }
}