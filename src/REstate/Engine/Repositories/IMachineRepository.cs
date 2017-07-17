using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System;
using REstate.Schematics;

namespace REstate.Engine.Repositories
{
    public interface IMachineRepository<TState, TInput>
    {
        Task CreateMachineAsync(string schematicName, string machineId, IDictionary<string, string> metadata, CancellationToken cancellationToken = default(CancellationToken));

        Task CreateMachineAsync(Schematic<TState, TInput> schematic, string machineId, IDictionary<string, string> metadata, CancellationToken cancellationToken = default(CancellationToken));

        Task CreateMachineAsync(string schematicName, string machineId, CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteMachineAsync(string machineId, CancellationToken cancellationToken = default(CancellationToken));

        Task<State<TState>> GetMachineStateAsync(string machineId, CancellationToken cancellationToken = default(CancellationToken));

        Task<State<TState>> SetMachineStateAsync(string machineId, TState state, TInput input, Guid? lastCommitTag, CancellationToken cancellationToken = default(CancellationToken));

        Task<State<TState>> SetMachineStateAsync(string machineId, TState state, TInput input, string parameterData, Guid? lastCommitTag, CancellationToken cancellationToken = default(CancellationToken));

        Task<IDictionary<string, string>> GetMachineMetadataAsync(string machineId, CancellationToken cancellationToken = default(CancellationToken));
    }
}
