namespace Project_Setup.So_StateMachine
{
    public readonly struct GameStateChangeData
    {
        public StateMachine.GameState OldState { get; }
        public StateMachine.GameState CurrentState { get; }

        public GameStateChangeData(StateMachine.GameState oldState, StateMachine.GameState currentState)
        {
            OldState = oldState;
            CurrentState = currentState;
        }
    }
}