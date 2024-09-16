using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Foci_WebApp.Models;

namespace Foci_WebApp.Pages
{
    public class TabellaModel : PageModel
    {
        private readonly Foci_WebApp.Models.FociDbContext _context;

        public TabellaModel(Foci_WebApp.Models.FociDbContext context)
        {
            _context = context;
        }

        public IList<Meccs> Meccs { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Meccs = await _context.Meccsek.ToListAsync();
            Feltolt();
        }

        public List<Csapat> csapatok = new();

        void Feltolt()
        {
            foreach (var mecs in Meccs)
            {
                if (csapatok.Count(n => n.Nev == mecs.HazaiCsapat) != 0)
                {
                    int wins = 0, ties = 0, loses = 0;
                    int points = 0;
                    if (mecs.HazaiVeg > mecs.VendegVeg)
                    {
                        wins++;
                        points = 3;
                    }
                    else if (mecs.HazaiVeg == mecs.VendegVeg)
                    {
                        ties++;
                        points = 1;
                    }
                    else
                    {
                        loses++;
                    }
                    int goalsScored = mecs.HazaiVeg;
                    int goalsTaken = mecs.VendegVeg;

                    Csapat csap = csapatok.Where(n => n.Nev == mecs.HazaiCsapat).First();
                    csap.Wins += wins;
                    csap.Ties += ties;
                    csap.Loses += loses;
                    csap.GoalsTaken += goalsTaken;
                    csap.GoalsScored += goalsScored;
                    csap.NumberOfMatches++;
                    csap.Points+= points;

                }
                if (csapatok.Count(n => n.Nev == mecs.VendegCsapat) != 0)
                {
                    int wins = 0, ties = 0, loses = 0;
                    int points = 0;
                    if (mecs.VendegVeg > mecs.HazaiVeg)
                    {
                        wins++;
                        points = 3;
                    }
                    else if (mecs.VendegVeg == mecs.HazaiVeg)
                    {
                        ties++;
                        points = 1;
                    }
                    else
                    {
                        loses++;
                    }
                    int goalsScored = mecs.VendegVeg;
                    int goalsTaken = mecs.HazaiVeg;

                    Csapat csap = csapatok.Where(n => n.Nev == mecs.VendegCsapat).First();
                    csap.Wins += wins;
                    csap.Ties += ties;
                    csap.Loses += loses;
                    csap.GoalsTaken += goalsTaken;
                    csap.GoalsScored += goalsScored;
                    csap.NumberOfMatches++;
                    csap.Points += points;
                }
                if (csapatok.Count(n=>n.Nev==mecs.HazaiCsapat)==0)
                {
                    string csapatNev = mecs.HazaiCsapat;
                    int wins=0, ties=0, loses = 0;
                    if (mecs.HazaiVeg>mecs.VendegVeg)
                    {
                        wins++;
                    }
                    else if (mecs.HazaiVeg == mecs.VendegVeg)
                    {
                        ties++;
                    }
                    else
                    {
                        loses++;
                    }
                    int goalsScored = mecs.HazaiVeg;
                    int goalsTaken = mecs.VendegVeg;
                    csapatok.Add(new Csapat(csapatNev, wins, ties, loses, goalsScored, goalsTaken));
                }
                if (csapatok.Count(n => n.Nev == mecs.VendegCsapat) == 0)
                {
                    string csapatNev = mecs.VendegCsapat;
                    int wins = 0, ties = 0, loses = 0;
                    if (mecs.VendegVeg > mecs.HazaiVeg)
                    {
                        wins++;
                    }
                    else if (mecs.VendegVeg == mecs.HazaiVeg)
                    {
                        ties++;
                    }
                    else
                    {
                        loses++;
                    }
                    int goalsScored = mecs.VendegVeg;
                    int goalsTaken = mecs.HazaiVeg;
                    csapatok.Add(new Csapat(csapatNev, wins, ties, loses, goalsScored, goalsTaken));
                }



            }

            csapatok=csapatok.OrderByDescending(n=>n.Points).ToList();
            int counter = 0;
            foreach (var item in csapatok)
            {
                counter++;
                item.Helyezes = counter;
            }
        }
    }
}
