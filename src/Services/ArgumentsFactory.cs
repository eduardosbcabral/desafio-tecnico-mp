using DesafioTecnicoMP.Exceptions;
using DesafioTecnicoMP.Interfaces;
using DesafioTecnicoMP.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioTecnicoMP.Services
{
    public class ArgumentsFactory
    {
        private readonly string[] _enabledArguments;

        private readonly IDictionary<string, string> _mappedArguments;

        private const char ARGUMENT_PREFIX = '-';

        private readonly IDictionary<string, Func<string, IApplicationArgument>> _arguments
            = new Dictionary<string, Func<string, IApplicationArgument>>()
        {
            { ArgumentsConstants.FILE_SIZE_ARGUMENT, (argValue) => new FileSizeArgument(argValue) },
            { ArgumentsConstants.BUFFER_LENGTH_ARGUMENT, (argValue) => new BufferLengthArgument(argValue) },
            { ArgumentsConstants.PATH_ARGUMENT, (argValue) => new PathArgument(argValue) },
        };

        public ArgumentsFactory(string[] applicationArguments, params string[] enabledArguments)
        {
            _enabledArguments = enabledArguments;
            _mappedArguments = MapArguments(applicationArguments);
        }

        public T CreateArgument<T>(string argumentName) where T : IApplicationArgument
        {
            if (!ArgumentIsEnabled(argumentName))
                throw new ApplicationArgumentException($"Argument ({argumentName}) it is not enabled on this application.");

            IApplicationArgument applicationArgument = null;

            try
            {
                applicationArgument = _arguments[argumentName].Invoke(_mappedArguments[argumentName]);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                throw ex;
            }

            return (T)applicationArgument;
        }

        private IDictionary<string, string> MapArguments(string[] applicationArguments)
        {
            IDictionary<string, string> mappedArguments = new Dictionary<string, string>();

            for(var i = 0; i < applicationArguments.Length; i++)
            {
                if (applicationArguments[i].Contains(ARGUMENT_PREFIX))
                {
                    mappedArguments.Add(new KeyValuePair<string, string>(
                        applicationArguments[i],
                        applicationArguments[i + 1] ?? string.Empty
                    ));
                }
            }

            return mappedArguments;
        }

        private bool ArgumentIsEnabled(string argument)
        {
            return _enabledArguments.Any(x => x == argument);
        }
    }
}
