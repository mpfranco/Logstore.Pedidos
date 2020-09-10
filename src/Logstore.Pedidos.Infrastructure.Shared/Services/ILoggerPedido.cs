﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Logstore.Pedidos.Infrastructure.Shared.Services
{
    public interface ILoggerPedido
    {
        Guid TraceId { get; }
        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="message">mensagem a ser logada</param>
        void LogDebug(string message);
        /// <summary>
        /// Log de error
        /// </summary>
        /// <param name="message">mensagem a ser logada</param>
        void LogError(string message);
        /// <summary>
        /// Log de error
        /// </summary>
        /// <param name="exception">erro</param>
        void LogError(Exception exception);
        /// <summary>
        /// Log de information
        /// </summary>
        /// <param name="message">mensagem a ser logada</param>
        void LogInformation(string message);
    }
}
