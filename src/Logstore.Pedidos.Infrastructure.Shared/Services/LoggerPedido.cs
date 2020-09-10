﻿using Microsoft.Extensions.Logging;
using System;

namespace Logstore.Pedidos.Infrastructure.Shared.Services
{
    public class LoggerPedido : ILoggerPedido
    {
        readonly ILogger<LoggerPedido> _logger;
        public Guid TraceId { get; private set; }
        public LoggerPedido(ILogger<LoggerPedido> logger)
        {
            _logger = logger;
            TraceId = Guid.NewGuid();
        }

        //<inheritdoc/>
        public void LogDebug(string message)
        {
            _logger.LogDebug($"{GetMessage(message)}");
        }
        //<inheritdoc/>
        public void LogError(string message) => Console.WriteLine($"{GetMessage(message)}");
        //<inheritdoc/>
        public void LogError(Exception exception) => Console.WriteLine(GetExceptionMessage(exception));
        //<inheritdoc/>
        public void LogInformation(string message)
        {
            Console.WriteLine($"{GetMessage(message)}");
        }

        /// <summary>
        /// Formata a mensagem para efetuar o log
        /// </summary>
        /// <param name="message">mensagem</param>
        /// <returns>mensagem formatada</returns>
        private string GetMessage(string message)
        {
            return $"[TraceId:{TraceId}] -> {message.Replace(Environment.NewLine, " ")}";
        }
        /// <summary>
        /// Cria a mensagem de Excecao baseado na Exception
        /// </summary>
        /// <param name="exception">Erro</param>
        /// <param name="message">mensagem</param>
        /// <returns>>mensagem formatada</returns>
        private string GetExceptionMessage(Exception exception, string message = "")
        {
            message += exception.Message;

            if (exception.InnerException != null)
                return GetExceptionMessage(exception.InnerException, message);

            return message;
        }
    }
}
