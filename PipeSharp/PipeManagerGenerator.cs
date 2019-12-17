using System;
using System.IO;
using System.Text;

namespace PipeSharp
{
    public class PipeManagerGenerator
    {
        public virtual void GeneratePipeManagerCs(string directory = "", int loop = 15)
        {
            string pipeManagerString = GetPipeManagerString(loop);
            if (string.IsNullOrWhiteSpace(directory))
            {
                directory = AppDomain.CurrentDomain.BaseDirectory;
            }

            System.IO.File.WriteAllText(directory + "PipeManager.cs", pipeManagerString);
        }

        public virtual string GetPipeManagerString(int loop = 15)
        {
            var pipeManagerTemplate = GetPipeManagerTemplate();
            var functionsString = GetFunctionsString(loop);

            var formatResult = string.Format(pipeManagerTemplate, functionsString);
            return formatResult.Replace("###", "{").Replace("##", "}");
        }

        protected virtual string GetFunctionsString(int loop = 15)
        {
            /*
             *  public static T Pipe<T, TO1>(this T arg0, Func<T, TO1> func1, Func<TO1, T> func2)
                {
                    return func2.Invoke(func1.Invoke(arg0));
                }
             */
            StringBuilder sb = new StringBuilder();

            string pattern = GetPipeFunctionTemplate();

            for (int i = 1; i < loop + 1; i++)
            {
                StringBuilder p0 = new StringBuilder();
                StringBuilder p1 = new StringBuilder();
                StringBuilder p2 = new StringBuilder();
                StringBuilder p3 = new StringBuilder();
                for (int j = 1; j <= i; j++)
                {
                    p0.Append(", TO" + j);
                    p1.Append($", Func<T{(j - 1 == 0 ? "" : "O" + (j - 1))}, TO{j}> func{j}");
                    p2.Append($"func{i - j + 1}.Invoke(");
                    p3.Append(")");
                }

                var funcStr = string.Format(pattern, p0.ToString(), p1.ToString(), p2.ToString(), p3.ToString(), "TO" + i);
                sb.Append(funcStr.Replace("###", "{").Replace("##", "}"));
            }

            return sb.ToString();
        }

        protected virtual string GetPipeManagerTemplate()
        {
            var stream = GetType().Assembly.GetManifestResourceStream("PipeSharp.Template.PipeManager.txt");
            if (stream == null)
                throw new Exception("The resource PipeManager was not loaded properly.");

            var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        protected virtual string GetPipeFunctionTemplate()
        {
            var stream = GetType().Assembly.GetManifestResourceStream("PipeSharp.Template.PipeFunction.txt");
            if (stream == null)
                throw new Exception("The resource PipeFunction was not loaded properly.");

            var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
