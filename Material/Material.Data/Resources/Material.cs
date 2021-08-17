using Material.Core.Infrastructure.Database;

namespace Material.Data.Resources
{
    public class Material : IIdentity<string>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public bool IsVisible { get; set; }

        public MaterialTypeOfPhase TypeOfPhase { get; set; }

        public MaterialFunction MaterialFunction { get; set; }

        public Material(
            string id,
            string name,
            bool isVisible,
            MaterialTypeOfPhase typeOfPhase,
            MaterialFunction materialFunction)
        {
            Id = id;
            Name = name;
            IsVisible = isVisible;
            TypeOfPhase = typeOfPhase;
            MaterialFunction = materialFunction;
        }

        public Material()
        { }
    }
}
