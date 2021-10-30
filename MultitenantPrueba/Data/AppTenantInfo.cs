﻿using Finbuckle.MultiTenant.Stores;
using Finbuckle.MultiTenant;

namespace MultitenantPrueba.Data
{
    public class AppTenantInfo
    {
        public string Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string ConnectionString { get; set; }
    }
}