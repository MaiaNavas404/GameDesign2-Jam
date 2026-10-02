using Unity.VisualScripting;
using UnityEngine;

public partial class FloorBase 
{
    public class FloorStateIdle : FloorStateBase
    {
        public FloorStateIdle(FloorFSM fsm, float size) : base(fsm, size) {}

        public override void Update(float deltaTime)
        {
            if (Context._isHovered) FSM.ChangeTo(FSM.HoverState);

            base.Update(deltaTime);
        }
    }
}
