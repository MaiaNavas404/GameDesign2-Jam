using UnityEngine;

public partial class Tower 
{
    public class TowerStateBase : IState
    {
        public TowerFSM FSM;
        public Tower Context => FSM.Context;

        public TowerStateBase (TowerFSM fsm)
        {
            FSM = fsm;
        }

        public virtual void OnEnter() {}

        public virtual void OnExit() {}

        public virtual void Update(float deltaTime) {}

        public virtual void OnFloorsChanged() {}
    }
}
