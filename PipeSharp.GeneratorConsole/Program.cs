namespace PipeSharp.GeneratorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var pipeManagerGenerator = new PipeManagerGenerator();
            pipeManagerGenerator.GeneratePipeManagerCs();
        }
    }
}
