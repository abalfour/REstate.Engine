using System.Collections.Generic;
using System.Linq;
using REstate.Schematics;

namespace REstate.Engine
{
    /// <summary>
    /// DOT GraphViz text writer for cartographer API.
    /// </summary>
    public class DotGraphCartographer<TState, TInput>
        : ICartographer<TState, TInput>
    {
        /// <summary>
        /// Produces a DOT GraphViz graph.
        /// </summary>
        /// <returns>DOT GraphViz text.</returns>
        public string WriteMap(IEnumerable<IState<TState, TInput>> states)
        {
            var lines = new List<string>();
            var onEntryActionLines = new List<string>();

            foreach (var state in states)
            {
                var source = state.Value;

                lines.AddRange(state.Transitions.Values
                    .Select(transition => 
                        GetTransitionRepresentation(
                            source.ToString(),
                            transition.Input.ToString(),
                            transition.ResultantState.ToString(),
                            transition.Guard?.Description)));

                if (state.OnEntry != null)
                {
                    onEntryActionLines.Add($" {state.Value} -> \"{state.OnEntry.Description ?? state.OnEntry.ConnectorKey}\" [label=\"On Entry\" style=dotted];");
                }
            }

            if (onEntryActionLines.Count > 0)
            {
                lines.Add(" node [shape=box];");

                lines.AddRange(onEntryActionLines);
            }

            return "digraph {" + "\r\n" +
                     string.Join("\r\n", lines) + "\r\n" +
                   "}";
        }

        private static string GetTransitionRepresentation(string sourceState, string input, string destination, string guardDescription)
        {
            return string.IsNullOrWhiteSpace(guardDescription) 
                ? $" \"{sourceState}\" -> \"{destination}\" [label=\"{input}\"];" 
                : $" \"{sourceState}\" -> \"{destination}\" [label=\"{input} ({guardDescription})\"];";
        }
    }
}