using Microsoft.AspNetCore.Mvc;

[ApiController, Route("[controller]/word")]
public class ApiController(DataContext db) : ControllerBase
{
  private readonly DataContext _dataContext = db;

  // http get entire collection
  [HttpGet]
  public IEnumerable<Word> Get()
  {
      return _dataContext.Words;
  }
  // http get specific member of collection
  [HttpGet("{id}")]
  public Word? Get(int id)
  {
      return _dataContext.Words.Find(id);
  }
  // http post member to collection
  [HttpPost]
  public async Task<ActionResult<Word>> Post([FromBody] Word word) {
    _dataContext.Add(word);
    await _dataContext.SaveChangesAsync();
    return word;
  }
  // http delete member from collection
  [HttpDelete("{id}")]
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
