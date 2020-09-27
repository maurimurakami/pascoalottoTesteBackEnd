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
                result.CalculationDate = DateTime.Now;
                result.DaysOfDelay = (int)(result.CalculationDate - ExpirationDate).TotalDays;

                if (InterestType.ToLower() == "simples")
                {
                    result.TotalValue = DebtAmount * (1 + InterestPercentage * result.DaysOfDelay);
                }
                else if (InterestType.ToLower() == "composto")
                {
                    result.TotalValue = DebtAmount;
                    for (int i = 0; i < result.DaysOfDelay; i++)
                    {
                        result.TotalValue = result.TotalValue * (1 + InterestPercentage);
                    }
                }

                result.MonthlyPaymentValue = result.TotalValue / MonthlyPayments;
                result.InterestAmount = result.TotalValue - DebtAmount;
                result.ComissionAmount = result.TotalValue * ComissionPercentage;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string IsValid()
        {
            if (!(InterestPercentage > 0 && InterestPercentage <= 1))
            {
                return "Valor de porcentagem de juros(InterestPercentage) invalido. O valor deve ser entre 0-1. Exemplo: 0,002(0,2% ao dia)";
            }
            if (InterestType.ToLower() != "simples" && InterestType.ToLower() != "composto")
            {
                return "Tipo de juros(InterestType) invalido. Escolha entre 'simples' ou 'composto'";
            }
            if (!(ComissionPercentage > 0 && ComissionPercentage <= 1))
            {
                return "Valor de porcentagem de comissao(ComissionPercentage) invalido. O valor deve ser entre 0-1. Exemplo: 0,1(10% de comissao)";
            }
            if (DebtAmount < 0)
            {
                return "Valor de divida(DebtAmount) invalido. Exemplo: 3000 (R$3000,00)";
            }
            if (!(MonthlyPayments > 0))
            {
                return "Numero de parcelas(MonthlyPayments) esta invalido. Exemplo: 3 (3 parcelas)";
            }
            if (ExpirationDate == DateTime.MinValue)
            {
                return "Data de vencimento(ExpirationDate) esta invalido. Preencher no formato correto YYYY-MM-DD. Exemplo: 2020-09-17.";
            }

            return "";
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
