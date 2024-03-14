﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BusinessObject
{
    public partial class ServiceType
    {
        public ServiceType()
        {
            Services = new HashSet<Service>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}
