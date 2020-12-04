using DesafioTecnicoMP.Interfaces;
using DesafioTecnicoMP.Models;
using System;
using System.Linq;

namespace DesafioTecnicoMP
{
    public class ArgumentsFactory
    {
        private readonly string[] _applicationArguments;
        private readonly string[] _enabledArguments;

        public ArgumentsFactory(string[] applicationArguments, params string[] enabledArguments)
        {
            _applicationArguments = applicationArguments;
            _enabledArguments = enabledArguments;
        }

        public IApplicationArgument GetArgument(string argumentName)
        {
            if (!ArgumentIsEnabled(argumentName))
                throw new ApplicationArgumentException($"Argument ({argumentName}) it is not enabled on this application.");

            IApplicationArgument applicationArgument = null;

            try
            {
                foreach (var argument in _applicationArguments)
                {
                    if (argumentName == "-f" && argument == argumentName)
                    {
                        applicationArgument = new FileSizeArgument(GetArgValue<long>(argument));
                    }
                    else if (argument == "-b" && argument == argumentName)
                    {
                        applicationArgument = new BufferLengthArgument(GetArgValue<long>(argument));
                    }
                    else if (argument == "-p" && argument == argumentName)
                    {
                        applicationArgument = new PathArgument(GetArgValue<string>(argument));
                    }
                }
            }
            catch(ApplicationArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                throw ex;
            }

            return applicationArgument;
        }

        private T GetArgValue<T>(string argumentName)
        {
            T argValue = default;
            for (var i = 0; i < _applicationArguments.Length; i++)
            {
                if (_applicationArguments[i] == argumentName)
                {
                    try
                    {
                        argValue = (T)Convert.ChangeType(_applicationArguments[i + 1], typeof(T));
                    }
                    catch (Exception)
                    {
                        throw new ArgumentException("An error occurred while running the application with the parameters.");
                    }
                }
            }
            return argValue;
        }

        private bool ArgumentIsEnabled(string argument)
        {
            return _enabledArguments.Any(x => x == argument);
        }
    }
}
