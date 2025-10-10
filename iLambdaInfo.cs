using OutSystems.ExternalLibraries.SDK;

namespace LambdaResources
{
    /// <summary>
    /// Provides information about the current Lambda environment (CPU, Memory, etc.)
    /// </summary>
    [OSInterface(
        Description = "AWS Lambda environment information: memory, CPU count, and current usage.",
        Name = "LambdaInfo"
    )]
    public interface ILambdaInfo
    {
        /// <summary>
        /// Returns the current Lambda memory limit (MB), CPU count, and current memory usage.
        /// </summary>
        [OSAction(
            Description = "Get Lambda runtime information (memory, CPU count, and current memory usage)."
        )]
        void GetLambdaRuntimeInfo(out int LambdaMemoryLimitMB, out int CpuCount, out double CurrentMemoryUsageMB);
    }
}
