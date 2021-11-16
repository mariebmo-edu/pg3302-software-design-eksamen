using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PG332_SoftwareDesign_EksamenH21.Handlers;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21
{
    public interface IPrintable<T>
    {
        List<T> Options { get; set; }
        OptionsHandler SuperOption { get; set; }
        public IPrintable<T> ChooseOption(string input);
    }
}