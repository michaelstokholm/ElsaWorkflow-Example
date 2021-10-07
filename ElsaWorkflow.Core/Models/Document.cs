﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElsaWorkflow.Core.Models
{
    public class Document
    {
        public string Id { get; set; } = default!;
        public string DocumentTypeId { get; set; } = default!;
        public string FileName { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public string? Notes { get; set; }
        public DocumentStatus Status { get; set; }
    }
}
