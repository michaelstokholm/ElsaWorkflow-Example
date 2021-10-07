using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Elsa.Scripting.Liquid.Messages;
using ElsaWorkflow.Core.Models;
using ElsaWorkflow.Workflows.Activities;
using Fluid;
using MediatR;

namespace ElsaWorkflow.Workflows.Scripting.Liquid
{
    public class ConfigureLiquidEngine : INotificationHandler<EvaluatingLiquidExpression>
    {
        public Task Handle(EvaluatingLiquidExpression notification, CancellationToken cancellationToken)
        {
            var memberAccessStrategy = notification.TemplateContext.Options.MemberAccessStrategy;

            memberAccessStrategy.Register<Document>();
            memberAccessStrategy.Register<DocumentFile>();

            return Task.CompletedTask;
        }
    }
}
