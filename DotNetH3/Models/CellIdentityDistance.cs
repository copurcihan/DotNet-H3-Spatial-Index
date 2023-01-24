namespace DotNetH3.Models;

public record CellIdentityDistance(string Index, int Resolution, int Distance) : CellIdentity(Index, Resolution);