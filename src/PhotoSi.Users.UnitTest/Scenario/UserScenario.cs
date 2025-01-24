using PhotoSi.Users.Application.Models;

namespace PhotoSi.Users.UnitTest.Scenario;
public class UserScenario
{
    public Dictionary<Guid, User> Users { get; private set; } = [];
    public Dictionary<Guid, Location> Locations { get; private set; } = [];

    public UserScenario()
    {
        Users[ScenarioIds.UserWithLocation] = new(ScenarioIds.UserWithLocation,
                                                  "Mario",
                                                  "Rossi");

        Locations[ScenarioIds.LocationRiccione] = new(ScenarioIds.LocationRiccione,
                                                      ScenarioIds.UserWithLocation,
                                                      "Riccione",
                                                      "RN",
                                                      "ITA",
                                                      "VIA CARPEGNA 22",
                                                      "47838");

        Locations[ScenarioIds.LocationBasiglio] = new(ScenarioIds.LocationBasiglio,
                                                      ScenarioIds.UserWithLocation,
                                                      "Basiglio",
                                                      "MI",
                                                      "ITA",
                                                      "VIA Ennio Doris 15",
                                                      "20079");
    }
}

