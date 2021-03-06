﻿using System.Collections.Generic;
using AsmResolver.DotNet;
using AsmResolver.PE.File;

namespace Deoxys.Core
{
    public class DeoxysContext
    {
        public DeoxysContext(DeoxysOptions options, ILogger logger)
        {
            Options = options;
            Module = ModuleDefinition.FromFile(options.FilePath);
            PeFile = PEFile.FromFile(options.FilePath);
            Logger = logger;
            VirtualizedMethods = new List<NashaMethodInfo>();
            DeoxysOpCodes = new Dictionary<int, NashaOpCode>();
            DisassembledVirtualizedMethods = new List<NashaMethod>();
        }

        public DeoxysOptions Options { get; set; }
        public ModuleDefinition Module { get; set; }
        public PEFile PeFile { get; set; }
        public ILogger Logger { get; set; }

        public PESection Nasha0 { get; set; }
        public PESection Nasha1 { get; set; }
        public PESection Nasha2 { get; set; }
        public FieldDefinition Cfg { get; set; }
        public List<NashaMethodInfo> VirtualizedMethods { get; set; }
        public Dictionary<int,NashaOpCode> DeoxysOpCodes { get; set; }
        public List<NashaMethod> DisassembledVirtualizedMethods { get; set; }
    }
}