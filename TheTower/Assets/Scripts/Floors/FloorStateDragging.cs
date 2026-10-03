using UnityEngine;

public partial class FloorBase 
{
    public class FloorStateDragging : FloorStateBase
    {
        public FloorStateDragging(FloorFSM fsm, float size) : base(fsm, size) {}

        public override void OnEnter()
        {
            _isDragging = true;

            base.OnEnter();
        }

        public override void Update(float deltaTime)
        {
            Vector3 pos = Context._cam.ScreenToWorldPoint(Context._mousePos);
            pos.z = 0;

            Context.transform.position = pos;

            Context._tower.SortTower();

            base.Update(deltaTime);
        }

        public override void LeftClick()
        {
            FSM.ChangeTo(FSM.IdleState);
            Context._tower.OnFloorsChanged();
            _isDragging = false;

            base.LeftClick();
        }
    }
}
