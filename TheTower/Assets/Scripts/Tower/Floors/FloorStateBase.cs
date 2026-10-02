using UnityEngine;

public partial class FloorBase 
{
    public class FloorStateBase : IState
    {
        public FloorFSM FSM;
        public FloorBase Context => FSM.Context;
        float _size;

        public FloorStateBase (FloorFSM fsm, float size)
        {
            FSM = fsm;
            _size = size;
        }

        public virtual void OnEnter()
        {
            Context.transform.localScale = _size * Vector3.one;
        }

        public virtual void OnExit() {}

        public virtual void Update(float deltaTime) {}
    }
}
