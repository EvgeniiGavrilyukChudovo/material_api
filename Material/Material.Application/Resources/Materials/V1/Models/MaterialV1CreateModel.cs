namespace Material.Application.Resources.Materials.V1
{
    public class MaterialV1CreateModel
    {
        public string Name { get; set; }

        public bool IsVisible { get; set; }

        public MaterialModelTypeOfPhase TypeOfPhase { get; set; }

        public MaterialFunctionV1InModel MaterialFunction { get; set; }

        public MaterialV1CreateModel(
            string name,
            bool isVisible,
            MaterialModelTypeOfPhase typeOfPhase,
            MaterialFunctionV1InModel materialFunction)
        {
            Name = name;
            IsVisible = isVisible;
            TypeOfPhase = typeOfPhase;
            MaterialFunction = materialFunction;
        }

        public MaterialV1CreateModel()
        { }
    }
}
