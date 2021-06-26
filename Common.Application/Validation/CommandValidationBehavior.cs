using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Domain.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Common.Application.Validation
{
    public class CommandValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IList<IValidator<TRequest>> _validators;
        private readonly DbContext _db;
        private readonly ILogger<TRequest> _logger;
        public CommandValidationBehavior(IList<IValidator<TRequest>> validators, DbContext db, ILogger<TRequest> logger)
        {
            _validators = validators;
            _db = db;
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var errors = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();
            try
            {
                if (errors.Any())
                {
                    var errorBuilder = new StringBuilder();

                    foreach (var error in errors)
                    {
                        errorBuilder.AppendLine(error.ErrorMessage);
                    }

                    throw new InvalidCommandException(errorBuilder.ToString(), null);
                }

                var response = await next();

                if (request is ICommitTableRequest)
                {
                    await _db.SaveChangesAsync(cancellationToken);
                }

                return response;
            }
            catch (Exception e)
            {

                if (e is InvalidCommandException)
                    throw new InvalidCommandException(e.Message, null);

                if (e is InvalidDomainDataException)
                    throw new InvalidDomainDataException(e.Message);

                _logger.LogError(e, e.Message);
                throw new Exception(e.Message, e);
            }
        }
    }
}