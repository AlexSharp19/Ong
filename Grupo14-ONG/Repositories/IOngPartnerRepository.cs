using Grupo14_ONG_DA.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupo14_ONG.Repositories
{
    public interface IOngPartnerRepository: IGenericRepository<ONGpartner>
    {
        List<ONGpartner> GetAll(bool isActive);

        void UpdateMultiMediaOngPartner(List<MultiMedia> ListMultiMedia, int partnerId);

        void InsertMultiMediaOngPartner(List<MultiMedia> ListMultiMedia, int PartnerId);
    }
}
