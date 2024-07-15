using CleanArch.Domain.Abstractions;
using CleanArch.Infrastructure.Context;
using CleanArch.Infrastructure.Repositories;

namespace CleanArch.Infrastructure.EntityConfiguration
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IMemberRepository? _memberRepository;
        private readonly AppDbContext? _appDbContext;

        public UnitOfWork(AppDbContext? appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IMemberRepository MemberRepository
        {
            get
            {
                return _memberRepository = _memberRepository ?? new MemberRepository(_appDbContext);
            }
        }

        public async Task CommitAsyc()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}
