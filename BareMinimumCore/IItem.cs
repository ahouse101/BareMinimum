namespace BareMinimumCore
{
    public interface IItem
    {
		// Properties for display:
		string Name { get; set; }
        string Notes { get; set; }
		
		// Non-display properties:
		ItemContainer Parent { get; }
		int Level { get; }
    }
}