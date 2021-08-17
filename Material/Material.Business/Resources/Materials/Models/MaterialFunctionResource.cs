namespace Material.Business.Resources.Materials.Models
{
    public class MaterialFunctionResource
    {
        public double MinTemperature { get; }

        public double MaxTemperature { get; }

        public MaterialFunctionResource(double minTemperature, double maxTemperature)
        {
            MinTemperature = minTemperature;
            MaxTemperature = maxTemperature;
        }
    }
}
