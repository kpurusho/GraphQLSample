using System.Collections.Generic;
using System.Linq;
using App.Data;
using App.Repository;
using GraphQL;

namespace App.Query
{
    public class Query
    {
        [GraphQLMetadata("lot")]
        public Lot GetLot()
        {
            return LotDB.Lot;
        }

        [GraphQLMetadata("wafers")]
        public IEnumerable<Wafer> GetWafers()
        {
            return LotDB.Lot.Wafers;
        }

        [GraphQLMetadata("wafer")]
        public Wafer GetWafer(int id)
        {
            return LotDB.Lot.Wafers.FirstOrDefault(w => w.Id == id);
        }

        [GraphQLMetadata("defects")]
        public IEnumerable<Defect> GetDefects(int waferid)
        {
            return LotDB.Lot.Wafers.FirstOrDefault(w => w.Id == waferid)?.Defects;
        }

        [GraphQLMetadata("defect")]
        public Defect GetDefect(int waferid, int id)
        {
            return LotDB.Lot.Wafers.FirstOrDefault(w => w.Id == waferid)?.Defects.FirstOrDefault(d => d.Id == id);
        }
    }
}