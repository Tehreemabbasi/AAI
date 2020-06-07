
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public interface IState
{

}

public abstract class BaseDecision<T> : IState where T : MonoBehaviour
{
    protected T m_owner;
    public void SetOwner(T _owner) => m_owner = _owner;
    public abstract bool Decision();
    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }
}

public class NpcDecisionInRange : BaseDecision<NpcStateMachine>
{
    private float m_range;
    public NpcDecisionInRange(float _range) => m_range = _range;

    public override bool Decision()
    {
        float _distance = Vector3.Distance(m_owner.tranform.position, m_owner.target.position);
        return _distance < m_range;
    }
}