namespace StateMonad;

public sealed class State<TS, T>(Func<TS, (T, TS)> run)
{
    private readonly Func<TS, (T Value, TS State)> _run = run;

    public (T Value, TS State) Run(TS state) => _run(state);
}

public static class State
{
    public static State<TS, T> Return<TS, T>(T value) =>
        new(state => (value, state));

    public static State<TS, TS> Get<TS>() =>
        new(state => (state, state));

    public static State<TS, Unit> Put<TS>(TS newState) =>
        new(_ => (Unit.Value, newState));

    public static State<TS, Unit> Modify<TS>(Func<TS, TS> f) =>
        new(state => (Unit.Value, f(state)));
}

public static class StateExtensions
{
    extension<TS, T>(State<TS, T> state)
    {
        public State<TS, TResult> SelectMany<TResult>(Func<T, State<TS, TResult>> bind)
        {
            return new State<TS, TResult>(s =>
            {
                var (value, newState) = state.Run(s);
                return bind(value).Run(newState);
            });
        }

        public State<TS, TResult> SelectMany<TIntermediate, TResult>(Func<T, State<TS, TIntermediate>> bind,
            Func<T, TIntermediate, TResult> project)
        {
            return new State<TS, TResult>(s =>
            {
                var (value, newState) = state.Run(s);
                var (intermediateValue, finalState) = bind(value).Run(newState);
                return (project(value, intermediateValue), finalState);
            });
        }

        public State<TS, TResult> Select<TResult>(Func<T, TResult> map)
        {
            return state.SelectMany(x => State.Return<TS, TResult>(map(x)));
        }
    }
}

public readonly struct Unit
{
    public static readonly Unit Value = new();
    public override string ToString() => "()";
}