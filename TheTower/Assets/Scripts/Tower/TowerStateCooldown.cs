using UnityEngine;

public partial class Tower 
{
    public class TowerStateCooldown : TowerStateBase
    {
        public TowerStateCooldown(TowerFSM fsm) : base(fsm) {}
        float _timer;

        public override void OnEnter()
        {
            _timer = Context._cooldownTime;

            base.OnEnter();
        }

        public override void Update(float deltaTime)
        {
            _timer -= deltaTime * (Context.BuffFloorAmount + 1);
            if (_timer < 0)
            {
                FSM.ChangeTo(FSM.TriggeringState);
            }

            base.Update(deltaTime);
        }
    }
}
