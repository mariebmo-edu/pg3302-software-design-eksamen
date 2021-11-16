using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PG332_SoftwareDesign_EksamenH21
{
    public interface IPrintable<T>
    {
        List<T> Options { get; set; }

        public IPrintable<T> ChooseOption(String input);
    }
}