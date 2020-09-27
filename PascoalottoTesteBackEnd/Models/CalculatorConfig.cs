using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraDividas.Models
{
    public class CalculatorConfig
    {
        public string InterestType { get; set; }
        public decimal InterestPercentage { get; set; }
        public decimal ComissionPercentage { get; set; }
        public decimal DebtAmount { get; set; }
        public int MonthlyPayments { get; set; }
        public DateTime ExpirationDate { get; set; }


        public Result ApplyRules()
        {
            try
            {
                Result result = new Result();

                if (InterestType.ToLower() == "simples")
                {
                    result.CalculationDate = DateTime.Now;
                    result.DaysOfDelay = (int)(result.CalculationDate - ExpirationDate).TotalDays;
                    result.TotalValue = DebtAmount * (1 + InterestPercentage * result.DaysOfDelay);
                    result.MonthlyPaymentValue = result.TotalValue / MonthlyPayments;
                    result.InterestAmount = result.TotalValue - DebtAmount;
                    result.ComissionAmount = result.TotalValue * ComissionPercentage;

                    return result;
                }
                else if (InterestType.ToLower() == "composto")
                {
                    result.CalculationDate = DateTime.Now;
                    result.DaysOfDelay = (int)(result.CalculationDate - ExpirationDate).TotalDays;
                    result.TotalValue = DebtAmount;

                    for (int i = 0; i < result.DaysOfDelay; i++)
                    {
                        result.TotalValue = result.TotalValue * (1 + InterestPercentage);
                    }

                    result.MonthlyPaymentValue = result.TotalValue / MonthlyPayments;
                    result.InterestAmount = result.TotalValue - DebtAmount;
                    result.ComissionAmount = result.TotalValue * ComissionPercentage;

                    return result;
                }
                else
                {
                    throw new Exception("Tipo de juros invalido, por favor selecione um valor valido. (Simples ou composto)");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class Result
    {
        public decimal TotalValue { get; set; }
        public int DaysOfDelay { get; set; }
        public decimal InterestAmount { get; set; }
        public DateTime CalculationDate { get; set; }
        public decimal MonthlyPaymentValue { get; set; }
        public decimal ComissionAmount { get; set; }
    }
}
