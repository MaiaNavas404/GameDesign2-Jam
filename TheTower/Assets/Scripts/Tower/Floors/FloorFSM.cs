using UnityEngine;

public partial class FloorBase 
{
    public class FloorFSM : FiniteStateMachine
    {
        public FloorBase Context;

        public FloorStateIdle IdleState;
        public FloorStateHovered HoverState;

        public FloorFSM (FloorBase context)
        {
            Context = context;

            IdleState = new(this, 1);
            HoverState = new(this, Context._hoveredSizeMult);

            ChangeTo(IdleState);
        }
    }
}
