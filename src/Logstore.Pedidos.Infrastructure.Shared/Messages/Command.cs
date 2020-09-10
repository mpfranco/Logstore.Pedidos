﻿using MediatR;
using Logstore.Pedidos.Infrastructure.Shared.DomainObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logstore.Pedidos.Infrastructure.Shared.Messages
{
    public abstract class Command : Message, IRequest<ResultCommand>
    {
        public DateTime Timestamp { get; private set; }

        protected Command()
        {

            Timestamp = DateTime.Now;
        }

        public virtual bool IsValidCommand()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class Command<T> : Message, IRequest<ResultCommand<T>>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }
        protected Command()
        {

            Timestamp = DateTime.Now;
        }

        public virtual bool IsValidCommand()
        {
            throw new NotImplementedException();
        }
    }
}
