namespace StudyPerformance.Infrastructure.Utils;

public static class GuidIdMapper
{
    public static Guid FromInt(int? id)
    {
        if (id is null)
            throw new ArgumentNullException(nameof(id));
        return Guid.Parse($"00000000-0000-0000-0000-{id.Value.ToString().PadLeft(12, '0')}");
    }
}
