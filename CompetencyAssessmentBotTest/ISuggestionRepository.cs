using CompetencyAssessmentBotTest.Models;

namespace CompetencyAssessmentBotTest
{
    public interface ISuggestionRepository
    {
        Task<IEnumerable<Suggestions>> GetSuggestion();
        Task<Suggestions> GetSuggestion(int SNO);
        Task<Suggestions> AddSuggestion(Suggestions suggestion);
        Task<Suggestions> UpdateSuggestion(Suggestions suggestion);
    }
}
