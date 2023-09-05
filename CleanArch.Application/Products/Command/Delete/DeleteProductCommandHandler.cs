using CleanArch.Application.Common.Exceptions;
using CleanArch.Application.Data.Interfaces;
using MediatR;

namespace CleanArch.Application.Products.Command.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var check_product = await _unitOfWork.Products.GetByIDAsync(request.Id);

        if(check_product is null)
        {
            throw new NotFoundException(request.Id);
        }
        _unitOfWork.Products.Delete(check_product);
        await _unitOfWork.SaveChangeAsync(cancellationToken);
    }
}