namespace Material.Application.Resources.Materials.V1
{
    public class MaterialFunctionV1OutModel
    {
        public double MinTemperature { get; }

        public double MaxTemperature { get; }

        public MaterialFunctionV1OutModel(double minTemperature, double maxTemperature)
        {
            MinTemperature = minTemperature;
            MaxTemperature = maxTemperature;
        }
    }
}
