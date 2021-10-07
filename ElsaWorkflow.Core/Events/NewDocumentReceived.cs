using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElsaWorkflow.Core.Models;
using MediatR;

namespace ElsaWorkflow.Core.Events
{
    public record NewDocumentReceived(Document Document) : INotification;
}
