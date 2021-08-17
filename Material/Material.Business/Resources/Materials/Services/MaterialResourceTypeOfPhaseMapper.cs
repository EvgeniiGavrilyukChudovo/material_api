using System;
using Material.Business.Resources.Materials.Models;
using Material.Data.Resources;

namespace Material.Business.Resources.Materials
{
    public static class MaterialResourceTypeOfPhaseMapper
    {
        public static MaterialResourceTypeOfPhase MapFromEntity(MaterialTypeOfPhase type)
        {
            switch (type)
            {
                case MaterialTypeOfPhase.Liquid:
                    return MaterialResourceTypeOfPhase.Liquid;
                case MaterialTypeOfPhase.Solid:
                    return MaterialResourceTypeOfPhase.Solid;
                default:
                    throw new NotImplementedException();
            }
        }

        public static MaterialTypeOfPhase MapFromResource(MaterialResourceTypeOfPhase type)
        {
            switch (type)
            {
                case MaterialResourceTypeOfPhase.Liquid:
                    return MaterialTypeOfPhase.Liquid;
                case MaterialResourceTypeOfPhase.Solid:
                    return MaterialTypeOfPhase.Solid;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
