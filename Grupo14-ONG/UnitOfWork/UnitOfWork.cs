using Grupo14_ONG.Repositories;
using Grupo14_ONG.Repositories.Implements;
using Grupo14_ONG_DA.DataAccess;
using System;


namespace Grupo14_ONG.UnitWork
{
    public class UnitOfWork : IDisposable
    {
        private readonly Context context = new Context();

        private ISystemRepository systemRepository;

        private IUserRepository userRepository;

        private IProjectRepository projectRepository;

        private IMultiMediaRepository multiMediaRepository;

        private IRolRepository rolRepository;
    

        private IOngPartnerRepository ongPartnerRepository;

        private IProvinceRepository provinceRepository;

        private IOngTypeRepository ongTypeRepository;


        public IOngTypeRepository ONGTypeRepository {
            get
            {
                if (this.ongTypeRepository == null)
                {

                    this.ongTypeRepository = new ONGtypeRepository(context);
                }
                return ongTypeRepository;
            }

        }

        public IProvinceRepository ProvinceRepository {

            get {
                if (this.provinceRepository == null) 
                {

                    this.provinceRepository = new ProvinceRepository(context);
                }
                return provinceRepository;
                }
        
        
        }


        public IOngPartnerRepository OngPartnerRepository
        {
            get
            {
                if (this.ongPartnerRepository == null)
                {
                    this.ongPartnerRepository = new OngPartnerRepository(context);
                }
                return ongPartnerRepository;
            }
        }
        public ISystemRepository SystemRepository
        {
            get
            {
                if(this.systemRepository == null)
                {
                    this.systemRepository = new SystemRepository(context);
                }
                return systemRepository;
            }
        }
        
        public IUserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(context);
                }
                return userRepository;
            }
        }

        public IMultiMediaRepository MultiMediaRepository
        {
            get
            {
                if (this.multiMediaRepository == null)
                {
                    this.multiMediaRepository = new MultiMediaRepository(context);
                }
                return multiMediaRepository;
            }
        }

        public IProjectRepository ProjectRepository
        {
            get
            {
                if (this.projectRepository == null)
                {
                    this.projectRepository = new ProjectRepository(context);
                }
                return projectRepository;
            }
        }

        public IRolRepository RolRepository
        {
            get
            {
                if (this.rolRepository == null)
                {
                    this.rolRepository = new RolRepository(context);
                }
                return rolRepository;
            }
        }

        public bool Save() //retorna 1 si las filas fueron afectadas
        {
            bool save = false;
            if (context.SaveChanges() > 0)
            {
                save = true;
            }
            return save;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}