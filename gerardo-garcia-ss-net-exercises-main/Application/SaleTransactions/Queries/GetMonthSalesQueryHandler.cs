using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.SaleTransactions.Dtos;
using Application.SaleTransactions.Queries;
using Common.Persistence;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.SaleTransactions.Queries
{
    public class GetMonthSalesQueryHandler : IRequestHandler<GetMonthSalesQuery, List<SaleInfoModel>>
    {
        private readonly IRepository _repository;

        public GetMonthSalesQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SaleInfoModel>> Handle(GetMonthSalesQuery request, CancellationToken cancellationToken)
        {
            // Calculate the start and end dates of the specified month
            var startDate = new DateTime(request.Year, request.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            // Query the repository to retrieve sale records within the specified month
            var saleTransactions = await _repository.Query<SaleTransaction>()
                .Where(s => s.Date >= startDate && s.Date <= endDate)
                .ToListAsync(cancellationToken);

            // Map SaleTransaction entities to SaleInfoModel DTOs
            var sales = saleTransactions.Select(s => new SaleInfoModel
            {
                Date = s.Date,
                PaymentMethodType = s.PaymentMethodType
            }).ToList();

            return sales;
        }
    }

}
