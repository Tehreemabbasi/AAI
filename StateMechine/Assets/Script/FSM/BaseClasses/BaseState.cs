using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{        
    public abstract class BaseState<T> : IState where T : StateMachine<T>
    {
        public void InitState(T _stateMachine)
        {
            m_stateMachine = _stateMachine;
            SetActions();
            SetTransitions();
            SetOwner();
        }

        public abstract void SetActions();
        public abstract void SetTransitions();

        protected Cooldown m_cooldown = new Cooldown();
        public bool OnCooldown => m_cooldown.OnCooldown;

        protected T m_stateMachine;

        protected BaseAction<T>[] m_actions;
        protected Transition<T>[] m_transitions;

        private void SetOwner()
        {
            foreach(BaseAction<T> _action in m_actions)
                _action.SetOwner(m_stateMachine);

            foreach(Transition<T> _transition in m_transitions)
                _transition.SetOwner(m_stateMachine);
        }

        public virtual void OnStateEnter()
        {
            foreach(BaseAction<T> _action in m_actions)
                _action.OnStateEnter();

            foreach(Transition<T> _transition in m_transitions)
                _transition.OnStateEnter();
        }

        public virtual void OnStateUpdate(float _dt)
        {
            int _state = -1;

            foreach(BaseAction<T> _action in m_actions)
                _action.DoAction(_dt);

            foreach(Transition<T> _transition in m_transitions)
                _state = _transition.DoTransition();

            if(_state != m_stateMachine.CurrentStateIndex)
                m_stateMachine.SetNewState(_state);
        }

        public virtual void OnStateExit()
        {
            foreach(BaseAction<T> _action in m_actions)
                _action.OnStateExit();

            foreach(Transition<T> _transition in m_transitions)
                _transition.OnStateExit();
        }
    }
}
