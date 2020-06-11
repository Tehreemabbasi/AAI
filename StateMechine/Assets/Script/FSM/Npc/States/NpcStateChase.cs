using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class NpcStateChase : BaseState<NpcStateMachine>
{
    public override void OnStateExit()
    {
        m_cooldown.Start(2f, m_stateMachine);
        base.OnStateExit();
    }

    public override void SetActions()
    {
        m_actions = new BaseAction<NpcStateMachine>[]
        {
            new NpcActionChase(),
            new NpcActionLookAtTarget()
        };
    }

    public override void SetTransitions()
    {
        m_transitions = new Transition<NpcStateMachine>[]
        {
            new Transition<NpcStateMachine>("ToGrow",new NpcDecisionInRange(1.5f),(int)NpcStateMachine.NpcState.GROW, (int)NpcStateMachine.NpcState.CHASE)
        };
    }
}

/*public class NpcStateChase : MonoBehaviour
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
