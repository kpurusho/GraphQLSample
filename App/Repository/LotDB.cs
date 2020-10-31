using System.Collections.Generic;
using App.Data;

namespace App.Repository
{
    public static class LotDB
    {
        static LotDB()
        {
            Lot = new Lot
            {
                Id = 1, 
                Name = "LotusLot",
                Wafers = new List<Wafer>
                {
                    new Wafer
                    {
                        Id = 1,
                        Name = "W01",
                        Defects = new List<Defect>
                        {
                            new Defect {Id = 1, X = 10, Y = 10, Classcode = 1, Roughcode = 2},
                            new Defect {Id = 2, X = 10, Y = 10, Classcode = 1, Roughcode = 2}
                        }
                    },
                    new Wafer
                    {
                        Id = 2, 
                        Name = "W02",
                        Defects = new List<Defect>
                        {
                            new Defect {Id = 1, X = 10, Y = 10, Classcode = 1, Roughcode = 1},
                            new Defect {Id = 2, X = 10, Y = 10, Classcode = 1, Roughcode = 2},
                            new Defect {Id = 3, X = 10, Y = 10, Classcode = 1, Roughcode = 3}
                        }
                    }
                }
            };
        }

        public static Lot Lot { get; }
    }
}