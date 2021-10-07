using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElsaWorkflow.Core.Services
{
    public interface ISystemClock
    {
        DateTime UtcNow { get; }
    }
}
