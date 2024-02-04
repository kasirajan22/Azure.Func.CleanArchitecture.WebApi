using InfrastructureLayer;

namespace ApplicationLayer;

public abstract class ApplicationBase
{
    protected readonly IRepositoryWrapper _repository;

    public ApplicationBase(IRepositoryWrapper repository) => _repository = repository;
}
