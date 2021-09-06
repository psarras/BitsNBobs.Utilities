using System;
using System.Collections.Generic;
using UnityEngine;

namespace BitsNBobs.Patterns
{
    public abstract class StateMachine
    {
        private IState currentState;
        private Dictionary<Type, List<Transition>> transitions = new Dictionary<Type, List<Transition>>();

        private List<Transition> currentTransitions = new List<Transition>();
        private List<Transition> anyTransitions = new List<Transition>();
        private static List<Transition> EmptyTransitions = new List<Transition>();
        public event Action<IState> OnChangeState;
        public int TotalTicks { get; private set; } = 0;

        public void Tick()
        {
            TotalTicks++;
            var transition = GetTransition();
            // We need to leave!
            if (transition != null)
            {
                SetState(transition.To);
                OnChangeState?.Invoke(transition.To);
            }

            // BAU
            currentState?.Tick();
        }

        public void SetState(IState state)
        {
            if (state == currentState)
                return;

            // We are out of here
            currentState?.OnExit();
            currentState = state;

            // Gather the transitions of the next node / state
            transitions.TryGetValue(currentState.GetType(), out currentTransitions);
            if (currentTransitions == null)
                currentTransitions = EmptyTransitions;

            Debug.Log($"Entering State: {currentState.GetType()}");
            currentState.OnEnter();
        }

        public void AddTransition(IState from, IState to, Func<bool> condition)
        {
            if (!transitions.TryGetValue(from.GetType(), out var trans))
            {
                trans = new List<Transition>();
                transitions[from.GetType()] = trans;
            }
            trans.Add(new Transition(to, condition));
        }

        public void AddAnyTransition(IState state, Func<bool> condition)
        {
            anyTransitions.Add(new Transition(state, condition));
        }

        private Transition GetTransition()
        {
            // Maybe add a priority ?
            foreach (var transition in anyTransitions)
                if (transition.Condition())
                    return transition;

            foreach (var transition in currentTransitions)
                if (transition.Condition())
                    return transition;

            return null;
        }

        public void CallElevator(int Floor)
        {
            
        }
        
    }
}