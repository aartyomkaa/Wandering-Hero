using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    internal abstract class State : MonoBehaviour
    {
        [SerializeField] protected List<Transition> Transition;

        public void Enter()
        {
            if (enabled == false)
            {
                enabled = true;

                foreach (var transition in Transition)
                {
                    transition.enabled = true;
                }
            }
        }

        public void Exit()
        {
            if (enabled == true)
            {
                foreach (var transition in Transition)
                {
                    transition.enabled = false;
                }

                enabled = false;
            }
        }

        public State GetNextState()
        {
            foreach (var transition in Transition)
            {
                if (transition.NeedTransit)
                {
                    return transition.TargetState;
                }
            }

            return null;
        }
    }
}