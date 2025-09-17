using Application.Exceptions;
using Application.UnitOfWork;
using AutoMapper;
using MediatR;

namespace Application.Features.Company.Commands.Create
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateCompanyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.CompanyRepository.FindByIdAsync(request.Id);
            if (company is null) throw new EntityIsNotFoundException("Company bulunamadı");

            var updatedCompany = _mapper.Map<Domain.Entities.Company>(request);
            _unitOfWork.CompanyRepository.Update(updatedCompany);
            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
