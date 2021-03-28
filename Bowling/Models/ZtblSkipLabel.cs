using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Bowling.Models
{
    [Table("ztblSkipLabels")]
    public partial class ZtblSkipLabel
    {
        [Key]
        [Column(TypeName = "int")]
        public long LabelCount { get; set; }
    }
}
