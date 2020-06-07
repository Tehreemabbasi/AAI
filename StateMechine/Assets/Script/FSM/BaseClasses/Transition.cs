using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Transition<T> : IState where T : MonoBehaviour
{
    private string m_name;
    protected int m_successState;
    protected int m_failState;
    protected BaseDecision<T> m_decision;

    public Transition(string _name, BaseDecision<T> _decision, int _successState, int _failState)
    {
        m_name = _name;
        m_decision = _decision;
        m_successState = _successState;
        m_failState = _failState;
    }

    public void SetOwner(T _owner) => m_decision.SetOwner(_owner);
    public int DoTransition() => m_decision.Decision() ? m_successState : m_failState;
    public void OnStateEnter() => m_decision.OnStateEnter();
    public void OnStateExit() => m_decision.OnStateExit();
}