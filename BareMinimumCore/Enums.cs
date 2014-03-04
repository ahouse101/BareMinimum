namespace BareMinimumCore
{
    public enum ItemType
    {
        None, Section, Grade
    }

	public enum GradeRounding
	{
		Floor, Standard, Ceiling
	}

	[System.Flags]
	public enum ItemFlags
	{
		None = 0x0,
		ExtraCredit = 0x1
	}
}