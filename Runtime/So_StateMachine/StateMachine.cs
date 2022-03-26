using UnityEngine;

namespace Project_Setup.So_StateMachine
{
    [CreateAssetMenu(fileName = "Game State Machine", menuName = "Game State Machine", order = 0)]
    public class StateMachine : ScriptableObject
    {
        //[SerializeField] private GameStateChangeEventSo onGameStateChange;

        [SerializeField] private GameState currentSate;
        public GameState CurrentState => currentSate;

        public enum GameState
        {
            Start,
            Gameplay,
            LevelFailed,
            LevelComplete
        }

        public void ChangeState(GameState newState)
        {
            var oldState = currentSate;
            currentSate = newState;

            //onGameStateChange.RaiseEvent(new GameStateChangeData(oldState, currentSate));
        }
    }
}