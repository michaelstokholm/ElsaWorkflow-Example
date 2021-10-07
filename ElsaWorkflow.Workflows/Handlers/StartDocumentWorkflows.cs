using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Elsa.Models;
using Elsa.Services;
using ElsaWorkflow.Core.Events;
using MediatR;

namespace ElsaWorkflow.Workflows.Handlers
{
    /// <summary>
    /// Handles the <see cref="NewDocumentReceived"/> event by starting the HelloFile workflow.
    /// </summary>
    public class StartDocumentWorkflows : INotificationHandler<NewDocumentReceived>
    {
        private readonly IWorkflowRegistry _workflowRegistry;
        private readonly IWorkflowDefinitionDispatcher _workflowDispatcher;

        public StartDocumentWorkflows(IWorkflowRegistry workflowRegistry, IWorkflowDefinitionDispatcher workflowDispatcher)
        {
            _workflowRegistry = workflowRegistry;
            _workflowDispatcher = workflowDispatcher;
        }

        public async Task Handle(NewDocumentReceived notification, CancellationToken cancellationToken)
        {
            var document = notification.Document;

            // Get our HelloFile workflow.
            var workflow = await _workflowRegistry.FindAsync(x => x.Name == "HelloFile" && x.IsPublished && x.Tag == document.DocumentTypeId, cancellationToken);

            if (workflow == null)
                return; // Do nothing.

            // Dispatch the workflow.
            await _workflowDispatcher.DispatchAsync(new ExecuteWorkflowDefinitionRequest(workflow!.Id, CorrelationId: document.Id, Input: new WorkflowInput(document.Id)), cancellationToken);
        }
    }
}
