using Newtonsoft.Json;

public class Program
{

    public class Teams
    {
        public string? Competition { get; set; }
        public int Year { get; set; }
        public string? Round { get; set; }
        public string? Team1 { get; set; }
        public string? Team2 { get; set; }
        public string? Team1Goals { get; set; }
        public string? Team2Goals { get; set; }

    }

    public class Dados
    {
        public int Page { get; set; }
        public int Per_Page { get; set; }
        public int Total { get; set; }
        public int Total_pages { get; set; }
        public List<Teams>?  Data { get; set; }

    }

    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static int getTotalScoredGoals(string team, int year)
    {
        var gols = 0;

        using (var client = new HttpClient() ) 
        {

            var team1 = client.GetAsync($"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1={team}").Result;

            if (team1.IsSuccessStatusCode)
            {

                var json = team1.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<Dados>(json);

                if (result != null && result.Data.Any())
                {

                    foreach (var item in result.Data)
                    {

                        gols += Convert.ToInt32(item.Team1Goals);

                    }

                }

            }

            var team2 = client.GetAsync($"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team2={team}").Result;

            if (team2.IsSuccessStatusCode)
            {

                var json = team1.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<Dados>(json);

                if (result != null && result.Data.Any())
                {

                    foreach (var item in result.Data)
                    {

                        gols += Convert.ToInt32(item.Team1Goals);

                    }

                }

            }

        }

        return gols;
        
    }
}