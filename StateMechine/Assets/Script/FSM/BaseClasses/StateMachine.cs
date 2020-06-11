using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{        
    public abstract class StateMachine<T> : MonoBehaviour where T : StateMachine<T>
    {
        protected event Action<int> OnStateChanged = delegate { };

        private int m_currentStateIndex;
        public int CurrentStateIndex => m_currentStateIndex;

        private BaseState<T> m_currentState;
        private Dictionary<int, BaseState<T>> m_allStates = new Dictionary<int, BaseState<T>>();
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
            m_currentStateIndex = _currentState ==  null ? 0 : AllStates.First(_state => _state.Value == _currentState).Key;
            m_currentState = _currentState ?? AllStates.Values.First();

            foreach(KeyValuePair<int,BaseState<T>> keyValuePair in AllStates)
                keyValuePair.Value.InitState(this as T);
            
            m_currentState.OnStateEnter();
        }

        public virtual void Update() => m_currentState.OnStateUpdate(Time.deltaTime);

        public void SetNewState(int _newStateIndex)
        {
            BaseState<T> _newState = AllStates[_newStateIndex];

            if(_newState.OnCooldown)
                return;

            m_currentStateIndex = _newStateIndex;

            m_currentState.OnStateExit();
            m_currentState = _newState;
            m_currentState.OnStateEnter();

            OnStateChanged(_newStateIndex);
        }
    }
}
