﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.PostContracts
{
    public class UpdatePostRequest
    {
        public int IdPost { get; set; } 
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
    }
}
