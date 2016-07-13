using MyClassShop.Data.Infrastructure;
using MyClassShop.Data.Reponsitories;
using MyClassShop.Model.Models;

namespace MyClassShop.Service
{
    public interface IErrorService
    {
        Error Create(Error error);

        void Save();
    }

    public class ErrorService : IErrorService
    {
        private IErrorRepositoty _errorRepository;
        private IUnitOfWork _unitOfWork;

        public ErrorService(IErrorRepositoty errorRepositoty, IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorRepositoty;
            this._unitOfWork = unitOfWork;
        }

        public Error Create(Error error)
        {
            return _errorRepository.Add(error);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}