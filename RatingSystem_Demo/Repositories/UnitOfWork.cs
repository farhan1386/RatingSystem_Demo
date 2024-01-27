namespace RatingSystem_Demo.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICompany Companies { get; set; }
        public UnitOfWork(ICompany Companies)
        {
            this.Companies = Companies;
        }
    }
}
