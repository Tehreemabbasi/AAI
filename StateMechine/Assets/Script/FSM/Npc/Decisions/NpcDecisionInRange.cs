
using UnityEngine;
using FSM;

public class NpcDecisionInRange : BaseDecision<NpcStateMachine>
{
    private float m_range;
    public NpcDecisionInRange(float _range) => m_range = _range;

    public override bool Decision()
    {
        float _distance = Vector3.Distance(m_owner.transform.position, m_owner.target.position);
        return _distance < m_range;
    }
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
}
*/
