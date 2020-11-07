
using System.Collections.Generic;

namespace MilitaryElite.Contracts
{
    interface ILieutenantGeneral : IPrivate
    {
      public  IReadOnlyCollection<ISoldier> Privates { get; }

       public void AddPrivate(ISoldier @private)
        {
        }
    }

   
}
