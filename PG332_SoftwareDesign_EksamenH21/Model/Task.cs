using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class Task
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public IProgression Progression { get; set; }
    }
}