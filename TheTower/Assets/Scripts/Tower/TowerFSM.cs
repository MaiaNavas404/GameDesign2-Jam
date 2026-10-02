using UnityEngine;

public partial class Tower 
{
    public class TowerFSM : FiniteStateMachine
    {
        public Tower Context;

        public TowerStateCooldown CooldownState;
        public TowerStateTriggering TriggeringState;

        public TowerFSM (Tower context)
        {
            Context = context;

            CooldownState = new TowerStateCooldown(this);
            TriggeringState = new TowerStateTriggering(this);

            ChangeTo(CooldownState);
        }
    }
}
