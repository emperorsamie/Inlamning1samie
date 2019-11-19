using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace samiesbank.Models.ViewModels
{
    public class TransactionViewModel
    {
        [Required]
        [Display(Name = "Kontonummer")]
        public int WithdrawalAccountId { get; set; }

        [Required]
        [Display(Name = "Summa")]

        public decimal WithdrawalAmount { get; set; }

        public string WithdrawalErrorMessage { get; set; }

        public string WithdrawalSuccessMessage { get; set; }


        [Required]
        [Display(Name = "Kontonummer")]

        public int DepositAccountId { get; set; }

        [Required]
        [Display(Name = "Summa")]

        public decimal DepositAmount { get; set; }

        public string DepositErrorMessage { get; set; }

        public string DepositSuccessMessage { get; set; }

    }
}
