namespace CamelFlow_Backend.Data
{
    public class ItemDefinition
    {
        public string Name { get; set; } = string.Empty;
        public string Hint { get; set; } = string.Empty;
        public ItemDefinitionTypes Type { get; set; }
        public string? Options { get; set; }
        public ItemDefinition[]? ListItemDefinition { get; set; }
    }

    public enum ItemDefinitionTypes
    {
        Text,
        Number,
        Select,
        List
    }
}
