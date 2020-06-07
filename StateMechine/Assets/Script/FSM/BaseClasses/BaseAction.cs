using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseAction<T> : IState where T : MonoBehaviour
{
    protected T m_owner;
    public void SetOwner(T _owner) => m_owner = _owner;
    public abstract void DoAction(float _dt);
    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }
}

public class NpcActionRotate : BaseAction<NpcStateMachine>
{
    public override void DoAction(float _dt) => m_owner.transform.Rotate(Vector3.up, 360f * _dt);
}