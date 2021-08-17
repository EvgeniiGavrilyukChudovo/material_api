namespace Material.Application.Resources.Materials.V1
{
    public class MaterialFunctionV1InModel
    {
        public double MinTemperature { get; set; }

        public double MaxTemperature { get; set; }

        public MaterialFunctionV1InModel(double minTemperature, double maxTemperature)
        {
            MinTemperature = minTemperature;
            MaxTemperature = maxTemperature;
        }

        public MaterialFunctionV1InModel()
        { }
    }
}
