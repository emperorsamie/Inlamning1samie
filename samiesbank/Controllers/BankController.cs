using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using samiesbank.Models;
using samiesbank.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace samiesbank.Controllers
{
    public class BankController : Controller
    {
        public IActionResult Index(TransactionViewModel model = null)
        {
            if (model == null)
            {
                model = new TransactionViewModel();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Deposit(TransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                BankRepository.Deposit(model.DepositAccountId, model.DepositAmount);
            }
            var newModel = new TransactionViewModel();
            newModel.DepositErrorMessage = BankRepository.ErrorMessage;
            newModel.DepositSuccessMessage = BankRepository.SuccessMessage;
            return View("Index", newModel);
        }

        [HttpPost]
        public IActionResult Withdrawal(TransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                BankRepository.Withdrawal(model.WithdrawalAccountId, model.WithdrawalAmount);

            }
            var newModel = new TransactionViewModel();
            newModel.WithdrawalErrorMessage = BankRepository.ErrorMessage;
            newModel.WithdrawalSuccessMessage = BankRepository.SuccessMessage;
            return View("Index", newModel);
        }
    }
}
