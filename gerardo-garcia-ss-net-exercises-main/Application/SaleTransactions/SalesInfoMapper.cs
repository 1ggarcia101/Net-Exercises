using Application.SaleTransactions.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SaleTransactions
{
    public static class SaleInfoMapper
    {
        public static SaleTransaction MapToSaleTransaction(SaleInfoModel saleInfo)
        {
            return new SaleTransaction
            {
                Date = saleInfo.Date,
                PaymentMethodType = saleInfo.PaymentMethodType,
                // You may need to map other properties if they exist
            };
        }
    }
}
