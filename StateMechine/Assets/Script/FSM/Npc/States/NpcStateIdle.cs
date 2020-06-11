using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FSM;

public class NpcStateIdle : BaseState<NpcStateMachine>
{
    public override void SetActions()
    {
        m_actions = new BaseAction<NpcStateMachine>[]
        {
            new NpcActionIdle(),
            new NpcActionRotate(),
        };
    }

    public override void SetTransitions()
    {
        m_transitions = new Transition<NpcStateMachine>[]
        {
            new Transition<NpcStateMachine>("ToChase",new NpcDecisionInRange(3f),(int)NpcStateMachine.NpcState.CHASE, (int)NpcStateMachine.NpcState.IDLE)
        };
    }
}


/*public class NpcStateIdle : MonoBehaviour
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
