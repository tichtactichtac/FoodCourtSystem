﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace FoodCourtSystem.Models
{
    public class AccountFundModel
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public int Balance { get; set; }
    }

    public class ChargeAccountViewModel
    {
        public string UserName { get; set; }
        [Required]
        [Range(50000, 1000000, ErrorMessage ="Số tiền nạp tối thiểu là 50000 và tối đa là 1000000")]
        public int Amount { get; set; }
    }

    public class FundDbContext : DbContext 
    {
        public FundDbContext():base("FundContext")
        { }
        public DbSet<AccountFundModel> accountFunds { get; set; }

        public System.Data.Entity.DbSet<FoodCourtSystem.Models.PaymentRequestModel> PaymentRequestModels { get; set; }
    }

}