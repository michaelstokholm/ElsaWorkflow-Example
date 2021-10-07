using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elsa.ActivityResults;
using Elsa.Attributes;
using Elsa.Expressions;
using Elsa.Providers.WorkflowStorage;
using Elsa.Services;
using Elsa.Services.Models;
using ElsaWorkflow.Core.Models;
using ElsaWorkflow.Core.Services;

namespace ElsaWorkflow.Workflows.Activities
{
    [Action(Category = "Document Management", Description = "Gets the specified document from the database.")]
    public class GetDocument : Activity
    {
        [ActivityInput(Label = "Document ID", Hint = "The ID of the document to load", SupportedSyntaxes = new [] { SyntaxNames.JavaScript, SyntaxNames.Liquid })]
        public string DocumentId { get; set; } = default!;
        
        [ActivityOutput(Hint = "the document + file", DefaultWorkflowStorageProvider = TransientWorkflowStorageProvider.ProviderName)]
        public DocumentFile Output { get; set; } = default!;

        private readonly IDocumentStore _documentStore;
        private readonly IFileStorage _fileStorage;

        public GetDocument(IDocumentStore documentStore, IFileStorage fileStorage)
        {
            _documentStore = documentStore;
            _fileStorage = fileStorage;
        }

        protected override async ValueTask<IActivityExecutionResult> OnExecuteAsync(ActivityExecutionContext context)
        {
            var document = await _documentStore.GetAsync(DocumentId, context.CancellationToken);
            var fileStream = await _fileStorage.ReadAsync(document!.FileName, context.CancellationToken);

            Output = new DocumentFile(document, fileStream);
            return Done();
        }
    }

    public record DocumentFile(Document Document, Stream FileStream);
}
