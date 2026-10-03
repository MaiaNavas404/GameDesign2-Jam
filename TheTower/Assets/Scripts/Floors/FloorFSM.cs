using UnityEngine;

public partial class FloorBase 
{
    public class FloorFSM : FiniteStateMachine
    {
        public FloorBase Context;

        public FloorStateIdle IdleState;
        public FloorStateHovered HoverState;
        public FloorStateDragging DraggingState;
        public FloorStateHoldDragging HoldDraggingState;

        public FloorFSM (FloorBase context)
        {
            Context = context;

            IdleState = new(this, 1);
            HoverState = new(this, Context._hoveredSizeMult);
            DraggingState = new(this, Context._draggedSizeMult);
            HoldDraggingState = new(this, Context._draggedSizeMult);

            ChangeTo(IdleState);
        }

        public void RightClick ()
        {
            (CurrentState as FloorStateBase).RightClick();
        }
        public void LeftClick ()
        {
            (CurrentState as FloorStateBase).LeftClick();
        }
        public void StopLeftClick ()
        {
            (CurrentState as FloorStateBase).StopLeftClick();
        }
    }
}
