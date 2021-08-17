namespace Material.Application.Resources.Materials.V1
{
    public class MaterialV1OutModel
    {
        public string Id { get; }

        public string Name { get; }

        public bool IsVisible { get; }

        public MaterialModelTypeOfPhase TypeOfPhase { get; }

        public MaterialFunctionV1OutModel MaterialFunction { get; }

        public MaterialV1OutModel(
            string id,
            string name,
            bool isVisible,
            MaterialModelTypeOfPhase typeOfPhase,
            MaterialFunctionV1OutModel materialFunction)
        {
            Id = id;
            Name = name;
            IsVisible = isVisible;
            TypeOfPhase = typeOfPhase;
            MaterialFunction = materialFunction;
        }
    }
}
