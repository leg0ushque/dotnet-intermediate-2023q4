using AutoMapper;
using CatalogService.BusinessLogic.Exceptions;
using CatalogService.BusinessLogic.Validators;
using CatalogService.DataAccess.Entities;
using CatalogService.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.BusinessLogic.Services
{
    public class GenericEntityService<TEntity, TEntityDto> : IService<TEntityDto>
        where TEntity : class, IEntity
        where TEntityDto : class
    {
        private readonly IValidator<TEntityDto> _validator;
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public GenericEntityService(IValidator<TEntityDto> validator, IRepository<TEntity> repository, IMapper mapper)
        {
            _validator = validator;
            _repository = repository;
            _mapper = mapper;
        }

        public Task<int> CreateAsync(TEntityDto entity, CancellationToken cancellationToken = default)
        {
            _validator.Validate(entity);
            return _repository.CreateAsync(_mapper.Map<TEntity>(entity), cancellationToken);
        }

        public Task DeleteAsync(int entityId, CancellationToken cancellationToken = default)
        {
            try
            {
                return _repository.DeleteAsync(entityId, cancellationToken);
            }
            catch (ArgumentException)
            {
                throw new BusinessLogicException($"There is no {nameof(TEntity)} found by Id='{entityId}' to delete.");
            }
        }

        public async Task<IReadOnlyCollection<TEntityDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return _mapper.Map<List<TEntityDto>>(
                    await _repository.GetAll().ToListAsync(cancellationToken))
                .AsReadOnly();
        }

        public async Task<TEntityDto> GetById(int entityId, CancellationToken cancellationToken = default)
        {
            try
            {
                return _mapper.Map<TEntityDto>(
                    await _repository.GetByIdAsync(entityId, cancellationToken));
            }
            catch (ArgumentException)
            {
                throw new BusinessLogicException($"There is no {nameof(TEntity)} found by Id='{entityId}'.");
            }
        }

        public Task UpdateAsync(TEntityDto entity, CancellationToken cancellationToken = default)
        {
            int entityId = Constants.DefaultId;

            try
            {
                _validator.Validate(entity, cancellationToken);
                var mappedEntity = _mapper.Map<TEntity>(entity);
                entityId = mappedEntity.Id;

                return _repository.CreateAsync(mappedEntity, cancellationToken);
            }
            catch (ArgumentException)
            {
                throw new BusinessLogicException($"There is no {nameof(TEntity)} found by Id='{entityId}' to update.");
            }
        }
    }
}
