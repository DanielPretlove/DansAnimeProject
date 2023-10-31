using AnimeList.Application.Services.AnimeList;
using AnimeList.Data.Entities.AnimeSeries;
using AnimeList.Web.Shared.Models.AnimeSeries.Seasons;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnimeList.Web.Server.Controllers.AnimeList
{
    public class SeasonController : BaseApiController
    {
        private readonly SeasonService _service;
        private readonly Mapper _mapper;

        public SeasonController(SeasonService service, Mapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<ActionResult<IList<Seasons>>> GetList()
        {
            var result = await _service.GetAll();
            return Ok(result.Select(n => _mapper.Map<IList<SeasonsListModel>>(result)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Seasons>> GetById(Guid id)
        {
            var result = await _service.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            else
            {
                return Ok(_mapper.Map<SeasonsDisplayModel>(result));
            }
        }

        [HttpPost]
        public async Task<ActionResult<Seasons>> InsertAnime(Seasons data)
        {
            var result = await _service.Insert(data);
            return Ok(_mapper.Map<SeasonsEditRetrieveModel>(result));
        }

        [HttpPut]
        public async Task UpdateAnime(Seasons data)
        {
            await _service.Update(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Seasons>> DeleteAnime(Guid id)
        {
            var result = await _service.Delete(id);
            return Ok(_mapper.Map<SeasonsEditRetrieveModel>(result));
        }
    }
}
