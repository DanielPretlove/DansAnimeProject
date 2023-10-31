using AnimeList.Application.Services;
using AnimeList.Application.Services.AnimeList;
using AnimeList.Data.Entities.AnimeSeries;
using AnimeList.Web.Shared.Models.AnimeSeries.Anime;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimeList.Web.Server.Controllers.AnimeList
{
    public class AnimeController : BaseApiController
    {
        private readonly AnimeService _service;
        private readonly Mapper _mapper;

        public AnimeController(AnimeService service, Mapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<ActionResult<IList<Anime>>> GetList()
        {
            var result = await _service.GetAll();
            return Ok(result.Select(n => _mapper.Map<IList<AnimeListModel>>(result)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Anime>> GetById(Guid id)
        {
            var result = await _service.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            else
            {
                return Ok(_mapper.Map<AnimeDisplayModel>(result));
            }
        }

        [HttpPost]
        public async Task<ActionResult<Anime>> InsertAnime(Anime data)
        {
            var result = await _service.Insert(data);
            return Ok(_mapper.Map<AnimeEditRetrieveModel>(result));
        }

        [HttpPut]
        public async Task UpdateAnime(Anime data)
        {
            await _service.Update(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Anime>> DeleteAnime(Guid id)
        {
            var result = await _service.Delete(id);
            return Ok(_mapper.Map<AnimeEditRetrieveModel>(result));
        }
    }
}
