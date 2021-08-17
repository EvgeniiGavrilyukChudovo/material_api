namespace Material.Data.Resources
{
    public class MaterialFunction
    {
        public double MinTemperature { get; }

        public double MaxTemperature { get; }

        public MaterialFunction(double minTemperature, double maxTemperature)
        {
            MinTemperature = minTemperature;
            MaxTemperature = maxTemperature;
        }
    }
}
