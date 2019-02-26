using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondSightWeb.Models
{


    public class Disposables
    {
        [Key]
        public int DisposableId { get; set; }

        public string DisposableName { get; set; }

        public bool IsDeleted { get; set; } = false;

    }

}