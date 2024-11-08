using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

public class GLBudgetEntryService
{
    private readonly HttpClient _httpClient;

    public GLBudgetEntryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<GLBudgetEntry>> GetGLBudgetEntriesAsync()
    {
        var url = "http://machine:7048/BC240/ODataV4/Company('CRONUS%20International%20Ltd.')/G_LBudgetEntries";
        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var jsonData = JsonDocument.Parse(jsonString);
            var glBudgetEntries = jsonData.RootElement.GetProperty("value");
            return JsonSerializer.Deserialize<List<GLBudgetEntry>>(glBudgetEntries.ToString());
        }

        return new List<GLBudgetEntry>();
    }
}

public class GLBudgetEntry
{
    public int Entry_No { get; set; }                   // The unique entry number
    public string? Budget_Name { get; set; }            // The name of the budget
    public string? G_L_Account_No { get; set; }         // The general ledger account number
    public string? Business_Unit_Code { get; set; }     // The business unit code
    public string? Date { get; set; }                   // The date of the budget entry
    public decimal Amount { get; set; }                 // The amount for the entry
    public int Dimension_Set_ID { get; set; }           // The dimension set ID
}