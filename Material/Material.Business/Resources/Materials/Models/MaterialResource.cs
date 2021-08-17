namespace Material.Business.Resources.Materials.Models
{
    public class MaterialResource
    {
        public string Id { get; }

        public string Name { get; }

        public bool IsVisible { get; }

        public MaterialResourceTypeOfPhase TypeOfPhase { get; }

        public MaterialFunctionResource MaterialFunction { get; }

        public MaterialResource(
            string id,
            string name,
            bool isVisible,
            MaterialResourceTypeOfPhase typeOfPhase,
            MaterialFunctionResource materialFunction)
        {
            Id = id;
            Name = name;
            IsVisible = isVisible;
            TypeOfPhase = typeOfPhase;
            MaterialFunction = materialFunction;
        }

        public MaterialResource(
            string name,
            bool isVisible,
            MaterialResourceTypeOfPhase typeOfPhase,
            MaterialFunctionResource materialFunction)
        {
            Name = name;
            IsVisible = isVisible;
            TypeOfPhase = typeOfPhase;
            MaterialFunction = materialFunction;
        }
    }
}
