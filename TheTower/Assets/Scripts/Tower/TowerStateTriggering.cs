using UnityEngine;

public partial class Tower 
{
    public class TowerStateTriggering : TowerStateBase
    {
        public TowerStateTriggering(TowerFSM fsm) : base(fsm) {}
        float _timer;
        int n;

        public override void OnEnter()
        {
            _timer = Context._triggerTime;
            n = 0;

            base.OnEnter();
        }

        public override void Update(float deltaTime)
        {
            _timer -= deltaTime;
            if (_timer < 0)
            {
                Context._floors[n].Trigger();
                _timer = Context._triggerTime;

                n++;
                if (n >= Context._floors.Count)
                {
                    FSM.ChangeTo(FSM.CooldownState);
                }
            }

            base.Update(deltaTime);
        }
    }
}
