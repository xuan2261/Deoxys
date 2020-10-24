﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using AsmResolver;
using Deoxys.Core;
using Deoxys.Core.Disassembly;

namespace Deoxys.Pipeline.DevirtualizationStages
{
    public class MethodDisassembly : IDevirtualizationStage
    {
        public string Name => nameof(MethodDisassembly);
        public bool Execute(DeoxysContext context)
        {
            context.DevirtualizedMethods = DisassembleAllMethods(context);
            return context.DevirtualizedMethods.Count == context.VirtualizedMethods.Count;
            //TODO: fixups ig
        }

        public List<NashaMethod> DisassembleAllMethods(DeoxysContext context)
        {
            List<NashaMethod> nashaMethods = new List<NashaMethod>();
            var methodDisassembler = new NashaMethodDisassembler(context);
            foreach (var method in context.VirtualizedMethods)
            {
                nashaMethods.Add(methodDisassembler.DisassembleMethod(method));
            }
            return nashaMethods;
        }
    }
}