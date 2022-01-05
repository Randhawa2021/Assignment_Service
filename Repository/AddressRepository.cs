using ASG_ADAC_FE.ContextADAC;
using ASG_ADAC_FE.CoreModels;

namespace ASG_ADAC_FE.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private DbContextADAC _dbContextADAC;
        public AddressRepository(DbContextADAC dbContextADAC)
        {
            _dbContextADAC = dbContextADAC;
        }

        
    }
}
