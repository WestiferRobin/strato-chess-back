using Newtonsoft.Json;

namespace StratoChess {
    public class TestName
{
    [JsonProperty("firstName")]
    public string FirstName { get; set; }

    [JsonProperty("lastName")]
    public string LastName { get; set; }

    public TestName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}
}