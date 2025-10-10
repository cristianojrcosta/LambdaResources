using System;
using System.Diagnostics;

namespace LambdaResources
{
    /// <summary>
    /// Implements Lambda environment info retrieval.
    /// </summary>
    public class LambdaInfo : ILambdaInfo
    {
        public void GetLambdaRuntimeInfo(out int LambdaMemoryLimitMB, out int CpuCount, out double CurrentMemoryUsageMB)
        {
            try
            {
                // Lambda memory limit from environment variable
                var memoryEnv = Environment.GetEnvironmentVariable("AWS_LAMBDA_FUNCTION_MEMORY_SIZE");
                int.TryParse(memoryEnv, out LambdaMemoryLimitMB);

                // CPU count available to the container
                CpuCount = Environment.ProcessorCount;

                // Current process memory usage (MB)
                var process = Process.GetCurrentProcess();
                CurrentMemoryUsageMB = Math.Round(process.WorkingSet64 / (1024.0 * 1024.0), 2);
            }
            catch (Exception ex)
            {
                // Return safe defaults on error
                LambdaMemoryLimitMB = -1;
                CpuCount = -1;
                CurrentMemoryUsageMB = -1;

                Console.WriteLine($"[LambdaInfo] Error: {ex.Message}");
            }
        }
    }
}
