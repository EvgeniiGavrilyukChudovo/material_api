using System;
using Material.Business.Resources.Materials.Models;

namespace Material.Application.Resources.Materials.V1
{
    public class MaterialModelTypeOfPhaseV1Mapper
    {
        public static MaterialModelTypeOfPhase MapFromResource(MaterialResourceTypeOfPhase type)
        {
            switch (type)
            {
                case MaterialResourceTypeOfPhase.Liquid:
                    return MaterialModelTypeOfPhase.Liquid;
                case MaterialResourceTypeOfPhase.Solid:
                    return MaterialModelTypeOfPhase.Solid;
                default:
                    throw new NotImplementedException();
            }
        }

        public static MaterialResourceTypeOfPhase MapFromModel(MaterialModelTypeOfPhase type)
        {
            switch (type)
            {
                case MaterialModelTypeOfPhase.Liquid:
                    return MaterialResourceTypeOfPhase.Liquid;
                case MaterialModelTypeOfPhase.Solid:
                    return MaterialResourceTypeOfPhase.Solid;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
