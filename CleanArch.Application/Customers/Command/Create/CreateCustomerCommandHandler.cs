using CleanArch.Application.Common.Customers;
using CleanArch.Application.Data.Interfaces;
using CleanArch.Domain.Common.Errors;
using CleanArch.Domain.Customers;
using ErrorOr;
using MediatR;

namespace CleanArch.Application.Customers.Command.Create
{
    internal class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ErrorOr<CustomerResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<CustomerResult>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var newCustomerId = new CustomerId(Guid.NewGuid());
            
            var check_product = await _unitOfWork.Customers.GetByIDAsync(newCustomerId);

            if(check_product is not null)
            {
                return Errors.Product.DuplicateProduct;
            }
            //var newGuid = Guid.Parse("5E2AB0D2-F545-488A-A280-0CCE48F83027");

            var customer = new Customer(
                newCustomerId,
                request.Name,
                request.Email
            );
            _unitOfWork.Customers.Add(customer);
            await _unitOfWork.SaveChangeAsync(cancellationToken);
            return new CustomerResult(customer);
        }
    }
}