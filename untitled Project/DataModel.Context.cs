﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace untitled_Project
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class masterEntities : DbContext
    {
        public masterEntities()
            : base("name=masterEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<productDetail> productDetails { get; set; }
        public DbSet<productImage> productImages { get; set; }
    
        public virtual ObjectResult<Nullable<int>> CredentialCheck(string userName, string password)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("CredentialCheck", userNameParameter, passwordParameter);
        }
    
        public virtual ObjectResult<productImage> GetMainImage()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<productImage>("GetMainImage");
        }
    
        public virtual ObjectResult<productImage> GetMainImage(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<productImage>("GetMainImage", mergeOption);
        }
    
        public virtual ObjectResult<Nullable<int>> ValidateLogin(string userName, string password)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("ValidateLogin", userNameParameter, passwordParameter);
        }
    }
}
