using UnityEngine;

public partial class FloorBase 
{
    public class FloorStateHovered : FloorStateBase
    {
        public FloorStateHovered(FloorFSM fsm, float size) : base(fsm, size) {}

        public override void OnEnter()
        {
            Context._hoverInfo.SetActive(true);

            base.OnEnter();
        }

        public override void OnExit()
        {
            Context._hoverInfo.SetActive(false);

            base.OnExit();
        }

        public override void Update(float deltaTime)
        {
            if (!Context._isHovered) FSM.ChangeTo(FSM.IdleState);

            base.Update(deltaTime);
        }

        public override void RightClick()
        {
            Context.Sell();

            base.RightClick();
        }

        public override void LeftClick()
        {
            FSM.ChangeTo(FSM.HoldDraggingState);

            base.LeftClick();
        }
    }
}
