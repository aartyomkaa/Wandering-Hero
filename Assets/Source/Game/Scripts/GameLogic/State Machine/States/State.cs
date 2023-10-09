using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    internal abstract class State : MonoBehaviour
    {
        [SerializeField] protected List<Transition> Transition;

        protected bool IsActive;

        public void Enter()
        {
            if (enabled == false)
            {
                IsActive = true;
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

                IsActive = false;
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