﻿using System;
using System.Collections.Generic;

namespace Policy.Logger
{
    public partial class SysLog
    {
        public string? LogDetails { get; set; }
        public int Id { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
