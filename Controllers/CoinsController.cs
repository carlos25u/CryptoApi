using CryptoApi.DAL;
using CryptoApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CryptoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CoinsController : ControllerBase
{

    private readonly ILogger<CoinsController> _logger;
    private Contexto _contexto;

    public CoinsController(ILogger<CoinsController> logger, Contexto contexto)
    {
        _logger = logger;
        _contexto = contexto;

    }

    [HttpGet("GetCoins")]
    public IEnumerable<Coins> Get()
    {
        return _contexto.Coins.AsNoTracking().ToList();
    }

    [HttpPost("PostCoins")]
    public async Task<ActionResult<Coins>> postCoin(Coins coin)
    {
        _contexto.Coins.Add(coin);
        await _contexto.SaveChangesAsync();
        return CreatedAtAction(nameof(postCoin), coin);
    }

    [HttpDelete("DeleteCoins/{id}")]
    public async Task<ActionResult<Coins>> deleteCoins(int id)
    {
        var coins = await _contexto.Coins.FindAsync(id);

        if (coins != null)
        {
            _contexto.Coins.Remove(coins);
            await _contexto.SaveChangesAsync();
        }
        else
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpGet("GetCoin/{id}")]
    public async Task<ActionResult<Coins>>GetCoin(int id)
    {
        var coins = await _contexto.Coins.FindAsync(id);

        if(coins == null)
        {
            return NotFound();
        }
        
        return coins;
    }

    [HttpPut("PutCoins/{id}")]
    public async Task<ActionResult<Coins>> PutCoins(int id, Coins coins)
    {
        if (id != coins.CoinId)
        {
            return BadRequest();
        }

        _contexto.Entry(coins).State = EntityState.Modified;

        try
        {
            await _contexto.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ExisteCoins(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    private bool ExisteCoins(int id)
    {
        return _contexto.Coins.Any(e => e.CoinId == id);
    }

}
