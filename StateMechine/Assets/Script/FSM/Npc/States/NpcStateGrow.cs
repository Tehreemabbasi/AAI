using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;
public class NpcStateGrow : BaseState<NpcStateMachine>
{
    public override void SetActions()
    {
        m_actions = new BaseAction<NpcStateMachine>[]
        {
            new NpcActionGrow(),
        };
    }

    public override void SetTransitions()
    {
        m_transitions = new Transition<NpcStateMachine>[]
        {
            new Transition<NpcStateMachine>("ToIdle",new NpcDecisionInRange(5f),(int)NpcStateMachine.NpcState.GROW, (int)NpcStateMachine.NpcState.IDLE)
        };
    }
}

/*public class NpcStateGrow : MonoBehaviour
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
