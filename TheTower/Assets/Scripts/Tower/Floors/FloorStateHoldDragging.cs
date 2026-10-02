using UnityEngine;

public partial class FloorBase 
{
    public class FloorStateHoldDragging : FloorStateBase
    {
        public FloorStateHoldDragging(FloorFSM fsm, float size) : base(fsm, size) {}

        float _timer;

        public override void OnEnter()
        {
            _isDragging = true;

            _timer = 0.2f;

            base.OnEnter();
        }

        public override void Update(float deltaTime)
        {
            _timer -= deltaTime;

            Vector3 pos = Context._cam.ScreenToWorldPoint(Context._mousePos);
            pos.z = 0;

            Context.transform.position = pos;

            base.Update(deltaTime);
        }

        public override void StopLeftClick()
        {
            if (_timer >= 0)
            {
                FSM.ChangeTo(FSM.DraggingState);
            }
            else
            {
                FSM.ChangeTo(FSM.IdleState);
                Context._tower.OnFloorsChanged();
                _isDragging = false;
            }

            base.StopLeftClick();
        }
    }
}
