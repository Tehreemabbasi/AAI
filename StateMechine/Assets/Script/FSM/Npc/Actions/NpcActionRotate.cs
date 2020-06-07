using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcActionRotate : BaseAction<NpcStateMachine>
{
    public override void DoAction(float _dt) => m_owner.transform.Rotate(Vector3.up,360f* _dt);
}
