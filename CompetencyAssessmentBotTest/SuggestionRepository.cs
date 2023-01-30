using CompetencyAssessmentBotTest.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CompetencyAssessmentBotTest
{
    public class SuggestionRepository : ISuggestionRepository
    {
        private readonly CompetencyBotDBContext competencyBotDBContext;
        //constructor of this class
        public SuggestionRepository(CompetencyBotDBContext competencyBotDBContext)
        {
            this.competencyBotDBContext = competencyBotDBContext;
        }

        public async Task<Suggestions> AddSuggestion(Suggestions suggestion)
        {
            var result = competencyBotDBContext.Suggestions.AddAsync(suggestion);
            await competencyBotDBContext.SaveChangesAsync();
            return suggestion;
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<Suggestions>> GetSuggestion()
        {
            return await competencyBotDBContext.Suggestions.ToListAsync();

            //throw new NotImplementedException();
        }

        public async Task<Suggestions> GetSuggestion(int SNO)
        {
            return await competencyBotDBContext.Suggestions.FirstOrDefaultAsync(l => l.SNo == SNO);

            //throw new NotImplementedException();
        }

        public async Task<Suggestions> UpdateSuggestion(Suggestions suggestion)
        {
            var result = await competencyBotDBContext.Suggestions.FirstOrDefaultAsync(l => l.SNo == suggestion.SNo);
            if (result != null)
            {
                result.status = suggestion.status;
               

                await competencyBotDBContext.SaveChangesAsync();
                return result;
            }
            return null;

            //throw new NotImplementedException();
        }

    }
}
