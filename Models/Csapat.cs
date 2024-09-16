namespace Foci_WebApp.Models
{
    public class Csapat
    {
        int helyezes;
        string nev;
        int numberOfMatches;
        int wins;
        int ties;
        int loses;
        int points;
        int goalsScored;
        int goalsTaken;

        public Csapat(string nev, int wins, int ties, int loses, int goalsScored, int goalsTaken)
        {
            this.nev = nev;
            this.numberOfMatches = wins+ties+loses;
            this.wins = wins;
            this.ties = ties;
            this.loses = loses;
            this.points = wins*3+ties;
            this.goalsScored = goalsScored;
            this.goalsTaken = goalsTaken;
        }

        public string Nev { get => nev; set => nev = value; }
        public int NumberOfMatches { get => numberOfMatches; set => numberOfMatches = value; }
        public int Wins { get => wins; set => wins = value; }
        public int Ties { get => ties; set => ties = value; }
        public int Loses { get => loses; set => loses = value; }
        public int Points { get => points; set => points = value; }
        public int GoalsScored { get => goalsScored; set => goalsScored = value; }
        public int GoalsTaken { get => goalsTaken; set => goalsTaken = value; }
        public int Helyezes { get => helyezes; set => helyezes = value; }

        static public string szoveg()
        {
            return "a";
        }

        static public List<Csapat> csapatok = new List<Csapat>();
    }
}