using System.Collections.Generic;

namespace REstate.Schematics
{
    public interface ISchematic<TState, TInput>
    {
        string SchematicName { get; }
        TState InitialState { get; }
        IReadOnlyDictionary<TState, IState<TState, TInput>> States { get; }
    }
}