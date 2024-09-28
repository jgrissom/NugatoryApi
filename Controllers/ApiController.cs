using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

[ApiController, Route("[controller]/word")]
public class ApiController(DataContext db) : ControllerBase
{
  private readonly DataContext _dataContext = db;

  // http get entire collection
  [HttpGet, SwaggerOperation(summary: "returns all words", null)]
  public IEnumerable<Word> Get()
  {
      return _dataContext.Words;
  }
  // http get specific member of collection
  [HttpGet("{id}"), SwaggerOperation(summary: "returns specific word", null)]
  public Word? Get(int id)
  {
      return _dataContext.Words.Find(id);
  }
  // http post member to collection
  [HttpPost, SwaggerOperation(summary: "add word to collection", null), ProducesResponseType(typeof(Word), 201), SwaggerResponse(201, "Created")]
  public async Task<ActionResult<Word>> Post([FromBody] Word word) {
    _dataContext.Add(word);
    await _dataContext.SaveChangesAsync();
    return word;
  }
  // http delete member from collection
  [HttpDelete("{id}"), SwaggerOperation(summary: "delete word from collection", null), ProducesResponseType(typeof(Word), 204), SwaggerResponse(204, "No Content")]
  public async Task<ActionResult> Delete(int id){
    Word? word = await _dataContext.Words.FindAsync(id);
    if (word == null){
        return NotFound();
    }
    _dataContext.Remove(word);
    await _dataContext.SaveChangesAsync();
    return NoContent();
  }
}
