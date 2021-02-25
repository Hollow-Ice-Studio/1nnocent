using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace innocent
{
    public class StateMachine 
    {
        protected State CurrentState;
        protected Dictionary<string, State> statesCache;

        public void Initialize(State startingState)
        {
            CurrentState = startingState;
            startingState.Enter();
        }

        public void ChangeState<T>(T newState) where T : State
        {
            if (newState == CurrentState)
                return;

            CurrentState.Exit();
            CurrentState = newState;
            newState.Enter();
            Debug.Log("Current State " + CurrentState);
        }

        public State GetCurrentState()
        {
            return CurrentState;
        }
    }
}

